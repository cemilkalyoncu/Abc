using Abc.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Abc.Core.DataAccess.EntityFramework
{
    #region EfEntityRepositoryBase implement açıklama
    /* TEntity, TContext sorgu yazabilmemiz için 2 şeye ihtiyaç vardır.
    * hangi nesne ile çalışılacak hangi context ile çalışıcak belirtiyoruz.
    */
    /* hem Entity hem Context için kısıltlamalar where şartı ile veriyoruz.
     * Tcontext' e dbcontext yani entityframework dbcontextinden türeyen bi nesne olmalı.
     * DbContext referans yapılmalı. using Microsoft.EntityFrameworkCore;
     */
    #endregion

    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        /* filter = null> default değer isteseydik null eklerdik, zorunluluk yok. */
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            /* benim gönderdiğim contextten bir new istiyorum*/
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                /* filter null ise listele eğer null değilse 
                 * yani bir parametre göndermişse şarta göre listele */
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                /* "Entry" yani hangi entity ile çalışacağımı belirtiyorum. 
                 * nesne ile ilgili bir product olustur ve 
                 * onun eklenmesi gereken bir nesne olduğunu anla (EntityState.Added) */
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
