///<remarks> 
/// -Cesar I. Mendoza (aberuwu)
/// File: DDCBot.cs
/// Purpose: Simulate international football matches and post them to Debates de Concacaf on Facebook
///          
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Facebook;

namespace DDCBot6000
{

    public class BotPost
    {
        public const string FB_IMAGE_ADDRESS = "https://graph.facebook.com/v6.0/me/photos";
        public const string FB_BASE_ADDRESS = "https://graph.facebook.com/";
        public string FB_PAGE_ID = "159341114128414";
        public string FB_ACCESS_TOKEN = "EAADzm28CcOYBAAebJI11c5cCNzaAYgZCb5L82qlw2zPZCskTGzCToCdU63UgJZBNhAom1xp9buHj9oiu3AZA9cT49WZCK18N5WZCmOWwBV1LWoOYOC1kbfZA0775RyT73ej6k1cOl3gGuSQrZBPB1tZAfZCBBuBcnzoI0XV8els9XOHwZDZD";
        public async Task<string> PublishMessage(string message)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(FB_BASE_ADDRESS);

                var parametters = new Dictionary<string, string>
                {
                    { "access_token", FB_ACCESS_TOKEN },
                    { "message", message }
                };
                var encodedContent = new FormUrlEncodedContent(parametters);
                var result = await httpClient.PostAsync($"{FB_PAGE_ID}/feed", encodedContent);
                var msg = result.EnsureSuccessStatusCode();
                return await msg.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> PublishImageAndMessage(string caption)
        {
            string picture = "url=https://manga.tokyo/wp-content/uploads/2018/06/5b10cdc11f264.jpg";

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(FB_IMAGE_ADDRESS);

                var parametters = new Dictionary<string, string>
                {
                    { "access_token", FB_ACCESS_TOKEN },
                    { "message", caption }
                };
                var encodedContent = new FormUrlEncodedContent(parametters);
                var result = await httpClient.PostAsync($"?{picture}&caption={caption}&access_token={FB_ACCESS_TOKEN}", encodedContent);
                var msg = result.EnsureSuccessStatusCode();
                return await msg.Content.ReadAsStringAsync();           
            }
        }

    }


    class DDCBot
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                BotPost post = new BotPost();
                await post.PublishImageAndMessage("Nice");
            }).GetAwaiter().GetResult();
            Console.WriteLine("DDCBot6000 - Post completed succesfully!");
        }
    }
}