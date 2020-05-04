///<remarks> 
/// -Cesar I. Mendoza (aberuwu)
/// File: MatchSimulation.cs
/// Purpose: Contains classes and methods for the simulation of matches
///          
/// </remarks>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDCBot6000
{
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

        public string simulateMatch(string team1, string team2, int str1, int str2)
        {
            var winChance = 0;
            if (str1 < str2)
            {
                double difference = 100-(((double)str1 / (double)str2) * 100);

                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                
                if (difference >= 70 && difference <= 100)   {winChance = 95;}
                else if(difference >= 50 && difference < 70) {winChance = 75;}
                else if(difference >= 30 && difference < 50) {winChance = 70;}
                else if(difference >= 10 && difference < 30) {winChance = 55;}
                else{winChance = 50;}
             
                int result = rnd.Next(0, 100) < winChance ? 1 : 0;

                if (result == 1) { return ($"---Match Simulation---\n{team1} vs. {team2} - {team1} wins!"); }
                else { return($"---Match Simulation---\n{team1} vs. {team2} - {team2} wins!"); }
            }
            else
            {
                double difference = 100 - (((double)str2 / (double)str1) * 100);

                Random rnd = new Random(Guid.NewGuid().GetHashCode());

                if (difference >= 70 && difference <= 100)    {winChance = 95;}
                else if (difference >= 50 && difference < 70) {winChance = 75;}
                else if (difference >= 30 && difference < 50) {winChance = 70;}
                else if (difference >= 10 && difference < 30) {winChance = 55;}
                else{ winChance = 50;}

                int result = rnd.Next(0, 100) < winChance ? 1 : 0;

                if (result == 1) {return($"---Match Simulation---\n{team1} vs. {team2} - {team1} wins!");}
                else {return($"---Match Simulation---\n{team1} vs. {team2} - {team2} wins!");}
            }
        }      
    }
}
