using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.Models;
using SportsTeamManagementApp.STMApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.DbAction
{
    public static class ExerciseDbAction
    {
        public static ObservableCollection<ExerciseResultModel> GetBestsExerciseResultsObservalbeCollection()
        {
            var finalCollection = new ObservableCollection<ExerciseResultModel>();

            using (var db = new DatabaseContext())
            {
                var helperList = (from e in db.Exercises
                                  join c in db.Competitions on e.CompetitionId equals c.Id
                                  where e.UserId == STMAppMainData.LogedUserId
                                  select new ExerciseResultModel()
                                  {
                                      CompetitionId = c.Id,
                                      Name = c.Name,
                                      Result = Convert.ToDouble(e.Score),
                                      Unit = c.Unit
                                  }).ToList();


                var bestsResults = helperList
                    .OrderByDescending(r => r.Result)
                    .GroupBy(r => r.Name)
                    .Select(r => r.First())
                    .ToList();

                foreach (var result in bestsResults)
                {
                    finalCollection.Add(result);
                }
            }

            return finalCollection;
        }
    }
}
