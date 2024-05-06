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
    }
}
