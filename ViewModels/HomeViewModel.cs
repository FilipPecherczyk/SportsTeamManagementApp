using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.DbAction;
using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.Mappings;
using SportsTeamManagementApp.Models;
using SportsTeamManagementApp.STMApp;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly HomeView View;

        public HomeViewModel(HomeView view)
        {
            View = view;
            OnLoad();
        }

        private void OnLoad()
        {
            var userDomain = UserDbAction.GetUserById(STMAppMainData.LogedUserId);
            UserFullName = $"{userDomain.Name} {userDomain.LastName}";
            Team = STMAppMainData.LogedUserTeam;
        }

        #region Properties

        private string _userFullName;
        public string UserFullName
        {
            get { return _userFullName; }
            set
            {
                if (_userFullName != value)
                {
                    _userFullName = value;
                    OnPropertyChanged();
                }
            }
        }

        private TeamDomain _team;
        public TeamDomain Team
        {
            get { return _team; }
            set
            {
                if (_team != value)
                {
                    _team = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion
    }
}
