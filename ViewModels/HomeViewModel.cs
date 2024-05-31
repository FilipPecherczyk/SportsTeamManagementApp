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
            NextGame = new GameModel();
            PreviousGame = new GameModel();
        }

        private void OnLoad()
        {
            var userDomain = UserDbAction.GetUserById(STMAppMainData.LogedUserId);
            UserFullName = $"{userDomain.Name} {userDomain.LastName}";
            Team = STMAppMainData.LogedUserTeam;
            var hour = DateTime.Now.TimeOfDay;

            var a = GameDbActions.GetNextGame(DateTime.Today.Date, hour);
            var b = GameDbActions.GetPreviousGame(DateTime.Today.Date, hour);
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

        private GameModel _nextGame;
        public GameModel NextGame
        {
            get { return _nextGame; }
            set
            {
                if (_nextGame != value)
                {
                    _nextGame = value;
                    OnPropertyChanged();
                }
            }
        }

        private GameModel _previousGame;
        public GameModel PreviousGame
        {
            get { return _previousGame; }
            set
            {
                if (_previousGame != value)
                {
                    _previousGame = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion
    }
}
