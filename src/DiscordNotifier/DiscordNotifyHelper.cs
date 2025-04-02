using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiscordNotifier
{
    public static class DiscordNotifyHelper
    {
        public static async Task Notify(string webhookUrl, string message)
        {
            try
            {
                var payload = new
                {
                    content = message,
                    username = "CgLogListener",
                };
                
                var httpClient = new HttpClient();

                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(webhookUrl, content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Discord通知送信エラー: {ex.Message}");
            }
        }
    }
}