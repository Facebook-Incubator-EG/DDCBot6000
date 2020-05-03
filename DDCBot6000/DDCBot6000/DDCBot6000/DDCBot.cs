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
using System.Threading;

namespace DDCBot6000
{

    public class BotPost
    {
        private const string FB_IMAGE_ADDRESS = "https://graph.facebook.com/v6.0/me/photos";
        private const string FB_BASE_ADDRESS = "https://graph.facebook.com/";
        private const string FB_PAGE_ID = "107789687591192";
        private string fB_ACCESS_TOKEN;

        public string FB_ACCESS_TOKEN { get => fB_ACCESS_TOKEN; set => fB_ACCESS_TOKEN = value; }

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

        public async Task<string> PublishImageAndMessage(string caption, string image)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(FB_IMAGE_ADDRESS);

                var parametters = new Dictionary<string, string>
                {
                    { "access_token", FB_ACCESS_TOKEN },
                    { "message", caption }
                };
                var encodedContent = new FormUrlEncodedContent(parametters);
                var result = await httpClient.PostAsync($"?{image}&caption={caption}&access_token={FB_ACCESS_TOKEN}", encodedContent);
                var msg = result.EnsureSuccessStatusCode();
                return await msg.Content.ReadAsStringAsync();           
            }
        }
    }

    class DDCBot
    {
        static void Main(string[] args)
        {

            string token;
            string imageSource = "";
            string caption = "";

            Console.WriteLine("----DDCBot6000----");
            Console.WriteLine("Welcome!\nEnter FB Access Token: ");
       
            token = Console.ReadLine().Trim();
            BotPost post = new BotPost();
            post.FB_ACCESS_TOKEN = token;

            try
            {
                Task.Run(async () =>
                {
                    await post.PublishImageAndMessage(caption, imageSource);
                }).GetAwaiter().GetResult();         
                Console.WriteLine("DDCBot6000 - Post completed succesfully! uwu");
            }
            catch (Exception)
            {
                Console.WriteLine("An error ocurred, try again or try another token! unu");
            }
           
        }
    }
}