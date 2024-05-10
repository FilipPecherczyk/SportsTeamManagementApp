using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Enums;
using SportsTeamManagementApp.Extensions;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using SportsTeamManagementApp.DbAction;
using SportsTeamManagementApp.Models;
using System.Windows.Input;

namespace SportsTeamManagementApp.ViewModels
{
    public class CreateTeamWindowViewModel : BaseViewModel
    {
        private readonly CreateTeamWindowView View;

        public CreateTeamWindowViewModel(CreateTeamWindowView view)
        {
            View = view;
            OnLoad();
        }

        private void OnLoad()
        {
            CreatedTeamIteamsVisibility = Visibility.Hidden;
            CreateTeamButtonVisibility = Visibility.Visible;
            TeamsNameEnabled = true;
        }


        #region Properties

        private string _teamsName;
        public string TeamsName
        {
            get { return _teamsName; }
            set
            {
                if (_teamsName != value)
                {
                    _teamsName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _teamsCode;
        public string TeamsCode
        {
            get { return _teamsCode; }
            set
            {
                if (_teamsCode != value)
                {
                    _teamsCode = value;
                    OnPropertyChanged();
                }
            }
        }


        private Visibility _createdTeamIteamsVisibility;
        public Visibility CreatedTeamIteamsVisibility
        {
            get { return _createdTeamIteamsVisibility; }
            set
            {
                if (_createdTeamIteamsVisibility != value)
                {
                    _createdTeamIteamsVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _createTeamButtonVisibility;
        public Visibility CreateTeamButtonVisibility
        {
            get { return _createTeamButtonVisibility; }
            set
            {
                if (_createTeamButtonVisibility != value)
                {
                    _createTeamButtonVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _teamsNameEnabled;
        public bool TeamsNameEnabled
        {
            get { return _teamsNameEnabled; }
            set
            {
                if (_teamsNameEnabled != value)
                {
                    _teamsNameEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public ICommand SaveTeamCommand
        {
            get
            {
                string commandName = "SaveTeamCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.SaveTeamExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void SaveTeamExecute()
        {
            await Task.Run(() =>
            {
                SaveTeam();
            });
        }

        private void SaveTeam()
        {
            CreatedTeamIteamsVisibility = Visibility.Visible;
            CreateTeamButtonVisibility = Visibility.Collapsed;
            TeamsNameEnabled = false;

            var code = GenerateNewTeamsFirstUserJoinCode();

            LoginAndRegisterDbAction.AddTeam(TeamsName, code);
            TeamsCode = code;
        }

        private string GenerateNewTeamsFirstUserJoinCode()
        {
            var existingCodes = LoginAndRegisterDbAction.GetTeamsJoinCodes();

            Random rnd = new Random();
            string digits = "0123456789";

            string newCode;
            do
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < 9; i++)
                {
                    int index = rnd.Next(digits.Length);
                    builder.Append(digits[index]);
                }
                newCode = builder.ToString();
            } while (existingCodes.Contains(newCode));

            return newCode;
        }
    }
}
