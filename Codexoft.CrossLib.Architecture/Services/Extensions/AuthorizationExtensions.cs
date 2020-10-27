using System;
using Codexoft.CrossLib.Architecture.Data.Entities;
using Codexoft.CrossLib.Architecture.Database;
using Codexoft.CrossLib.Architecture.Exceptions;
using Codexoft.CrossLib.Architecture.Services.Helper;

namespace Codexoft.CrossLib.Architecture.Services.Extensions
{
    public static class AuthorizationExtensions
    {
        public static bool Authorize<T>(this IDataService service, T entity, Func<T, User, IAppDbContext, bool> policy)
        {
            if (policy.Invoke(entity, service.Authenticated, service.Context))
            {
                return true;
            }
            else
            {
                throw new UnauthorizedRequestException();
            }
        }

        public static bool Authorize(this IDataService service, Func<User, IAppDbContext, bool> policy)
        {
            if (policy.Invoke(service.Authenticated, service.Context))
            {
                return true;
            }
            else
            {
                throw new UnauthorizedRequestException();
            }
        }
    }
}