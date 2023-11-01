using System.Text.Json.Serialization;

namespace TokoShop.WebApp.Models.Products
{
    public class ProductListModel
    {
        [JsonPropertyName("group")]
        public string? Group { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("small")]
        public string? Sign { get; set; }

        [JsonPropertyName("molar")]
        public double Molar { get; set; }

        [JsonPropertyName("electrons")]
        public List<int>? Electrons { get; set; }
    }
}
