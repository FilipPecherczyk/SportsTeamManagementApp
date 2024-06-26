﻿using SportsTeamManagementApp.Entities;
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

        public static IList<ExerciseDomain> GetExerciseListByCompetitionId(int competitionId)
        {
            var finalList = new List<ExerciseDomain>();

            using (var db = new DatabaseContext())
            {
                return db.Exercises.Where(e => e.CompetitionId == competitionId && e.UserId == STMAppMainData.LogedUserId).ToList();
            }
        }

        public static void AddExercise(int score, int competitionId)
        {

            using (var db = new DatabaseContext())
            {
                db.Exercises.Add(new ExerciseDomain()
                {
                    Score = score,
                    Date = DateTime.Now,
                    CompetitionId = competitionId,
                    UserId = STMAppMainData.LogedUserId
                });

                db.SaveChanges();
            }
        }


    }
}
