using System.Text.Json.Serialization;

namespace TokoShop.WebApp.Models.Products
{
    public class Meal
    {
        [JsonPropertyName("strMeal")]
        public string StrMeal { get; set; }

        [JsonPropertyName("strMealThumb")]
        public string StrMealThumb { get; set; }

        [JsonPropertyName("idMeal")]
        public string IdMeal { get; set; }
    }

    public class MealRoot
    {
        [JsonPropertyName("meals")]
        public List<Meal> Meals { get; set; }
    }
}
