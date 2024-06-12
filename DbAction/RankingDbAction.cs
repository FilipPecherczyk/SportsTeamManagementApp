using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.DbAction
{
    public static class RankingDbAction
    {
        public static ObservableCollection<RankingModel> GetExerciseRankingObservalbeCollection(string competitionName, DateTime searchDate)
        {
            var finalCollection = new ObservableCollection<RankingModel>();

            using(var db = new DatabaseContext())
            {
                var helperList = (from u in db.Users
                                  join e in db.Exercises on u.Id equals e.UserId
                                  where u.TeamId == STMApp.STMAppMainData.LogedUserTeam.Id
                                      && e.Competition.Name == competitionName
                                      && e.Date <= searchDate
                                  select new RankingModel()
                                  {
                                      Name = $"{u.Name} {u.LastName}",
                                      Score = e.Score,
                                      Date = e.Date.ToString("dd.MM.yyyy")
                                  }).ToList();

                var bestResults = helperList
                    .OrderByDescending(x => x.Score)
                    .ThenByDescending(x => x.Date)
                    .GroupBy(x => x.Name)
                    .Select(g => g.First())
                    .ToList();

                foreach (var item in bestResults)
                {
                    finalCollection.Add(item);
                }

            }

            return finalCollection;
        }
    }
}
