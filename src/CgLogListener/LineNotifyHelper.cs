using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CgLogListener
{
    public static class LineNotifyHelper
    {
        public static async Task Notify(string token, string message)
        {
            using (var lineHttpClient = new HttpClient())
            {
                lineHttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                var httpContent = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "message", message }
                });

                var p = await lineHttpClient.PostAsync("https://notify-api.line.me/api/notify", httpContent);
                p.EnsureSuccessStatusCode();
            }
        }
    }
}
