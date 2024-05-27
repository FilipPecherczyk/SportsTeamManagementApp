using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Enums
{
    public enum EventNameTypeEnum
    {
        [Description("Mecz")]
        Game,

        [Description("Trening")]
        Training,

        [Description("Inne")]
        Other,
    }
}
