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
using System.Collections;



namespace DDCBot6000
{
    ///<remarks> 
    /// BotPost
    /// This class contains methods for "manually" posting to facebook using the endpoint        
    /// </remarks>
    public class BotPost
    {
        private const string FB_IMAGE_ADDRESS = "https://graph.facebook.com/v6.0/me/photos";
        private const string FB_BASE_ADDRESS = "https://graph.facebook.com/";
        public const string FB_PAGE_ID = "107789687591192";
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
            FacebookClient api = new FacebookClient();
        
            string token;
            string caption = "";
            string path = @"C:\Users\Scooby2\Desktop\mon_real.jpg";

            Console.WriteLine(
                "----------------DDCBot6000---------------- " + 
                "\nProgrammed by: Cesar I. Mendoza (aberuwu) " +
                "\nVersion: 1.0" +
                "\n------------------------------------------" +
                "\nWelcome! Bienvenido! Wilkomen! Yokoso! \nSimulate football match -> Post to Facebook -> Done! " +
                "\n\nEnter FB Access Token: "
                );

            token = Console.ReadLine().Trim();
          
            DDCBot sim = new DDCBot();
            sim.quickMatch();
            List<Team> teamList = new List<Team>();
            MatchSimulation newMatch = new MatchSimulation();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\n---Now simulating {teamList[i].TeamName} v. {teamList[i + 1].TeamName}---");
                caption = newMatch.simulateMatch(teamList[i].TeamName, teamList[i + 1].TeamName, teamList[i].TeamStrength, teamList[i + 1].TeamStrength);

                Console.WriteLine("\nMatch Result: " + caption);

                Console.WriteLine("\nAttempting to post to Facebook...");

                if (i == 0)
                {
                    DDCBot send = new DDCBot();
                    send.postToFbImage(BotPost.FB_PAGE_ID, token, path, caption);
                }
                else
                {
                    DDCBot send = new DDCBot();
                    send.postToFbText(token, caption);
                }

                string time = DateTime.Now.ToString("t");

                Console.WriteLine($"\nMatch simulation has been posted to Facebook @ {time}. Next simulation will be run in 5 minutes...");
                Thread.Sleep(300000);
            }

        }


        void quickMatch()
        {
            string caption = "";
            List<Team> teamList = new List<Team>();
            ArrayList roster = new ArrayList();

            roster.Add("Carlos Felipe Rodriguez");

            teamList.Add(new Team() { TeamName = "Monarcas Morelia", TeamLeague = "Liga MX", TeamStrength = 65, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "Real Madrid", TeamLeague = "La Liga", TeamStrength = 92, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "LA FC", TeamLeague = "MLS", TeamStrength = 69, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "Puntarenas FC", TeamLeague = "Liga FPD", TeamStrength = 99, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "C.D. Olimpia", TeamLeague = "LNFPH", TeamStrength = 60, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "Juventus", TeamLeague = "Serie A", TeamStrength = 91, TeamRoster = roster });

            MatchSimulation newMatch = new MatchSimulation();
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"\n---Now simulating {teamList[0].TeamName} v. {teamList[2].TeamName}---");
                caption = newMatch.simulateMatch(teamList[0].TeamName, teamList[2].TeamName, teamList[0].TeamStrength, teamList[2].TeamStrength);
                Console.WriteLine("\nMatch Result: " + caption + "\nSimulation finished at: " + DateTime.Now.ToString("h:mm:ss:ffff tt"));
            }
        }


        void postToFbText(string token, string caption)
        {
            try
            {
                BotPost post = new BotPost();
                post.FB_ACCESS_TOKEN = token;
                Task.Run(async () =>
                {
                    await post.PublishMessage(caption);
                }).GetAwaiter().GetResult();
                Console.WriteLine("DDCBot6000 - Post completed succesfully! uwu");
            }
            catch (Exception)
            {
                Console.WriteLine("\nAn error ocurred, try again or try another token! UnU");
            }
        }

        public string postToFbImage(string id, string accessToken, string filePath, string caption)
        {
            var mediaObject = new FacebookMediaObject
            {
                FileName = System.IO.Path.GetFileName(filePath),
                ContentType = "image/jpeg"
            };

            mediaObject.SetValue(System.IO.File.ReadAllBytes(filePath));

            try
            {
                var fb = new FacebookClient(accessToken);

                var result = (IDictionary<string, object>)fb.Post(id + "/photos", new Dictionary<string, object>
                                   {
                                       { "source", mediaObject },
                                       { "message", caption }
                                   });

                var postId = (string)result["id"];

                Console.WriteLine("DDCBot6000 - Post completed succesfully! uwu");
                return postId;
            }
            catch (FacebookApiException ex)
            {
                Console.WriteLine("\nAn error ocurred, try again or try another token! UnU " +
                    "\n\n-------------Facebook Exception Details-------------");
                throw;
            }
        }       
    }
}