using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///
/// Add a new class to your project, name it ViewModel.cs, and add this code to it. This will be your binding source class.
/// * We'll create a view of a sports team hierarchy that is organized into lists for leagues, divisions, and teams, and includes a team details view
///
namespace FirstAppUWP
{
    public class Team
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }

    public class Division
    {
        public string Name { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }

    public class  League
    {
        public string Name { get; set; }
        public IEnumerable <Division> Divisions { get; set; }
    }

    //////////////////////////////////////////////////////////////////
    /// Define Model View
    //////////////////////////////////////////////////////////////////
    public class LeagueList : List<League> {
        /// <summary>
        /// Contrustor
        /// </summary>
        public LeagueList() { 
            AddRange(GetLeagues().ToList());
        }

        #region Method
        public IEnumerable<Team> GetTeams(int x, int y)
        {
            return from z in Enumerable.Range(1, 4)
                   select new Team
                   {
                       Name = string.Format("Team {0}-{1}-{2}", x, y, z),
                       Wins = 25 - (x * y * z),
                       Losses = x * y * z
                   };
        }

        public IEnumerable<Division> GetDivisions(int x)
        {
            return from y in Enumerable.Range(1, 3)
                   select new Division
                   {
                       Name = string.Format("Division {0}-{1}", x, y),
                       Teams = GetTeams(x, y).ToList()
                   };
        }

        public IEnumerable<League> GetLeagues()
        {
            return from x in Enumerable.Range(1, 2)
                   select new League
                   {
                       Name = string.Format("League {0}", x),
                       Divisions = GetDivisions(x)
                   };
        }
        #endregion Method
    }
}
