using System.Text.Json.Serialization;

namespace d02_ex00.Model
{
    public class Movie : ISearchable
    {
        public string MediaType
        {
            get => "movie";
        }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("critics_pick")]
        public int IsCriticsPick { get; set; }
        [JsonPropertyName("summary_short")]
        public string SummaryShort { get; set; }
        [JsonPropertyName("link")]
        public MovieLink Link{ get; set; }
        public string Url()
        {
            return Link.Url;
        }

        public class MovieLink
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }
        }
        
        public override string ToString()
        {
            var checkCriticPick = IsCriticsPick == 1 ? "[NYT critic’s pick]" : "";
            return ($"- {Title.ToUpper()} {checkCriticPick}\n{SummaryShort}\n{Url()}");
        }
        
        
    }
}
