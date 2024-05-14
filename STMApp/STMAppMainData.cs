using SportsTeamManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.STMApp
{
    public static class STMAppMainData
    {
        public static int LogedUserId { get; set; }
        public static string LogedUserPermissionRole { get; set; }
        public static TeamDomain LogedUserTeam { get; set; }
    }
}
