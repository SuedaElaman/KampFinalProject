//using Core.DataAcces;  Core.Entities olması lazım çıkmıyo

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace Core.DataAccess.EntityFramework
{
    
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>

        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()

    {
        public void Add(TEntity entity)
        {
            //IDispossable pattern implementation of c#
            using (TContext context = new TContext()) //  using içinde yazılan nesneler  using bitinve bellekten at diyor 
            {
                // eklenen varlık
                var addedEntity = context.Entry(entity); //git benim gönderdiğim producta veri kaynağından nesneyle eşleştir
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }

        }


        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) //  using içinde yazılan nesneler  using bitinve bellekten at diyor 
            {
                // eklenen varlık
                var deletedEntity = context.Entry(entity); //git benim gönderdiğim producta veri kaynağından nesneyle eşleştir
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);


            }

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        //public void Test()
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) //  using içinde yazılan nesneler  using bitinve bellekten at diyor 
            {
                // eklenen varlık
                var updatedEntity = context.Entry(entity); //git benim gönderdiğim producta veri kaynağından nesneyle eşleştir
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }


        }


    }


}
