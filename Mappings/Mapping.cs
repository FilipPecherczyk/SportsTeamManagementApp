using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Mappings
{
    public static class Mapping
    {
        public static UserDomain UserModelToDomainMap(UserModel userModel)
        {
            var userDomain = new UserDomain();
            if (userModel != null)
            {
                userDomain.Id = userModel.Id;
                userDomain.Login = userModel.Login;
                userDomain.Password = userModel.Password;
                userDomain.Salt = userModel.Salt;
                userDomain.Role = userModel.Role;
                userDomain.Name = userModel.Name;
                userDomain.LastName = userModel.LastName;
                userDomain.Birthday = userModel.Birthday;
                userDomain.JoinDate = userModel.JoinDate;
            }

            return userDomain;
        }

        public static UserModel UserDomainToModelMap(UserDomain userDomain)
        {
            var userModel = new UserModel();
            if (userDomain != null)
            {
                userModel.Id = userDomain.Id;
                userModel.Login = userDomain.Login;
                userModel.Password = userDomain.Password;
                userModel.Salt = userDomain.Salt;
                userModel.Role = userDomain.Role;
                userModel.Name = userDomain.Name;
                userModel.LastName = userDomain.LastName;
                userModel.Birthday = userDomain.Birthday;
                userModel.JoinDate = userDomain.JoinDate;
            }

            return userModel;
        }
    }
}
