using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace CatsMVC.Models
{
    public class ResultsViewModel<TResult>
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        // Sets to next page whatever its called in the api
        [JsonPropertyName("next_page_url")]
        public string Next { get; set; }
        [JsonPropertyName("prev_page_url")]
        public string Previous { get; set;}

// gets list of data in api
        [JsonPropertyName("data")]
        public IEnumerable<TResult> Data { get; set; }

        public string NextPageNum => Next?.Split("?page=").LastOrDefault();
        public string PreviousPageNum => Previous?.Split("?page=").LastOrDefault();
    }
}