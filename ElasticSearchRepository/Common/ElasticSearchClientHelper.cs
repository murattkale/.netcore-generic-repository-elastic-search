﻿
using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearchRepository
{
    public static class ElasticSearchClientHelper
    {
        public static ElasticClient CreateElasticClient(string _cn)
        {
            var node = new SingleNodeConnectionPool(new Uri(_cn));
            var settings = new ConnectionSettings(node);
            return new ElasticClient(settings);
        }

        public static void CheckIndex<T>(ElasticClient client, string indexName) where T : class
        {
            var response = client.IndexExists(indexName);
            if (!response.Exists)
            {
                client.CreateIndex(indexName, index =>
                   index.Mappings(ms =>
                       ms.Map<T>(x => x.AutoMap())));
            }
        }


    }
}
