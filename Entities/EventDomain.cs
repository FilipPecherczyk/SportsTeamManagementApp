using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Entities
{
    public class EventDomain
    {
        public DateTime Date { get; set; }
        public TimeOnly Time { get; set; }
        public string Title { get; set; }
    }
}
