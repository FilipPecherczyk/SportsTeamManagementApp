using SportsTeamManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.DbAction
{
    public static class TeamDbAction
    {
        public static TeamDomain GetTeamById(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Teams.FirstOrDefault(u => u.Id == id);
            }
        }

        public static IList<UserDomain> GetTeamUsersByTeamId(int id, bool onlyPlayers = false)
        {
            using (var db = new DatabaseContext())
            {
                return db.Users.Where(u => u.TeamId == id).ToList<UserDomain>();
            }
        }
    }
}
