using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using EntityFramework.Extensions;

namespace SignalRSamples.Infrastructure.Data.Ef
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
      
        private readonly DbContext _context;
        private DbSet<TEntity> _entities;

        public EfRepository(IEfDbContextFactory factory)
        {
        
            this._context = factory.GetDbContext();
        }

        public virtual IQueryable<TEntity> Table
        {
            get
            {
                return this.Entities;
            }
        }

        protected DbSet<TEntity> Entities
        {
            get { return _entities ?? (_entities = _context.Set<TEntity>()); }
        }


        public TEntity GetById(object id)
        {
            return this.Entities.Find(id);
        }


        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            try
            {
                this.Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(dbEx.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage);
            }

        }

        public void AddOrUpdate(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Modified;
            }
            this.Entities.AddOrUpdate(entity);
            _context.SaveChanges();
        }

        public void AddRange(IList<TEntity> list)
        {
            if (list == null)
                throw new ArgumentNullException("entity");
            //批量操作前 关闭自动检测变化功能
            _context.Configuration.AutoDetectChangesEnabled = false;
            foreach (var e in list)
            {
                this.Entities.Add(e);
            }
            _context.Configuration.AutoDetectChangesEnabled = true;
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void Update(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            Entities.Where(expression).Update(updateExpression);
        }


        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Delete(Expression<Func<TEntity, bool>> expression)
        {
            //var q = this.Get(expression);
            //foreach (var item in q)
            //{
            //    Entities.Remove(item);
            //}
            //context.SaveChanges();
            Entities.Where(expression).Delete();
        }

        public void Delete(object id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

    }
}
