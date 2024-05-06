using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Entities
{
    public class GameDomain
    {
        public string Opponent { get; set; }
        public bool IsHomeGame { get; set; }
        public int TeamScore { get; set; }
        public int OpponentScore { get; set; }
    }
}
