using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.DbAction;
using SportsTeamManagementApp.Models;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace SportsTeamManagementApp.ViewModels
{
    public class TeamButtonsConfigurationWindowViewModel : BaseViewModel
    {
        private readonly TeamButtonsConfigurationWindowView _view;

        public TeamButtonsConfigurationWindowViewModel(TeamButtonsConfigurationWindowView view)
        {
            _view = view;
            FirstButton = new TeamButtonModel();
            SecondButton = new TeamButtonModel();
            ThirdButton = new TeamButtonModel();

            GetButtonsInfo();
        }

        private void GetButtonsInfo()
        {

        }

        private TeamButtonModel _firstButton;
        public TeamButtonModel FirstButton
        {
            get { return _firstButton; }
            set
            {
                if (_firstButton != value)
                {
                    _firstButton = value;
                    OnPropertyChanged();
                }
            }
        }

        private TeamButtonModel _secondButton;
        public TeamButtonModel SecondButton
        {
            get { return _secondButton; }
            set
            {
                if (_secondButton != value)
                {
                    _secondButton = value;
                    OnPropertyChanged();
                }
            }
        }

        private TeamButtonModel _thirdButton;
        public TeamButtonModel ThirdButton
        {
            get { return _thirdButton; }
            set
            {
                if (_thirdButton != value)
                {
                    _thirdButton = value;
                    OnPropertyChanged();
                }
            }
        }


        public ICommand SaveButtonsConfigurationCommand
        {
            get
            {
                string commandName = "SaveButtonsConfigurationCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.SaveButtonsConfigurationExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void SaveButtonsConfigurationExecute()
        {
            await Task.Run(() =>
            {
                SaveButtonsConfiguration();
            });
        }

        private void SaveButtonsConfiguration()
        {
            var abc = new List<TeamButtonModel>()
            {
                FirstButton,
                SecondButton,
                ThirdButton
            };
        }

    }
}
