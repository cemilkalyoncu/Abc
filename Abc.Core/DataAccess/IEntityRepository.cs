using Abc.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Abc.Core.DataAccess
{
    #region Aşağıdaki interface için bilgilendirme!
    /* Repository generic olacak o yüzden T,
    * Generic kısıtlar için "where" koşulundan yararlanıyoruz.
    * Class:Referans tip genel olarak class olacak
    * IEntity'den implement edilmiş olmalı buraya ancak veritabanı nesnesi yazılmalı.
    * new() ile classları engelliyoruz.
    * (Absractlarda class olduğundan onları engelliyoruz.)
    * Veri tabanında 5 temel operasyon vardır.
    * Get() = LinqExpression ile parametreye göre 
    * tek bir nesne çekmek için Get()'i kullanırız.
    * Expression bir filtredir. List için kullanışlı oluyor.*/
    #endregion

    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity); 
        void Delete(T entity);
    }
}
