using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.STMApp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SportsTeamManagementApp.DbAction
{
    public static class CompetitionDbAction
    {
        public static void AddCompetition(CompetitionDomain competition, List<UserDomain> teamPlayers)
        {
            using (var db = new DatabaseContext())
            {
                if (competition != null)
                {
                    var exercisesList = new List<ExerciseDomain>();

                    foreach (var player in teamPlayers)
                    {
                        exercisesList.Add(new ExerciseDomain()
                        {
                            UserId = player.Id, 
                            Score = 0,
                            Date = DateTime.Now,
                        });
                    }


                    db.Competitions.Add(new CompetitionDomain()
                    {
                        Name = competition.Name,
                        Unit = competition.Unit,
                        TeamId = STMAppMainData.LogedUserTeam.Id,
                        Exercises = exercisesList
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
