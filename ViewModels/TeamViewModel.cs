using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.DbAction;
using SportsTeamManagementApp.Enums;
using SportsTeamManagementApp.Extensions;
using SportsTeamManagementApp.Mappings;
using SportsTeamManagementApp.Models;
using SportsTeamManagementApp.Models.GridPagerModels;
using SportsTeamManagementApp.STMApp;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SportsTeamManagementApp.ViewModels
{
    public class TeamViewModel : BaseViewModel
    {
        private readonly TeamView View;

        public TeamViewModel(TeamView view)
        {
            View = view;
            OnLoad();
        }

        public void OnLoad()
        {
            GridDataSheet = new TeamGridPagerModel();
            var teamUsers = TeamDbAction.GetTeamUsersByTeamId(STMAppMainData.LogedUserTeam.Id).OrderBy(t => t.Role).ThenBy(t=> t.Name).ThenBy(t => t.LastName).ToList();
            GridDataSheet.List = Mapping.TeamUsersListToObservableCollectionMap(teamUsers);
            var annoucement = AnnouncementDbAction.GetLatestAnnoucementByTeamId(STMAppMainData.LogedUserTeam.Id);
            if (annoucement != null) Annoucement = annoucement.Text;

            SetVisibilityAndEnabled();
        }

        private void SetVisibilityAndEnabled()
        {
            if (STMAppMainData.LogedUserPermissionRole == EnumTools.GetDescription(UserCategoriesEnum.Coach))
            {
                IsAnnoucementEnabled = false;
                NewAnnoucementVisiblity = Visibility.Visible;
                SaveCancelAnnoucementVisiblity = Visibility.Hidden;
                EditTeamButtonsVisibility = Visibility.Visible;
            }
            else
            {
                IsAnnoucementEnabled = false;
                NewAnnoucementVisiblity = Visibility.Hidden;
                SaveCancelAnnoucementVisiblity = Visibility.Hidden;
                EditTeamButtonsVisibility = Visibility.Hidden;
            }
        }

        #region Properties

        private TeamGridPagerModel _gridDataSheet;
        public TeamGridPagerModel GridDataSheet
        {
            get { return _gridDataSheet; }
            set
            {
                if (_gridDataSheet != value)
                {
                    _gridDataSheet = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Annoucement;
        public string Annoucement
        {
            get { return _Annoucement; }
            set
            {
                if (_Annoucement != value)
                {
                    _Annoucement = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isAnnoucementEnabled;
        public bool IsAnnoucementEnabled
        {
            get { return _isAnnoucementEnabled; }
            set
            {
                if (_isAnnoucementEnabled != value)
                {
                    _isAnnoucementEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _newAnnoucementVisiblity;
        public Visibility NewAnnoucementVisiblity
        {
            get { return _newAnnoucementVisiblity; }
            set
            {
                if (_newAnnoucementVisiblity != value)
                {
                    _newAnnoucementVisiblity = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _saveCancelAnnoucementVisiblity;
        public Visibility SaveCancelAnnoucementVisiblity
        {
            get { return _saveCancelAnnoucementVisiblity; }
            set
            {
                if (_saveCancelAnnoucementVisiblity != value)
                {
                    _saveCancelAnnoucementVisiblity = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _editTeamButtonsVisibility;
        public Visibility EditTeamButtonsVisibility
        {
            get { return _editTeamButtonsVisibility; }
            set
            {
                if (_editTeamButtonsVisibility != value)
                {
                    _editTeamButtonsVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Operations

        //New Annoucement
        public ICommand NewAnnoucementCommand
        {
            get
            {
                string commandName = "NewAnnoucementCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.NewAnnoucementExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void NewAnnoucementExecute()
        {
            await Task.Run(() =>
            {
                NewAnnoucement();
            });
        }

        private void NewAnnoucement()
        {
            IsAnnoucementEnabled = true;
            NewAnnoucementVisiblity = Visibility.Hidden;
            SaveCancelAnnoucementVisiblity = Visibility.Visible;
        }

        //Save Annoucement
        public ICommand SaveAnnoucementCommand
        {
            get
            {
                string commandName = "SaveAnnoucementCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.SaveAnnoucementExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void SaveAnnoucementExecute()
        {
            await Task.Run(() =>
            {
                SaveAnnoucement();
            });
        }

        private void SaveAnnoucement()
        {
            IsAnnoucementEnabled = false;
            NewAnnoucementVisiblity = Visibility.Visible;
            SaveCancelAnnoucementVisiblity = Visibility.Hidden;

            AnnouncementDbAction.AddAnnoucement(Annoucement, STMAppMainData.LogedUserTeam.Id);
        }

        //Cancel Annoucement
        public ICommand CancelAnnoucementCommand
        {
            get
            {
                string commandName = "CancelAnnoucementCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.CancelAnnoucementExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void CancelAnnoucementExecute()
        {
            await Task.Run(() =>
            {
                CancelAnnoucement();
            });
        }

        private void CancelAnnoucement()
        {
            IsAnnoucementEnabled = false;
            NewAnnoucementVisiblity = Visibility.Visible;
            SaveCancelAnnoucementVisiblity = Visibility.Hidden;

            var annoucement = AnnouncementDbAction.GetLatestAnnoucementByTeamId(STMAppMainData.LogedUserTeam.Id);
            if (annoucement != null) Annoucement = annoucement.Text;
        }


        //Cancel Annoucement
        public ICommand EditTeamButtonsCommand
        {
            get
            {
                string commandName = "EditTeamButtonsCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.EditTeamButtonsExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void EditTeamButtonsExecute()
        {
            await Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    TeamButtonsConfigurationWindowView newWindow = new TeamButtonsConfigurationWindowView();
                    newWindow.ShowDialog();
                });
            });
        }

        #endregion
    }
}
