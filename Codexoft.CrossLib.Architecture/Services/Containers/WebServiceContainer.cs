using Codexoft.CrossLib.Architecture.Data.Entities;
using Codexoft.CrossLib.Architecture.Database;
using System.Security.Claims;

namespace Codexoft.CrossLib.Architecture.Services.Containers
{
    public partial class WebServiceContainer
    {
        /// <summary>
        /// Please don't modify the author access code
        /// </summary>
        #region AuthorAccess
        private readonly IAppDbContext _dbContext;
        private readonly User _authenticated;

        public WebServiceContainer(IAppDbContext context, ClaimsPrincipal principal)
        {
            _dbContext = context;
            _authenticated = GetUserFromClaims(principal);
        }

        private static User GetUserFromClaims(ClaimsPrincipal principal)
        {
            var user = new User();

            if (principal?.Claims == null) return user;

            foreach (var claim in principal?.Claims)
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
        #endregion


        /// <summary>
        /// Register Services
        /// </summary>
        private UserService _userService;
        public UserService UserService => _userService ?? (_userService = new UserService(_dbContext, _authenticated));
    }
}
