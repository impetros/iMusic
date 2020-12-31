using System;
using iMusic.DataModel.Context;
using iMusic.DataModel.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace iMusic.DataModel.Repository.Implementation
{
    public class GenericRepository<TEntity> : IRepository, IGenericRepository<TEntity> where TEntity : class
    {
        protected AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }


        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(object id)
        {
            _context.Set<TEntity>().Remove(_dbSet.Find(id));
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            _context.Set<TEntity>().Remove(entityToDelete);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return entity;
        }

    }
}
