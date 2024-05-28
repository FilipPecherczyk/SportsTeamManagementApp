using Microsoft.VisualBasic.Logging;
using SportsTeamManagementApp.Entities;
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
                    Date = eventModel.Date,
                    Time = eventModel.Time,
                    Title = eventModel.Title,
                });
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


    }
}
