using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.STMApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.DbAction
{
    public static class GameDbActions
    {

        public static GameDomain GetNextGame(DateTime date, TimeSpan hour)
        {
            using (var db = new DatabaseContext())
            {
                var game = (from evt in db.Events
                           join g in db.Games on evt.Id equals g.EventId
                           where evt.TeamId == STMAppMainData.LogedUserTeam.Id 
                                 && evt.Date > date
                           orderby evt.Date
                           select new GameDomain()
                           {
                               Id = g.Id,
                               Opponent = g.Opponent,
                               IsHomeGame = g.IsHomeGame,
                               TeamScore = g.TeamScore,
                               OpponentScore = g.OpponentScore,
                               EventId = g.EventId,
                               Event = new EventDomain
                               {
                                   Id = evt.Id,
                                   Date = evt.Date,
                                   Time = evt.Time,
                                   Title = evt.Title,
                                   TeamId = evt.TeamId
                               }
                           }).ToList();

                return game.OrderBy(g => g.Event.Time).FirstOrDefault(g => TimeSpan.Parse(g.Event.Time) > hour);
            }
        }

        public static GameDomain GetPreviousGame(DateTime date, TimeSpan hour)
        {
            using (var db = new DatabaseContext())
            {
                var games = (from evt in db.Events
                            join g in db.Games on evt.Id equals g.EventId
                            where evt.TeamId == STMAppMainData.LogedUserTeam.Id
                                  && evt.Date <= date
                            orderby evt.Date descending
                            select new GameDomain()
                            {
                                Id = g.Id,
                                Opponent = g.Opponent,
                                IsHomeGame = g.IsHomeGame,
                                TeamScore = g.TeamScore,
                                OpponentScore = g.OpponentScore,
                                EventId = g.EventId,
                                Event = new EventDomain
                                {
                                    Id = evt.Id,
                                    Date = evt.Date,
                                    Time = evt.Time,
                                    Title = evt.Title,
                                    TeamId = evt.TeamId
                                }
                            }).ToList();

                var finalModel = new GameDomain();

                // Today
                var todayGames = games.Where(g => g.Event.Date == date);
                var firstPlayedToday = todayGames.OrderBy(g => g.Event.Time).FirstOrDefault(g => TimeSpan.Parse(g.Event.Time) < hour);

                if (firstPlayedToday != null) return firstPlayedToday;

                // Not today 
                var pastGames = games.Where(g => g.Event.Date < date);
                return pastGames.FirstOrDefault();
            }
        }
    }
}
