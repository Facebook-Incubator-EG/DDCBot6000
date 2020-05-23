///<remarks> 
/// -Cesar I. Mendoza (aberuwu)
/// File: frmMain.cs
/// Purpose: Contains event handlers for the GUI interface of the simbot
///          
/// </remarks>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        public delegate void delUpdateTextBox(string text);
        ThreadStart threadStart;
        Thread myUpdateThread;

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
            MatchSimulation simulate = new MatchSimulation();
            rctConsoleOutput.Clear();

            simulate.T1winCount = 0;
            simulate.T2winCount = 0;
            simulate.DrawCount = 0;
            int limit = 1000;

            for(int i = 0; i < limit; i++)
            {
                rctConsoleOutput.AppendText($"\nSimulation #{i+1} "+simulate.quickSim(3, 5));
            }

            rctConsoleOutput.AppendText($"\n----{limit} simulations were run - Results----"+"\nPuntarenas FC win count: "+ simulate.T1winCount.ToString() + "\nJuventus win count: "
                + simulate.T2winCount.ToString() + "\nBoth teams drew: " + simulate.DrawCount.ToString());
        }

        private void btnRandomSim_Click(object sender, EventArgs e)
        {
            btnRandomSim.Enabled = false;
            simStop = false;

            Task.Run(async () =>
            {
                await RandSim(FB_TOKEN);
            });
        }

        public delegate void InvokeDelegate();
        private async Task RandSim(string token)
        {
            string caption;
            string imagePath;
            List<Team> teamList = new List<Team>();
            MatchSimulation newMatch = new MatchSimulation();
            ArrayList roster = new ArrayList();
            delUpdateTextBox dlu = new delUpdateTextBox(updateTextBox);
            BotPost newPost = new BotPost();
            
            teamList.Add(new Team() { TeamName = "Monarcas Morelia", TeamLeague = "Liga MX", TeamStrength = 65, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "Real Madrid", TeamLeague = "La Liga", TeamStrength = 92, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "LA FC", TeamLeague = "MLS", TeamStrength = 69, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "Puntarenas FC", TeamLeague = "Liga FPD", TeamStrength = 99, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "C.D. Olimpia", TeamLeague = "LNFPH", TeamStrength = 60, TeamRoster = roster });
            teamList.Add(new Team() { TeamName = "Juventus", TeamLeague = "Serie A", TeamStrength = 91, TeamRoster = roster });


            for (int i = 0; i < 5; i++)
            {    
                rctConsoleOutput.BeginInvoke(dlu, Environment.NewLine + $"\n---Now simulating {teamList[i].TeamName} v. {teamList[i + 1].TeamName}---");
                rctConsoleOutput.BeginInvoke(dlu, Environment.NewLine + $"\n---Now simulating {teamList[i].TeamName} v. {teamList[i + 1].TeamName}---");
                caption = newMatch.simulateMatch(teamList[i].TeamName, teamList[i + 1].TeamName, teamList[i].TeamStrength, teamList[i + 1].TeamStrength);
                rctConsoleOutput.BeginInvoke(dlu, Environment.NewLine + "Match Result: " + caption);
                rctConsoleOutput.BeginInvoke(dlu, Environment.NewLine + "Attempting to post to Facebook...");

                //postToFbText(token, caption);
                
                imagePath = newMatch.generateImage(i, i + 1, MatchSimulation.team1Score, MatchSimulation.team2Score, teamList[i].TeamName, teamList[i + 1].TeamName);
                imagePath = newMatch.generateImage(i, i + 1, MatchSimulation.team1Score, MatchSimulation.team2Score, teamList[i].TeamName, teamList[i + 1].TeamName);
                newPost.postToFbImage(BotPost.FB_PAGE_ID, token, imagePath, caption);
                          
                string time = DateTime.Now.ToString("h:mm:ss:ffff tt");

                rctConsoleOutput.BeginInvoke(dlu, Environment.NewLine + $"Match simulation has been posted to Facebook @ {time}. Next simulation will be run in 5 minute(s)...");

                if (i == 5) { break; }

                Stopwatch timer = new Stopwatch();
                timer.Start();
                while (timer.Elapsed.TotalSeconds < 300){}
                timer.Stop();

                //await Task.Delay(10000);

                if (simStop == true) { rctConsoleOutput.BeginInvoke(dlu, $"\n\nSimulation Terminated @{DateTime.Now.ToString("h:mm:ss:ff tt")}"); btnRandomSim.Enabled = true; break; }
            }

            rctConsoleOutput.BeginInvoke(dlu, Environment.NewLine + "\n---All simulations completed---");
            btnRandomSim.Enabled = true;
        }


        public void updateTextBox(string txt)
        {
            this.rctConsoleOutput.AppendText(txt);
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
