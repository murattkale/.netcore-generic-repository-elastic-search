using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ElasticSearchRepository
{
    public  class ElasticSearchRepository<T> : IElasticSearchRepository<T> where T : class
    {
        protected ElasticClient _elasticClient;
        protected string _indexName;

        public ElasticSearchRepository(string indexName, string _cn)
        {
            _elasticClient = ElasticSearchClientHelper.CreateElasticClient(_cn);
            _indexName = indexName;
        }

        public virtual IEnumerable<T> Search(BaseSearchModel request)
        {
            request.Size = request.Size == 0 ? 10000 : request.Size;
            var dynamicQuery = new List<QueryContainer>();
            foreach (var item in request.Fields)
            {
                dynamicQuery.Add(Query<T>.Match(m => m.Field(new Field(item.Key.ToLower())).Query(item.Value)));
            }
            if (request._NumericRangeQuery != null)
            {
                var result = _elasticClient.Search<T>(s => s
                                     .Index(_indexName)
                                     .Size(request.Size)
                                     .Query(q => q.Range(o => request._NumericRangeQuery))
                                     .Sort(ss => ss
                                     .Field(f => SortOrderCustom(f, request.orderProp, request.order))
                                     )
                                     );
                if (!result.IsValid)
                {
                    throw new Exception(result.OriginalException.Message);
                }

                return result.Documents;
            }
            else
            {
                var dynamicarray = dynamicQuery.ToArray();
                var result = _elasticClient.Search<T>(s => s
                                                            .From(request.From)
                                                            .Size(request.Size)
                                                            .Index(_indexName)
                                                            .Query(q => q.Bool(b => b.Must(dynamicarray)))
                                                            .Sort(ss => ss
                                                            .Field(f => SortOrderCustom(f, request.orderProp, request.order))
                                                            )
                                                            );
                if (!result.IsValid)
                {
                    throw new Exception(result.OriginalException.Message);
                }

                return result.Documents;
            }
        }

        public virtual IEnumerable<T> SearchAll(BaseSearchModel request)
        {
            return _elasticClient.Search<T>(search => search
                         .Sort(o => o.Field(c => SortOrderCustom(c, request.orderProp, request.order)))
                         .MatchAll().Index(_indexName)).Documents;
        }

        public virtual T Save(T entity)
        {
            var result = _elasticClient.Index<T>(entity, idx => idx.Index(_indexName));

            if (!result.IsValid)
            {
                throw new Exception(result.OriginalException.Message);
            }
            return entity;
        }

        public virtual IBulkResponse BulkInsert(IEnumerable<T> entities)
        {
            var request = new BulkDescriptor();

            foreach (var entity in entities)
            {
                request
                    .Index<T>(op => op
                        .Id(Guid.NewGuid().ToString())
                        .Index(_indexName)
                        .Document(entity));
            }

            var result = _elasticClient.Bulk(request);
            return result;
        }

        public virtual T Get(Guid id)
        {
            var result = _elasticClient.Get<T>(id.ToString(), idx => idx.Index(_indexName));
            if (!result.IsValid)
            {
                throw new Exception(result.OriginalException.Message);
            }
            return result.Source;
        }

        public virtual bool Delete(Guid id)
        {
            var result = _elasticClient.Delete<T>(id.ToString(), idx => idx.Index(_indexName));
            if (!result.IsValid)
            {
                throw new Exception(result.OriginalException.Message);
            }
            return result.IsValid;
        }

        public virtual bool DeleteIndex()
        {
            var result = _elasticClient.DeleteIndex(_indexName);
            if (!result.IsValid)
            {
                throw new Exception(result.OriginalException.Message);
            }
            return result.IsValid;
        }

        public virtual T Update(T entity)
        {
            var result = _elasticClient.Update(
                    new DocumentPath<T>(entity), u =>
                        u.Doc(entity).Index(_indexName));
            if (!result.IsValid)
            {
                throw new Exception(result.OriginalException.Message);
            }
            return entity;
        }

        public IFieldSort SortOrderCustom(SortFieldDescriptor<T> f, string ordername = "", SortOrder? order = null)
        {
            switch (order)
            {
                case SortOrder.Ascending:
                    f.Field(ordername).Ascending();
                    break;
                case SortOrder.Descending:
                    f.Field(ordername).Descending();
                    break;
            }

            return f;
        }

    }
}