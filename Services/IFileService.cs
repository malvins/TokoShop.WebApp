namespace TokoShop.WebApp.Services
{
    public interface IFileService
    {
        Task<object> SaveAsAsync(string fileName, byte[] data);
        string CreateCSVString<T>(List<T> list);
    }
}
