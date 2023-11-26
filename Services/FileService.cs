using Microsoft.JSInterop;
using System.Text;

namespace TokoShop.WebApp.Services
{
    public class FileService : IFileService
    {
        private IJSRuntime _jsRuntime;

        public FileService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public string CreateCSVString<T>(List<T> list)
        {
            StringBuilder csv = new StringBuilder();

            // Create header
            var header = string.Join(",", typeof(T).GetProperties().Select(f => f.Name).ToArray());
            csv.AppendLine(header);

            // Create rows
            foreach (var item in list)
            {
                var row = string.Join(",", typeof(T).GetProperties().Select(f => $"\"{f.GetValue(item)}\""));
                csv.AppendLine(row);
            }

            return csv.ToString();
        }

        public async Task<object> SaveAsAsync(string fileName, byte[] data)
        {
            return await _jsRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(data));
        }
    }
}
