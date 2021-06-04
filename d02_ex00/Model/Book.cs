using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace d02_ex00.Model
{
    public class Book : ISearchable
    {
        public string MediaType
        {
            get => "book";
        }
        public string Title
        {
            get => BookDetails[0].Title;
            set { }
        }
        public string Author()
        {
            return BookDetails[0].Author;
        }
        
        [JsonPropertyName("rank")]
        public int Rank { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        
        [JsonPropertyName("book_details")]
        public List<BookDetail> BookDetails { get; set; }

        public string SummaryShort()
        {
            return BookDetails[0].SummaryShort;
        }
        
        [JsonPropertyName("amazon_product_url")]
        public string Url { get; set; }

        
        public class BookDetail
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }
            [JsonPropertyName("author")]
            public string Author { get; set; }
            [JsonPropertyName("description")]
            public string SummaryShort { get; set; }
        }
        
        public override string ToString()
        {
            return ($"- {Title.ToUpper()} by {Author()} [{Rank} on NYT's {LastName}]\n{SummaryShort()}\n{Url}");
        }
    }
}