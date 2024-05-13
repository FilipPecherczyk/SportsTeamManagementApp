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
using System.Windows.Input;
using System.Windows;
using System.Windows.Forms;

namespace SportsTeamManagementApp.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly ProfileView View;

        public ProfileViewModel(ProfileView view)
        {
            View = view;
            OnLoad();
        }

        private void OnLoad()
        {
            var userDomain = UserDbAction.GetUserById(STMAppMainData.LogedUserId);
            User = Mapping.UserDomainToModelMap(userDomain);
            Team = STMAppMainData.LogedUserTeam;

            EditUserEnabled = false;
            EditDeleteButtonVisibility = Visibility.Visible;
            SaveCancelButtonVisibility = Visibility.Hidden;
        }

        #region Properties

        private UserModel _user;
        public UserModel User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
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

        private bool _editUserEnabled;
        public bool EditUserEnabled
        {
            get { return _editUserEnabled; }
            set
            {
                if (_editUserEnabled != value)
                {
                    _editUserEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _editDeleteButtonVisibility;
        public Visibility EditDeleteButtonVisibility
        {
            get { return _editDeleteButtonVisibility; }
            set
            {
                if (_editDeleteButtonVisibility != value)
                {
                    _editDeleteButtonVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _saveCancelButtonVisibility;
        public Visibility SaveCancelButtonVisibility
        {
            get { return _saveCancelButtonVisibility; }
            set
            {
                if (_saveCancelButtonVisibility != value)
                {
                    _saveCancelButtonVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion


        #region Operations

        public ICommand SaveUserCommand
        {
            get
            {
                string commandName = "SaveUserCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.SaveUserExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void SaveUserExecute()
        {
            await Task.Run(() =>
            {
                SaveUser();
            });
        }

        private void SaveUser()
        {
            EditUserEnabled = false;
            var userDomain = Mapping.UserModelToDomainMap(User);
            UserDbAction.SaveEditUser(userDomain);

            EditDeleteButtonVisibility = Visibility.Visible;
            SaveCancelButtonVisibility = Visibility.Hidden;

        }

        public ICommand EditUserCommand
        {
            get
            {
                string commandName = "EditUserCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.EditUserExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void EditUserExecute()
        {
            await Task.Run(() =>
            {
                EditUser();
            });
        }

        private void EditUser()
        {
            EditUserEnabled = true;
            EditDeleteButtonVisibility = Visibility.Hidden;
            SaveCancelButtonVisibility = Visibility.Visible;
        }

        public ICommand CancelUserEditCommand
        {
            get
            {
                string commandName = "CancelUserEditCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.CancelUserEditExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void CancelUserEditExecute()
        {
            await Task.Run(() =>
            {
                CancelUserEdit();
            });
        }

        private void CancelUserEdit()
        {
            OnLoad();
        }

        public ICommand DeleteUserCommand
        {
            get
            {
                string commandName = "DeleteUserCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.DeleteUserExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void DeleteUserExecute()
        {
            await Task.Run(() =>
            {
                DeleteUser();
            });
        }

        private void DeleteUser()
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Czy chcesz usunąć trwale konto? Spowoduje to automatyczne wylogowanie z aplikacji.", "Potwierdzenie",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                UserDbAction.DeleteUserById(User.Id);

                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    System.Windows.Application.Current.Shutdown();
                });
            }

        }

        #endregion
    }
}
