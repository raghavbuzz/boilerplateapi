﻿using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }
        public IQueryable<T> FindAll()
        {
            var result = this.RepositoryContext.Set<T>().AsNoTracking();
            return result;
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            var result = this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
            return result;
        }        
    }
}
