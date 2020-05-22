using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDCBot6000GUI
{
    ///<remarks> 
    /// Team Class
    /// This class contains getters and setters for the teams that will be simulated
    /// </remarks>
    public class Team
    {
        private string teamName;
        private string teamLeague;
        private int teamStrength;
        private ArrayList teamRoster = new ArrayList();

        public int TeamStrength { get => teamStrength; set => teamStrength = value; }
        public string TeamLeague { get => teamLeague; set => teamLeague = value; }
        public string TeamName { get => teamName; set => teamName = value; }
        public ArrayList TeamRoster { get => teamRoster; set => teamRoster = value; }
    }

    class MatchSimulation
    {
        public static int team1Score, team2Score;
        ///<remarks> 
        /// simulateMatch
        /// Return value: String
        /// Takes 4 parameters, 2 strings for team name and 2 integers for team strength
        /// Calculate the team difference against highest strength team and set winning chance
        /// Generate random outcomes based on said difference and probability
        /// 100% bug free, I swear you won't find a more efficient way to simulate football matches. Trust me, I went to college ;) 
        /// </remarks>
        /// 
        public string simulateMatch(string team1, string team2, int str1, int str2)
        {
            int winChance = 0;
            int drawChance = 0;
            int result = 0;
            int st1;
            int st2;
            double difference = 0;

            if (str1 < str2) { difference = 100 - (((double)str1 / (double)str2) * 100); }
            else { difference = 100 - (((double)str2 / (double)str1) * 100); }

            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            if (difference >= 70 && difference <= 100) { winChance = 95; st1 = rnd.Next(0, 12); st2 = rnd.Next(0, 1); }
            else if (difference >= 50 && difference < 70) { winChance = 75; st1 = rnd.Next(0, 9); st2 = rnd.Next(0, 2); }
            else if (difference >= 30 && difference < 50) { winChance = 70; st1 = rnd.Next(0, 7); st2 = rnd.Next(0, 3); }
            else if (difference >= 10 && difference < 30) { winChance = 55; st1 = rnd.Next(0, 6); st2 = rnd.Next(0, 4); }
            else { winChance = 50; drawChance = rnd.Next(0, 2); st1 = rnd.Next(0, 5); st2 = rnd.Next(0, 5); }

            if (drawChance == 0) { result = rnd.Next(0, 100) < winChance ? 1 : 0; }
            else { result = -1; }

            if (result == 1)
            {

                if (st1 <= st2)
                {
                    if (st1 - 1 == -1)
                    {
                        st1 += 1;
                    }
                    st2 = rnd.Next(0, st1 - 1);
                }

                team1Score = st1;
                team2Score = st2;

                return ($"---Match Simulation---\n{team1} vs. {team2} - {team1} wins! \nScore: {st1} - {st2}");
            }
            else if (result == 0)
            {

                if (st2 <= st1)
                {
                    if (st2 - 1 == -1)
                    {
                        st2 += 1;
                    }
                    st1 = rnd.Next(0, st2 - 1);
                }

                team1Score = st1;
                team2Score = st2;

                return ($"---Match Simulation---\n{team1} vs. {team2} - {team2} wins! \nScore: {st1} - {st2}");
            }
            else
            {
                st2 = st1;
                team1Score = st1;
                team2Score = st2;
                return ($"---Match Simulation---\n{team1} vs. {team2} - Both teams draw! \nScore: {st1} - {st2}");
            }
        }

        ///<remarks> 
        /// loadTeams
        /// Loads team information from csv file
        /// </remarks>
        public void loadTeams()
        {
            List<Team> teamList = new List<Team>();
            ArrayList roster = new ArrayList();
            string[] teamNames = { };
            string[] teamLeagues = { };
            int[] teamStrength = { };

        }


        public string quickSim(int t1, int t2)
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


            caption = newMatch.simulateMatch(teamList[t1].TeamName, teamList[t2].TeamName, teamList[t1].TeamStrength, teamList[t2].TeamStrength);

            string imagePath = generateImage(t1, t2, team1Score, team2Score, teamList[t1].TeamName, teamList[t2].TeamName);

            return Environment.NewLine + $"---Now simulating {teamList[t1].TeamName} v. {teamList[t2].TeamName}---" +
                Environment.NewLine + "\nMatch Result: " + caption + "\nSimulation finished at: " + DateTime.Now.ToString("h:mm:ss:ffff tt\n");

        }


        public string generateImage(int t1index, int t2index, int t1s, int t2s, string name1, string name2)
        {
            string[] teamEmblem = { @"TeamLogos\monarcas.png",
                @"TeamLogos\rmd.png",
                @"TeamLogos\la_fc.png",
                @"TeamLogos\puntarenas.png",
                @"TeamLogos\olimpia.png",
                @"TeamLogos\juventus2.png" };

            string image1 = @"TeamLogos\champ_background.jpg";
            string image2 = teamEmblem[t1index];
            string image3 = teamEmblem[t2index];

            Size standardSize = new Size(200, 262);

            System.Drawing.Image canvas = Bitmap.FromFile(image1);
            Graphics gra = Graphics.FromImage(canvas);

            Bitmap smallImg = new Bitmap(image2);
            Image resultImage = resizeImage(smallImg, standardSize);
            gra.DrawImage(resultImage, new Point(210, 220));

            Bitmap smalling = new Bitmap(image3);
            resultImage = resizeImage(smalling, standardSize);
            gra.DrawImage(resultImage, new Point(850, 220));

            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.DrawString($"{t1s} - {t2s}", new Font("Bahnschrift", 75, FontStyle.Bold), Brushes.White, new PointF(515, 310));
                g.DrawString("DDCBot - test simulation uwu", new Font("Bahnschrift", 20), Brushes.White, new PointF(453, 680));
            }

            canvas.Save($"{name1} v {name2}.png", System.Drawing.Imaging.ImageFormat.Png);

            string fileName = $"{name1} v {name2}.png";

            return fileName;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
    }
}
