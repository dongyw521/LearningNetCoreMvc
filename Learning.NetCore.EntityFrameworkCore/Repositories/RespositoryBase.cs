using System;
using Learning.NetCore.Domain.IRepositories;
using Learning.NetCore.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Learning.NetCore.EntityFrameworkCore.Repositories
{
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        protected readonly kuchenDbContext _dbContext;
        public RepositoryBase(kuchenDbContext dbContext) => _dbContext = dbContext;

        public List<TEntity> GetAllList()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity GetEntity(TPrimaryKey id)
        {
            return _dbContext.Set<TEntity>().Where(CreateEqualExpressionForId(id)).FirstOrDefault();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public TEntity Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            if (GetEntity(entity.Id) != null)
                return Update(entity);
            return Insert(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return entity;
        }

        public void Delete(TPrimaryKey id)
        {
            _dbContext.Set<TEntity>().Remove(GetEntity(id));
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        protected static Expression<Func<TEntity, bool>> CreateEqualExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));
            var lambdaBody = Expression.Equal(Expression.PropertyOrField(lambdaParam, "Id"), Expression.Constant(id, typeof(TPrimaryKey)));
            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }

    public abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity, int> where TEntity : Entity
    {
        public RepositoryBase(kuchenDbContext dbContext) : base(dbContext)
        {

        }
    }
}