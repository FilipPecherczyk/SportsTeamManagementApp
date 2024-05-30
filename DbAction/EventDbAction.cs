using Microsoft.VisualBasic.Logging;
using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.STMApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.DbAction
{
    public static class EventDbAction
    {
        public static void AddEvent(EventDomain eventModel)
        {
            using (var db = new DatabaseContext())
            {
                db.Events.Add(new EventDomain
                {
                    TeamId = STMAppMainData.LogedUserTeam.Id,
                    Date = eventModel.Date,
                    Time = eventModel.Time,
                    Title = eventModel.Title,
                });
                db.SaveChanges();
            }
        }

        public static void AddEventWithGame(EventDomain eventDomain, GameDomain gameModel)
        {
            using (var db = new DatabaseContext())
            {
                var game = new GameDomain()
                {
                    Opponent = gameModel.Opponent,
                    IsHomeGame = gameModel.IsHomeGame,
                };

                var eventModel = new EventDomain
                {
                    TeamId = STMAppMainData.LogedUserTeam.Id,
                    Date = eventDomain.Date,
                    Time = eventDomain.Time,
                    Title = eventDomain.Title,
                    Games = new List<GameDomain> { game }
                };

                db.Events.Add(eventModel);

                db.SaveChanges();
            }
        }

        public static EventDomain GetEventById(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Events.FirstOrDefault(e => e.Id == id);
            }
        }

        public static int GetEventIdByProperties(EventDomain model)
        {
            using (var db = new DatabaseContext())
            {
                var finalModel = db.Events.Where(e => e.TeamId == STMAppMainData.LogedUserTeam.Id)
                        .OrderByDescending(e => e.Id)
                        .FirstOrDefault(e => e.Title == model.Title && e.Time == model.Time && e.Date == model.Date);
                       

                if (finalModel is null) return 0 ; else return finalModel.Id;
            }
        }

    }
}
