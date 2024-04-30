﻿using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Enums;
using SportsTeamManagementApp.Extensions;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows;

namespace SportsTeamManagementApp.ViewModels
{
    public class LoginWindowViewModel : BaseViewModel
    {
        private readonly LoginWindowView View;

        public LoginWindowViewModel(LoginWindowView view)
        {
            View = view;
            OnLoad();
        }

        private void OnLoad()
        {
            Roles = new ObservableCollection<string>()
            {
                EnumTools.GetDescription(UserCategoriesEnum.Player),
                EnumTools.GetDescription(UserCategoriesEnum.Coach)
            };
        }



        #region Collectinos

        private ObservableCollection<string> _roles;
        public ObservableCollection<string> Roles
        {
            get { return _roles; }
            set
            {
                if (_roles != value)
                {
                    _roles = value;
                    OnPropertyChanged();
                }
            }

        }

        #endregion


        #region Operations

        public ICommand LogInCommand
        {
            get
            {
                string commandName = "LogInCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.LogInExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void LogInExecute()
        {
            await Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MainWindow newWindow = new MainWindow();
                    newWindow.Show();
                });

                Application.Current.Dispatcher.Invoke(() =>
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.DataContext == this)
                        {
                            window.Close();
                            break;
                        }
                    }
                });
            });
        }

        #endregion

    }
}
