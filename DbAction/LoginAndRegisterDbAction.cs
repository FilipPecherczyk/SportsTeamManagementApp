using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using SportsTeamManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.DbAction
{
    public static class LoginAndRegisterDbAction
    {
        public static void AddUser(string login, string password, string role, string joinCode, string salt)
        {
            using (var db = new DatabaseContext())
            {
                var teams = db.Users.Add(new UserDomain 
                {
                    Login = login,
                    Password = password,
                    Role = role,
                    Salt = salt,
                    JoinDate = DateTime.Now,
                    TeamId = 1,
                });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// If 0 there is no such User, if != 0 it is UserId
        /// </summary>
        /// <param name="login"></param>
        /// <param name="hashPassword"></param>
        /// <returns></returns>
        public static UserDomain GetUserIdIfLoginAndPasswordAreCorrect(string login, string hashPassword)
        {
            var userId = 0;

            using (var db = new DatabaseContext())
            {
                var loginUser = db.Users.FirstOrDefault(u => u.Login == login);
                if (loginUser != null && $"{hashPassword}{loginUser.Salt}" == loginUser.Password)
                {
                    return loginUser;
                }
            }

            return null;
        }

        public static IEnumerable<string> GetTeamsJoinCodes()
        {
            using (var db = new DatabaseContext())
            {
                return db.Teams.Select(t => t.TeamCode).ToList();
            }
        }

        public static void AddTeam(string Name, string joinCode)
        {
            using (var db = new DatabaseContext())
            {
                var teams = db.Teams.Add(new TeamDomain
                {
                    Name = Name,
                    TeamCode = joinCode
                });
                db.SaveChanges();
            }
        }

    }
}
