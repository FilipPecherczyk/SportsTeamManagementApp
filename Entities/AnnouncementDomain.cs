using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Entities
{
    public class AnnouncementDomain
    {
        public int Id { get; set; }

        public string Text { get; set; }


        //
        public TeamDomain Team { get; set; }
        public int TeamId { get; set; }

    }
}
