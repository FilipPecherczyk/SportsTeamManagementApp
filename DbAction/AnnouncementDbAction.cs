using SportsTeamManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D.Converters;

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

        public static void AddAnnoucement(string text, int teamId)
        {
            using (var db = new DatabaseContext())
            {
                db.Announcements.Add(new AnnouncementDomain()
                {
                    Text = text,
                    TeamId = teamId,
                });

                db.SaveChanges();                
            }
        }
    }
}
