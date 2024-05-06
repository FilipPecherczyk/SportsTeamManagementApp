using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Entities
{
    public class GameDomain
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string Opponent { get; set; }

        [Column(TypeName = "bit")]
        public bool IsHomeGame { get; set; }

        public int? TeamScore { get; set; }

        public int? OpponentScore { get; set; }

        //
        public EventDomain Event { get; set; }
        public int EventId { get; set; }
    }
}
