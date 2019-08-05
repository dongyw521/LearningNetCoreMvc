using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Learning.NetCore.Domain.IRepositories
{
    public interface IRepository
    {

    }

    public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : Entity<TPrimaryKey>
    {
        List<TEntity> GetAllList();

        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        TEntity GetEntity(TPrimaryKey id);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity InsertOrUpdate(TEntity entity);

        TEntity Delete(TEntity entity);

        void Delete(TPrimaryKey id);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : Entity
    {

    }
}