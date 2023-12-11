using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2
{

    public class Datum
    {
        [JsonProperty("competition", NullValueHandling = NullValueHandling.Ignore)]
        public string Competition { get; set; }

        [JsonProperty("year", NullValueHandling = NullValueHandling.Ignore)]
        public int Year { get; set; }

        [JsonProperty("round", NullValueHandling = NullValueHandling.Ignore)]
        public string Round { get; set; }

        [JsonProperty("team1", NullValueHandling = NullValueHandling.Ignore)]
        public string Team1 { get; set; }

        [JsonProperty("team2", NullValueHandling = NullValueHandling.Ignore)]
        public string Team2 { get; set; }

        [JsonProperty("team1goals", NullValueHandling = NullValueHandling.Ignore)]
        public string Team1goals { get; set; }

        [JsonProperty("team2goals", NullValueHandling = NullValueHandling.Ignore)]
        public string Team2goals { get; set; }
    }

    public class Root
    {
        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public int Page { get; set; }

        [JsonProperty("per_page", NullValueHandling = NullValueHandling.Ignore)]
        public int PerPage { get; set; }

        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public int Total { get; set; }

        [JsonProperty("total_pages", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalPages { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<Datum> Data { get; set; }
    }

}
