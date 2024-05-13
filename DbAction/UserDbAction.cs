using SportsTeamManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.DbAction
{
    public static class UserDbAction
    {
        public static UserDomain GetUserById(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Users.FirstOrDefault(u => u.Id == id);
            }
        }

        public static void SaveEditUser(UserDomain userDomain)
        {
            using (var db = new DatabaseContext())
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Id == userDomain.Id);

                if (existingUser != null)
                {
                    existingUser.Id = userDomain.Id;
                    existingUser.Login = userDomain.Login;
                    existingUser.Password = userDomain.Password;
                    existingUser.Salt = userDomain.Salt;
                    existingUser.Role = userDomain.Role;
                    existingUser.Name = userDomain.Name;
                    existingUser.LastName = userDomain.LastName;
                    existingUser.Birthday = userDomain.Birthday;
                    existingUser.JoinDate = userDomain.JoinDate;

                    db.SaveChanges();
                }
            }
        }

        public static void DeleteUserById(int id)
        {
            using (var db = new DatabaseContext())
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Id == id);

                if (existingUser != null)
                {
                    db.Users.Remove(existingUser);

                    db.SaveChanges();
                }
                
            }
        }
    }
}
