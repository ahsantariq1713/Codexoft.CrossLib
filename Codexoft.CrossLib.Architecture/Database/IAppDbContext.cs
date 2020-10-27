using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Codexoft.CrossLib.Architecture.Data.Entities;

namespace Codexoft.CrossLib.Architecture.Database
{
    public interface IAppDbContext
    {
        /// <summary>
        /// Please don't modify the author access code
        /// </summary>
        #region AuthorAccess
        int SaveChanges();
        EntityEntry Entry(object entity);
        #endregion

        //Register database tables
        DbSet<User> Users { get; set; }
    }
}
