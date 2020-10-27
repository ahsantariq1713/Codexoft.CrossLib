using Codexoft.CrossLib.Architecture.Data.Entities;
using Codexoft.CrossLib.Architecture.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codexoft.CrossLib.Architecture.Services.Helper
{
    public class BaseService : IDataService
    {
        public IAppDbContext Context { get; }
        private readonly User _authenticatedUser;
        public User Authenticated => AuthenticatedUserProvider.NotClaimBasedAuthentication ? AuthenticatedUserProvider.Instance : _authenticatedUser;

        public BaseService(IAppDbContext context, User auth) : this(context)
        {
            _authenticatedUser = auth;
        }

        public BaseService(IAppDbContext context)
        {
            Context = context;
        }
    }
}
