using BCrypt.Net;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Codexoft.CrossLib.Architecture.Exceptions;
using Codexoft.CrossLib.Architecture.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Codexoft.CrossLib.Architecture.Data.Entities;
using Codexoft.CrossLib.Architecture.Data.Models;
using Codexoft.CrossLib.Architecture.Database;
using Codexoft.CrossLib.Architecture.Services.Extensions;
using Codexoft.CrossLib.Architecture.Policies;
using Codexoft.CrossLib.Architecture.Services.Helper;
using Microsoft.EntityFrameworkCore;

namespace Codexoft.CrossLib.Architecture.Services
{

    public class UserService : BaseService, IDataService<User, RegisterModel>
    {
        public UserService(IAppDbContext context, User auth) : base(context, auth)
        {
        }

        public UserService(IAppDbContext context) : base(context)
        {
        }

        [AutoValidateModelIfClient]
        public async Task<User> GetAuthenticatedUserAsync(LoginModel model)
        {
            //defend
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //arrange
            var user = await Context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
            var isAuthenticated = (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.HashPassword));

            //register logged in user if the authentication is not claim based
            if (isAuthenticated && AuthenticatedUserProvider.NotClaimBasedAuthentication)
            {
                AuthenticatedUserProvider.Instance = user;
            }

            //return
            return isAuthenticated ? user : null;
        }


        public Task<User> CreateAsync(RegisterModel model, string role)
        {
            //defend
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (role is null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            //arrange
            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Role = role
            };

            user.SetHashPassword(model.Password);

            //track and validate
            user.TrackAndValidate();

            //commit changes
            Context.Users.Add(user);
            Context.SaveChanges();

            //resturn result
            return Task.FromResult(user);
        }

        public Task<User> CreateAsync(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        [AutoValidateModelIfClient]
        public async Task<IEnumerable<User>> GetAsync()
        {
            //authroize
            this.Authorize(UserPolicy.ReadAll);

            //arrange
            IEnumerable<User> users = await Context.Users.ToListAsync();

            //return
            return users;
        }

        public Task<User> GetAsync(string id)
        {
            //defend
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            //arrange
            var user = Context.Users.Find(id) ?? throw new EntityNotFoundException();

            //authorize
            this.Authorize(user, UserPolicy.Read);

            //return
            return Task.FromResult(user);
        }

        public Task<User> UpdateAsync(string id, User model)
        {
            //defend
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //arrange
            var user = Context.Users.Find(id) ?? throw new EntityNotFoundException();

            //authorize
            this.Authorize(user, UserPolicy.Update);

            //modify
            user.Email = model.Email;
            user.Name = model.Name;

            //track and validate
            user.TrackAndValidate();

            //commit changes
            Context.Users.Update(user);
            Context.SaveChanges();

            //return
            return Task.FromResult(user);
        }
    }

}