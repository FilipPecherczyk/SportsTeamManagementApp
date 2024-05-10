using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Entities
{
    public class TeamDomain
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(9)")]
        public string TeamCode { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string Name { get; set; }


        public ButtonsDomain Buttons { get; set; }
        public List<AnnouncementDomain> Announcements { get; set; } = new List<AnnouncementDomain>();
        public List<EventDomain> Events { get; set; } = new List<EventDomain>();
        public List<CompetitionDomain> Competitions { get; set; } = new List<CompetitionDomain>();
        public List<UserDomain> Users { get; set; } = new List<UserDomain>();
    }
}
