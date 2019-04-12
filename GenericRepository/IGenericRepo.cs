
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GenericRepository
{
    public interface IGenericRepo<T> where T : class
    {
        RModel<T> Where(Expression<Func<T, bool>> filter, bool ShowTombstone = false, params Expression<Func<T, object>>[] includes);
        RModel<T> FirstOrDefault(Expression<Func<T, bool>> filter, bool ShowTombstone = false, params Expression<Func<T, object>>[] includes);
        T Find(int id, bool ShowTombstone = false);
        bool Any(bool ShowTombstone = false);
        T Add(T t);
        List<T> AddBulk(List<T> tList);
        T Delete(int id);
        T Delete(T t);
        List<T> DeleteBulk(List<T> tList);
        T Update(T t);
        List<T> UpdateBulk(List<T> tList);
        int SaveChanges();
        void Dispose();

    }
}