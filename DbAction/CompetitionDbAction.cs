using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.STMApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.DbAction
{
    public class CompetitionDbAction
    {
        public static void AddCompetition(CompetitionDomain competition)
        {
            using (var db = new DatabaseContext())
            {
                if (competition != null)
                {
                    db.Competitions.Add(new CompetitionDomain()
                    {
                        Name = competition.Name,
                        Unit = competition.Unit,
                        TeamId = STMAppMainData.LogedUserTeam.Id
                    });

                    db.SaveChanges();
                }
            }
        }

        public static IList<CompetitionDomain> GetCompetitionList()
        {
            using (var db = new DatabaseContext())
            {
                return db.Competitions.Where(c => c.TeamId == STMAppMainData.LogedUserTeam.Id).ToList(); 
            }
        }

    }
}
