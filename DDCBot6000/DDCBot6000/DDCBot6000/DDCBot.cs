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

            //Console.WriteLine("\n---Now simulating Monarcas v. LA FC Matches---");
            //Console.WriteLine("Difference = 0.05 - Probability: 50% per team\n");

            //newMatch.simulateMatch(teamList[0].TeamName, teamList[2].TeamName, teamList[0].TeamStrength, teamList[2].TeamStrength);

            //for (int i = 0; i < 10; i++)
            //{
            //    newMatch.simulateMatch(teamList[0].TeamName, teamList[2].TeamName, teamList[0].TeamStrength, teamList[2].TeamStrength);
            //}

            Console.WriteLine("\n---Now simulating C.D. Olimpia v. Real Madrid Matches---");
            Console.WriteLine("Difference = 0.71 - Probability: 85% Real Madrid - 15% C.D. Olimpia\n");

            string post = newMatch.simulateMatch(teamList[1].TeamName, teamList[4].TeamName, teamList[1].TeamStrength, teamList[4].TeamStrength);


            //for (int i = 0; i < 10; i++)
            //{
            //    newMatch.simulateMatch(teamList[1].TeamName, teamList[4].TeamName, teamList[1].TeamStrength, teamList[4].TeamStrength);
            //}


            DDCBot send = new DDCBot();
            send.postToFbText(token, post);

            Console.WriteLine("\nMatch simulation has been posted!");

            //Console.WriteLine("\n----Now Listing All Teams----\n");
            //foreach(Team value in teamList)
            //{
            //    Console.WriteLine("Name: "+value.TeamName);
            //    Console.WriteLine("League: "+value.TeamLeague);
            //    Console.WriteLine("Strength: " + value.TeamStrength + "\n");

            //    //Console.WriteLine("----Team Roster---");
            //    //foreach(string item in value.TeamRoster)
            //    //{
            //    //    Console.WriteLine("-"+ item + "\n");
            //    //}
            //}
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
                Console.WriteLine("An error ocurred, try again or try another token! unu");
            }
        }


        void postToFbImage(string token, string caption, string imageSource)
        {
            try
            {
                BotPost post = new BotPost();
                post.FB_ACCESS_TOKEN = token;
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