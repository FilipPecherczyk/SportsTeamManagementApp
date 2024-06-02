using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.Models;
using SportsTeamManagementApp.STMApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Mappings
{
    public static class Mapping
    {
        #region User

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

        #endregion

        #region Team

        public static ObservableCollection<UserModel> TeamUsersListToObservableCollectionMap(IList<UserDomain> users)
        {
            var finalList = new ObservableCollection<UserModel>();

            if (users != null)
            {
                foreach (var user in users)
                {
                    finalList.Add(new UserModel()
                    {
                        Id = user.Id,
                        Login = user.Login,
                        Password = user.Password,
                        Salt = user.Salt,
                        Role = user.Role,
                        Name = user.Name,
                        LastName = user.LastName,
                        Birthday = user.Birthday,
                        JoinDate = user.JoinDate,
                    });
                }
            }

            return finalList;
        }

        #endregion

        #region Event

        public static ObservableCollection<CalendarEventModel> EventDomainListToCalendarEventModelObservableCollectionMap(IList<EventDomain> events)
        {
            var finalList = new ObservableCollection<CalendarEventModel>();

            foreach (var item in events)
            {
                finalList.Add(new CalendarEventModel()
                {
                    Name = item.Title,
                    Date = item.Date.ToString("dd.MM.yyyy"),
                    Time = item.Time,
                });
            }

            return finalList;
        }

        #endregion

        #region Game

        public static GameModel GameDomainToGameModelMap(GameDomain domain)
        {
            var finalModel = new GameModel();

            if (domain != null)
            {
                finalModel.Id = domain.Id;
                finalModel.Opponent = domain.Opponent;
                finalModel.Host = domain.IsHomeGame ? STMAppMainData.LogedUserTeam.Name : domain.Opponent;
                finalModel.DateAndTime = $"{domain.Event.Date.ToString("dd.MM.yyyy")}, {domain.Event.Time}";

                if (domain.OpponentScore != null && domain.TeamScore != null)
                {
                    if (domain.TeamScore > domain.OpponentScore)
                    {
                        finalModel.Result = $"Wygrana {domain.TeamScore}:{domain.OpponentScore}";
                    }
                    else if (domain.TeamScore < domain.OpponentScore)
                    {
                        finalModel.Result = $"Przegrana {domain.TeamScore}:{domain.OpponentScore}";
                    }
                    else
                    {
                        finalModel.Result = $"Remis {domain.TeamScore}:{domain.OpponentScore}";
                    }
                }
                else
                {
                    finalModel.Result = "???";
                }

            }
            else
            {
                finalModel.Opponent = "???";
                finalModel.Host = "???";
                finalModel.DateAndTime = "???";
                finalModel.Result = "???";
            }

            return finalModel;
        }

        #endregion
    }
}
