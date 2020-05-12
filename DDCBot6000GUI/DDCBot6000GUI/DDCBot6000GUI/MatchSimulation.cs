using System;
using System.Collections;
using System.Collections.Generic;
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
        ///<remarks> 
        /// simulateMatch
        /// Return value: String
        /// Takes 4 parameters, 2 strings for team name and 2 integers for team strength
        /// Calculate the team difference against highest strength team and set winning chance
        /// Generate random outcomes based on said difference and probability
        /// 100% bug free, I swear you won't find a more efficient way to simulate football matches. Trust me, I went to college ;) 
        /// </remarks>
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

                return ($"---Match Simulation---\n{team1} vs. {team2} - {team2} wins! \nScore: {st1} - {st2}");
            }
            else
            {
                st2 = st1;
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
    }
}
