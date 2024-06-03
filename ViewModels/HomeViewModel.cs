using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.DbAction;
using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.Enums;
using SportsTeamManagementApp.Extensions;
using SportsTeamManagementApp.Mappings;
using SportsTeamManagementApp.Models;
using SportsTeamManagementApp.STMApp;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SportsTeamManagementApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly HomeView View;

        public HomeViewModel(HomeView view)
        {
            View = view;
            NextGame = new GameModel();

            OnLoad();
        }

        private void OnLoad()
        {
            var userDomain = UserDbAction.GetUserById(STMAppMainData.LogedUserId);
            UserFullName = $"{userDomain.Name} {userDomain.LastName}";
            Team = STMAppMainData.LogedUserTeam;
            var hour = DateTime.Now.TimeOfDay;

            var nextGameDomain = GameDbActions.GetNextGame(DateTime.Today.Date, hour);
            var previousGameDomain = GameDbActions.GetPreviousGame(DateTime.Today.Date, hour);

            NextGame = Mapping.GameDomainToGameModelMap(nextGameDomain);
            PreviousGame = Mapping.GameDomainToGameModelMap(previousGameDomain);

            SetVisibilityAndEnabled();
        }

        private void SetVisibilityAndEnabled()
        {
            ResultVisibility = Visibility.Visible;
            EditResultVisibility = Visibility.Collapsed;

            // Depends of role
            if (STMAppMainData.LogedUserPermissionRole == EnumTools.GetDescription(UserCategoriesEnum.Coach))
            {
                EditResultBtnVisibility = Visibility.Visible;
                SaveCancelResultBtnVisibility = Visibility.Hidden;
            }
            else
            {
                EditResultBtnVisibility = Visibility.Hidden;
                SaveCancelResultBtnVisibility = Visibility.Hidden;
            }
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

        #region Visibility && Enabled

        private Visibility _resultVisibility;
        public Visibility ResultVisibility
        {
            get { return _resultVisibility; }
            set
            {
                if (_resultVisibility != value)
                {
                    _resultVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _editResultVisibility;
        public Visibility EditResultVisibility
        {
            get { return _editResultVisibility; }
            set
            {
                if (_editResultVisibility != value)
                {
                    _editResultVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _editResultBtnVisibility;
        public Visibility EditResultBtnVisibility
        {
            get { return _editResultBtnVisibility; }
            set
            {
                if (_editResultBtnVisibility != value)
                {
                    _editResultBtnVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _saveCancelResultBtnVisibility;
        public Visibility SaveCancelResultBtnVisibility
        {
            get { return _saveCancelResultBtnVisibility; }
            set
            {
                if (_saveCancelResultBtnVisibility != value)
                {
                    _saveCancelResultBtnVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #endregion


        #region Operations

        public ICommand EditResultCommand
        {
            get
            {
                string commandName = "EditResultCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.EditResultExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void EditResultExecute()
        {
            await Task.Run(() =>
            {
                EditResult();
            });
        }

        private void EditResult()
        {
            ResultVisibility = Visibility.Collapsed;
            EditResultVisibility = Visibility.Visible;

            EditResultBtnVisibility = Visibility.Hidden;
            SaveCancelResultBtnVisibility = Visibility.Visible;
        }


        public ICommand SaveResultCommand
        {
            get
            {
                string commandName = "SaveResultCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.SaveResultExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void SaveResultExecute()
        {
            await Task.Run(() =>
            {
                SaveResult();
            });
        }

        private void SaveResult()
        {
            var model = Mapping.GameModelToGameDomainMap(PreviousGame);
            GameDbActions.EditGameScore(model);

            ResultVisibility = Visibility.Visible;
            EditResultVisibility = Visibility.Collapsed;

            EditResultBtnVisibility = Visibility.Visible;
            SaveCancelResultBtnVisibility = Visibility.Hidden;
        }


        public ICommand CancelResultCommand
        {
            get
            {
                string commandName = "CancelResultCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.CancelResultExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void CancelResultExecute()
        {
            await Task.Run(() =>
            {
                CancelResult();
            });
        }

        private void CancelResult()
        {
            ResultVisibility = Visibility.Visible;
            EditResultVisibility = Visibility.Collapsed;

            EditResultBtnVisibility = Visibility.Visible;
            SaveCancelResultBtnVisibility = Visibility.Hidden;
        }
        #endregion



    }
}
