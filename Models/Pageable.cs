namespace TokoShop.WebApp.Models
{
    public class Pageable<T>
    {
        public int DataCount { get; set; }
        public List<T> Items { get; set; } = new List<T>();
    }
}
