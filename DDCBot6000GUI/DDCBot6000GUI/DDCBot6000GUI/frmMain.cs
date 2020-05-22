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

        public static string FB_TOKEN = "";
        public const string APP_TOKEN = "267848907911398|Tcxw4cGfvbLD92wOjfXQRRaAJnk";
        public static string apiResponse = "";
        public static bool simStop = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

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
                rctConsoleOutput.AppendText(Environment.NewLine + "DDCBot6000 - Post completed succesfully! uwu");
            }
            catch (Exception)
            {
                rctConsoleOutput.AppendText(Environment.NewLine + "An error ocurred, try again or try another token! UnU");
            }
        }
 
        private void btnQuickSim_Click(object sender, EventArgs e)
        {
            rctConsoleOutput.Text = "--------------------------------------------";
            //quickMatch();    
            MatchSimulation simulate = new MatchSimulation();

            for(int i = 0; i < 5; i++)
            {
                rctConsoleOutput.AppendText(simulate.quickSim(i, i+1));

            }        
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

        //STILL NEED TO FIX THIS CODE!!!!
        private async Task randSim(string token)
        {
            string caption;
            string imagePath;
            List<Team> teamList = new List<Team>();
            MatchSimulation newMatch = new MatchSimulation();
            ArrayList roster = new ArrayList();

            teamList.Add(new Team() { TeamName = "Monarcas Morelia", TeamLeague = "Liga MX", TeamStrength = 65, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "Real Madrid", TeamLeague = "La Liga", TeamStrength = 92, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "LA FC", TeamLeague = "MLS", TeamStrength = 69, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "Puntarenas FC", TeamLeague = "Liga FPD", TeamStrength = 99, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "C.D. Olimpia", TeamLeague = "LNFPH", TeamStrength = 60, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "Juventus", TeamLeague = "Serie A", TeamStrength = 91, TeamRoster = roster });


            for (int i = 2; i < 5; i++)
            {
                //rctConsoleOutput.AppendText(Environment.NewLine + $"\n---Now simulating {teamList[i].TeamName} v. {teamList[i+1].TeamName}---");
                caption = newMatch.simulateMatch(teamList[i].TeamName, teamList[i + 1].TeamName, teamList[i].TeamStrength, teamList[i + 1].TeamStrength);
                //rctConsoleOutput.AppendText(Environment.NewLine + "Match Result: " + caption);
                //rctConsoleOutput.AppendText(Environment.NewLine + "Attempting to post to Facebook...");

                //postToFbText(token, caption);


                imagePath = newMatch.generateImage(i, i+1, MatchSimulation.team1Score, MatchSimulation.team2Score, teamList[i].TeamName, teamList[i+1].TeamName);

                BotPost newPost = new BotPost();

                newPost.postToFbImage(BotPost.FB_PAGE_ID, token, imagePath, caption);


                string time = DateTime.Now.ToString("h:mm:ss:ffff tt");
        
                rctConsoleOutput.AppendText(Environment.NewLine + $"Match simulation has been posted to Facebook @ {time}. Next simulation will be run in 3 minute(s)...");
                if (i == 5) {break;}
                await Task.Delay(180000);
                if (simStop == true){ rctConsoleOutput.AppendText($"\n\nSimulation Terminated @{DateTime.Now.ToString("h:mm:ss:ff tt")}"); btnRandomSim.Enabled = true;  break;}
            }

            rctConsoleOutput.AppendText(Environment.NewLine + "\n---All simulations completed---");
            btnRandomSim.Enabled = true;
        }

        private void btnSubmitToken_Click(object sender, EventArgs e)
        {
            if (txtAccessToken.Text == "") { rctConsoleOutput.Text = "Token entered is blank! Try again."; return; }
            BotPost validate = new BotPost();
            FB_TOKEN = txtAccessToken.Text.Trim();
            bool validation = validate.validateToken(FB_TOKEN);

            if(validation == true)
            {               
                lblValidToken.Visible = true;
                btnRandomSim.Enabled = true;
                btnStop.Enabled = true;
                btnBeginSims.Enabled = true;
                rctConsoleOutput.Text = $"{apiResponse} \n\n Token Accepted UwU!";
            }
            else
            {
                rctConsoleOutput.Text = $"Token entered is invalid! - Try again.";
                btnRandomSim.Enabled = false;
                btnStop.Enabled = false;
                btnBeginSims.Enabled = false;
            }
            
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

        private void rctConsoleOutput_TextChanged(object sender, EventArgs e)
        {
            rctConsoleOutput.SelectionStart = rctConsoleOutput.Text.Length;
            rctConsoleOutput.ScrollToCaret();
        }
    }
}
