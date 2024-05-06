using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Entities
{
    public class ExerciseDomain
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Score { get; set; }

        public DateTime Date { get; set; }

        //
        public CompetitionDomain Competition { get; set; }
        public int CompetitionId { get; set; }

        public UserDomain User { get; set; }
        public int UserId { get; set; }
    }
}
