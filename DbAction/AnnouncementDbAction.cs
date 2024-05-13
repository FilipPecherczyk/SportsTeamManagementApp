using SportsTeamManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.DbAction
{
    public static class AnnouncementDbAction
    {
        public static AnnouncementDomain GetLatestAnnoucementByTeamId(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Announcements.Where(a => a.TeamId == id).OrderByDescending(a => a.Id).FirstOrDefault();
            }
        }
    }
}
