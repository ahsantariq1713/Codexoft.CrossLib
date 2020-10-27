using System.Collections.Generic;
using System.Threading.Tasks;
using Codexoft.CrossLib.Architecture.Data.Entities;
using Codexoft.CrossLib.Architecture.Database;

namespace Codexoft.CrossLib.Architecture.Services.Helper
{
    public interface IDataService
    {
        User Authenticated { get; }
        IAppDbContext Context { get; }
    }

    public interface IDataService<TEntity, in TCreateModel, in TUpdateModel>
    {
        Task<TEntity> GetAsync(string id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> CreateAsync(TCreateModel model);
        Task<TEntity> UpdateAsync(string id, TUpdateModel model);
        Task<TEntity> DeleteAsync(string id);

    }

    public interface IDataService<TEntity, in TCreateModel>
    {
        Task<TEntity> GetAsync(string id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> CreateAsync(TCreateModel model);
        Task<TEntity> UpdateAsync(string id, TEntity model);
        Task<TEntity> DeleteAsync(string id);

    }

    public interface IDataService<TEntity>
    {
        Task<TEntity> GetAsync(string id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> CreateAsync(TEntity model);
        Task<TEntity> UpdateAsync(string id, TEntity model);
        Task<TEntity> DeleteAsync(string id);

    }
}
