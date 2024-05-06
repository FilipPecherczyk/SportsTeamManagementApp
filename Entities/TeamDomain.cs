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

        [Column(TypeName = "varchar(4)")]
        public string TeamCode { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string Name { get; set; }
    }
}
