using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;

namespace DDCBot6000GUI
{
    public partial class frmMain : Form
    {

        public string FB_TOKEN = "";
        public bool simStop = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }


        void quickMatch()
        {
            string caption = "";
            List<Team> teamList = new List<Team>();
            ArrayList roster = new ArrayList();

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
                rctConsoleOutput.AppendText(Environment.NewLine + $"---Now simulating {teamList[0].TeamName} v. {teamList[2].TeamName}---");
                caption = newMatch.simulateMatch(teamList[0].TeamName, teamList[2].TeamName, teamList[0].TeamStrength, teamList[2].TeamStrength);
                Console.WriteLine("\nMatch Result: " + caption + "\nSimulation finished at: " + DateTime.Now.ToString("h:mm:ss:ffff tt"));           
                rctConsoleOutput.AppendText(Environment.NewLine + "\nMatch Result: " + caption + "\nSimulation finished at: " + DateTime.Now.ToString("h:mm:ss:ffff tt\n"));
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
                //Console.WriteLine("DDCBot6000 - Post completed succesfully! uwu");
                rctConsoleOutput.AppendText(Environment.NewLine + "DDCBot6000 - Post completed succesfully! uwu");
            }
            catch (Exception)
            {
                //Console.WriteLine("\nAn error ocurred, try again or try another token! UnU");
                rctConsoleOutput.AppendText(Environment.NewLine + "An error ocurred, try again or try another token! UnU");
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

                //Console.WriteLine("DDCBot6000 - Post completed succesfully! uwu");
                rctConsoleOutput.AppendText(Environment.NewLine + "DDCBot600 - Post completed succesfully! uwu");
                return postId;
            }
            catch (FacebookApiException ex)
            {
                //Console.WriteLine("\nAn error ocurred, try again or try another token! UnU " +
                //    "\n\n-------------Facebook Exception Details-------------");
                rctConsoleOutput.AppendText(Environment.NewLine + "\nAn error ocurred, try again or try another token! UnU " +
                    "\n\n-------------Facebook Exception Details-------------");
                throw;
                
            }
        }

        private void btnQuickSim_Click(object sender, EventArgs e)
        {
            rctConsoleOutput.Text = "--------------------------------------------";
            quickMatch();         
        }

        private void btnRandomSim_Click(object sender, EventArgs e)
        {
            btnRandomSim.Enabled = false;
            simStop = false;
            Task.Run(async () =>
            {
                await randSim(FB_TOKEN);
            });
        }

        private async Task randSim(string token)
        {
            string caption;
            List<Team> teamList = new List<Team>();
            MatchSimulation newMatch = new MatchSimulation();
            ArrayList roster = new ArrayList();

            teamList.Add(new Team() { TeamName = "Monarcas Morelia", TeamLeague = "Liga MX", TeamStrength = 65, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "Real Madrid", TeamLeague = "La Liga", TeamStrength = 92, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "LA FC", TeamLeague = "MLS", TeamStrength = 69, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "Puntarenas FC", TeamLeague = "Liga FPD", TeamStrength = 99, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "C.D. Olimpia", TeamLeague = "LNFPH", TeamStrength = 60, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "Juventus", TeamLeague = "Serie A", TeamStrength = 91, TeamRoster = roster });


            for (int i = 2; i < 3; i++)
            {
                rctConsoleOutput.AppendText(Environment.NewLine + $"\n---Now simulating {teamList[i].TeamName} v. {teamList[i+1].TeamName}---");

                caption = newMatch.simulateMatch(teamList[i].TeamName, teamList[i + 1].TeamName, teamList[i].TeamStrength, teamList[i + 1].TeamStrength);

                rctConsoleOutput.AppendText(Environment.NewLine + "Match Result: " + caption);

                rctConsoleOutput.AppendText(Environment.NewLine + "Attempting to post to Facebook...");


                postToFbText(token, caption);

                //if (i == 0)
                //{
                //    postToFbImage(BotPost.FB_PAGE_ID, token, path, caption);
                //}
                //else
                //{
                //    postToFbText(token, caption);
                //}

                string time = DateTime.Now.ToString("h:mm:ss:ffff tt");
        
                rctConsoleOutput.AppendText(Environment.NewLine + $"Match simulation has been posted to Facebook @ {time}. Next simulation will be run in 1 minutes...");
                if (i == 5) {break;}
                await Task.Delay(60000);
                if (simStop == true){ rctConsoleOutput.AppendText($"\n\nSimulation Terminated @{DateTime.Now.ToString("h:mm:ss:ff tt")}"); btnRandomSim.Enabled = true;  break;}
            }

            rctConsoleOutput.AppendText(Environment.NewLine + "\n---All simulations completed---");
            btnRandomSim.Enabled = true;
        }

        private void btnSubmitToken_Click(object sender, EventArgs e)
        {
            FB_TOKEN = txtAccessToken.Text.Trim();
            lblValidToken.Visible = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            simStop = true;
            rctConsoleOutput.AppendText("\n\n---Simulation Termination Notice---\nAll simulations will be terminated at the end of the next cycle.");
        }

        private void llbaberuwu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.github.com/aberuwu");
        }
    }
}
