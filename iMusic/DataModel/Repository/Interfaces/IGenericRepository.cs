using System;
namespace iMusic.DataModel.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> : IRepository where TEntity : class
    {
        TEntity GetById(object id);

        void Add(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);

        TEntity Update(TEntity entity);

    }
}
