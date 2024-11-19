using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TelegramNotifier
{
    public static class TelegramNotifyHelper
    {
        public static async Task Notify(string token, string chatId, string message)
        {
            using (var client = new HttpClient())
            {
                var httpContent = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "message", message }
                });

                var p = await client.PostAsync($"https://api.telegram.org/bot{token}/sendMessage?chat_id={chatId}&text={message}", httpContent);
                p.EnsureSuccessStatusCode();
            }
        }
    }
}
