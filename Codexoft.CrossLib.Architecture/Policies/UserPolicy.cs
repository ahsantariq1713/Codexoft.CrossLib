using Codexoft.CrossLib.Architecture.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codexoft.CrossLib.Architecture.Data.Entities;
using Codexoft.CrossLib.Architecture.Database;

namespace Codexoft.CrossLib.Architecture.Policies
{
    public static class UserPolicy
    {
        public static bool ReadAll(User auth, IAppDbContext context)
        {
            return
                auth.Role == UserRoles.Administrator;
        }

        public static bool Read(User user, User auth, IAppDbContext context)
        {
            return
                auth.Role == UserRoles.Administrator
                ||
                user.Id == auth.Id;
        }

        public static bool Delete(User user, User auth, IAppDbContext context)
        {
            return
                user.Id == auth.Id;
        }

        public static bool Update(User user, User auth, IAppDbContext context)
        {
            return
                user.Id == auth.Id;
        }
    }
}