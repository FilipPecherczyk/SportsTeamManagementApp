using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Entities
{
    public class UserDomain
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Login { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Role { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string? LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime JoinDate { get; set; }



        //
        public TeamDomain Team { get; set; }
        public int TeamId { get; set; }

        public List<ExerciseDomain> Exercises { get; set; } = new List<ExerciseDomain>();


    }
}
