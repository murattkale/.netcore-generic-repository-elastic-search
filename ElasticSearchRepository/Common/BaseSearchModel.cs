using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticSearchRepository
{
    public class BaseSearchModel
    {
        public int Size { get; set; }
        public int From { get; set; }
        public Dictionary<string, string> Fields { get; set; }
        public string orderProp { get; set; }
        public SortOrder order { get; set; }
        public NumericRangeQuery _NumericRangeQuery { get; set; }
    }
}
