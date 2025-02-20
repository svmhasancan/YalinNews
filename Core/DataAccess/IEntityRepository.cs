using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // Tüm kayıtları getir
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        
        // Tek bir kaydı getir
        T Get(Expression<Func<T, bool>> filter);
        
        // Yeni kayıt ekle
        void Add(T entity);
        
        // Kayıt güncelle
        void Update(T entity);
        
        // Kayıt sil
        void Delete(T entity);
    }
} 