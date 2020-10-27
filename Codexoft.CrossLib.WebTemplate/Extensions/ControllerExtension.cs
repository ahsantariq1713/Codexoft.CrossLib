using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Codexoft.CrossLib.Architecture.Database;
using Codexoft.CrossLib.Architecture.Data.Entities;

namespace Codexoft.CrossLib.WebTemplate.Extensions
{
    public static class ControllerExtension
    {
        public static void Authorize<T>(this ControllerBase controller, T entity, Func<T, User, IAppDbContext, bool> policy, IAppDbContext context)
        {
            var user = GetAuthenticatedUser(controller);
            ValidateAuthorization(policy.Invoke(entity, user, context));

        }

        public static void Authorize(this ControllerBase controller, Func<User, IAppDbContext, bool> policy, IAppDbContext context)
        {
            var user = GetAuthenticatedUser(controller);
            ValidateAuthorization(policy.Invoke(user, context));
        }

        private static User GetAuthenticatedUser(ControllerBase controller)
        {
            var user = new User();
            foreach (var claim in controller.User.Claims)
            {
                switch (claim.Type)
                {
                    case ClaimTypes.Role:
                        user.Role = claim.Value;
                        break;
                    case ClaimTypes.PrimarySid:
                        user.SetId(claim.Value);
                        break;
                    default:
                        break;
                }
            }
            return user;
        }

        private static void ValidateAuthorization(bool authorized)
        {
            if (!authorized)
            {
                throw new UnauthorizedAccessException();
            }
        }
    }
}
