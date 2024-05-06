using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Entities
{
    public class EventDomain
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "varchar(8)")]
        public string Time { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Title { get; set; }

        //
        public TeamDomain Team { get; set; }
        public int TeamId { get; set; }

        public List<GameDomain> Games { get; set; } = new List<GameDomain>();

    }
}
