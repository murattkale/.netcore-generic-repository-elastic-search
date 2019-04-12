using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ElasticSearchRepository
{
    public interface IElasticSearchRepository<T> where T : class
    {
        IBulkResponse  BulkInsert(IEnumerable<T> entities);
        T Save(T entity);
        T Get(Guid id);
        T Update(T entity);
        bool Delete(Guid id);
        bool DeleteIndex();
        IEnumerable<T> Search(BaseSearchModel search);
        IEnumerable<T> SearchAll(BaseSearchModel request);
    }
}