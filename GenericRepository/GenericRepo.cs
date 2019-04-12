using DataModels;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GenericRepository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class, IBaseModel
    {
        protected EFContext _context;
        protected IBaseSession sessionInfo;

        public GenericRepo(EFContext _context, IBaseSession sessionInfo)
        {
            this.sessionInfo = sessionInfo;
            this._context = _context;
        }


        public RModel<T> Where(Expression<Func<T, bool>> filter, bool ShowTombstone, params Expression<Func<T, object>>[] includes)
        {
            RModel<T> res = new RModel<T>();
            try
            {
                var query = _context.Set<T>() as IQueryable<T>;
                if (!ShowTombstone)
                    query = query.Where(o => o.Tombstone == null);
                if (filter != null)
                    query = query.Where(filter);

                if (includes.Count() > 0)
                {
                    if (!ShowTombstone)
                        query = includes.Aggregate(query, (current, include) => current.Include(include).Where(o => o.Tombstone == null));
                    else
                        query = includes.Aggregate(query, (current, include) => current.Include(include));
                }

                res.Result = query;
                res.ResultType = RType.OK;
            }
            catch (Exception ex)
            {
                res.ResultType = RType.Error;
                res.ErrorList.Add(ex.Message);
            }
            return res;
        }
        public RModel<T> FirstOrDefault(Expression<Func<T, bool>> filter, bool ShowTombstone = false, params Expression<Func<T, object>>[] includes)
        {
            RModel<T> res = new RModel<T>();
            try
            {
                var query = _context.Set<T>() as IQueryable<T>;
                if (!ShowTombstone)
                    query = query.Where(o => o.Tombstone == null);
                if (filter != null)
                    query = query.Where(filter);

                if (includes != null)
                {
                    if (!ShowTombstone)
                        query = includes.Aggregate(query, (current, include) => current.Include(include).Where(o => o.Tombstone == null));
                    else
                        query = includes.Aggregate(query, (current, include) => current.Include(include));
                }

                res.ResultRow = query.FirstOrDefault();
                res.ResultType = RType.OK;
            }
            catch (Exception ex)
            {
                res.ResultType = RType.Error;
                res.ErrorList.Add(ex.Message);
            }
            return res;
        }

        public bool Any(bool ShowTombstone = false)
        {
            var query = _context.Set<T>() as IQueryable<T>;
            if (!ShowTombstone)
                query = query.Where(o => o.Tombstone == null);

            return query.Any();
        }


        public T Find(int id, bool ShowTombstone = false)
        {
            var query = _context.Set<T>() as IQueryable<T>;
            if (!ShowTombstone)
                query = query.Where(o => o.Tombstone == null);
            return _context.Set<T>().Find(id);
        }


        public T Add(T t)
        {
            t.CreaUser = sessionInfo._BaseModel.CreaUser;
            t.CreaDate = DateTime.Now;
            _context.Set<T>().Add(t);
            return t;
        }

        public List<T> AddBulk(List<T> tList)
        {
            //_context.Configuration.AutoDetectChangesEnabled = false;
            tList.ForEach(t =>
            {
                _context.Entry(t).State = EntityState.Added;
                t.CreaUser = sessionInfo._BaseModel.CreaUser;
                t.CreaDate = DateTime.Now;
            });
            _context.Set<T>().AddRange(tList);
            //_context.Configuration.AutoDetectChangesEnabled = true;
            _context.ChangeTracker.DetectChanges();
            return tList;
        }

        public T Delete(int id)
        {
            var t = Find(id);
            if (t != null)
            {
                t.Tombstone = DateTime.Now;
                Update(t);
            }
            return t;
        }

        public T Delete(T t)
        {
            t.Tombstone = DateTime.Now;
            return Update(t);
        }

        public List<T> DeleteBulk(List<T> tList)
        {
            return UpdateBulk(tList, DateTime.Now);
        }

        public T Update(T t)
        {
            t.ModUser = sessionInfo._BaseModel.CreaUser;
            t.ModDate = DateTime.Now;
            var dbEntityEntry = _context.Entry(t);
            _context.Entry(t).State = EntityState.Modified;
            dbEntityEntry.Property(o => o.CreaDate).IsModified = false;
            return t;
        }

        public List<T> UpdateBulk(List<T> tList)
        {
            return UpdateBulk(tList, null);
        }

        List<T> UpdateBulk(List<T> tList, DateTime? Tombstone)
        {
            //_context.Configuration.AutoDetectChangesEnabled = false;
            tList.ForEach(t =>
            {
                if (Tombstone != null)
                    t.Tombstone = DateTime.Now;
                Update(t);
            });
            //_context.Configuration.AutoDetectChangesEnabled = true;
            _context.ChangeTracker.DetectChanges();
            return tList;
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;

        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}