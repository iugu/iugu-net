using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iugu.net.Filters
{
    public interface IQueryStringFilter
    {
        string ToQueryStringUrl();
    }

    public class QueryStringFilter : IQueryStringFilter
    {
        private string currentFilter = string.Empty;

        private readonly Dictionary<ResultOrderType, string> SortResult = new Dictionary<ResultOrderType, string>
        {
            [ResultOrderType.Ascending] = "asc",
            [ResultOrderType.Descending] = "desc",
        };


        private readonly Dictionary<FieldSort, string> FieldsWithSort = new Dictionary<FieldSort, string>
        {
            [FieldSort.Id] = "id",
            [FieldSort.Status] = "status",
            [FieldSort.CreateAt] = "created_at",
            [FieldSort.UpdateAt] = "updated_at",
            [FieldSort.Amount] = "amount",
            [FieldSort.AccountName] = "account_name",
        };

        private readonly Dictionary<string, string> FilterParams = new Dictionary<string, string>
        {
            [nameof(MaxResults)] = "limit={0}",
            [nameof(Start)] = "start={0}",
            [nameof(Since)] = "updated_since={0}",
            [nameof(SortBy)] = "sortBy[{0}]={1}"
        };

        private int? maxResults;
        [JsonProperty("limit")]
        public int? MaxResults
        {
            get { return maxResults; }
            set
            {
                maxResults = value;
                if (value.HasValue)
                {
                    AppendFilter(nameof(MaxResults), value.Value);
                }
            }
        }

        private int? start;
        [JsonProperty("start")]
        public int? Start
        {
            get { return start; }
            set
            {
                start = value;

                if (value.HasValue)
                {
                    AppendFilter(nameof(Start), value.Value);
                }
            }
        }

        private DateTime? since;
        [JsonProperty("updated_since")]
        public DateTime? Since
        {
            get { return since; }
            set
            {
                since = value;

                if (value.HasValue)
                {
                    AppendFilter(nameof(Since), value.Value.ToString("o"));
                }
            }
        }

        private OrderingFilter sortBy;
        [JsonProperty("sortBy")]
        public OrderingFilter SortBy
        {
            get { return sortBy; }
            set
            {
                sortBy = value;
                AppendFilter(nameof(SortBy), FieldsWithSort[value.FieldSort], SortResult[value.Order]);
            }
        }

        public string ToQueryStringUrl()
        {
            if (!string.IsNullOrEmpty(currentFilter))
                return $"?{currentFilter}";

            return string.Empty;
        }

        private void AppendFilter(string propertyName, params object[] args)
        {
            if (args != null && args.Any())
            {
                var queryString = string.Format(FilterParams[propertyName], args);

                if (!string.IsNullOrEmpty(currentFilter))
                    currentFilter = string.Join("&", new string[] { currentFilter, queryString });
                else
                    currentFilter = queryString;
            }
        }
    }

    public class OrderingFilter
    {
        public readonly FieldSort FieldSort;
        public readonly ResultOrderType Order;

        public OrderingFilter(FieldSort sortBy, ResultOrderType orderBy)
        {
            FieldSort = sortBy;
            Order = orderBy;
        }
    }
}
