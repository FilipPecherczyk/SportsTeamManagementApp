using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Enums
{
    public enum UserCategoriesEnum
    {
        [Description("Zawodnik")]
        Player,

        [Description("Trener")]
        Coach
    }
}
