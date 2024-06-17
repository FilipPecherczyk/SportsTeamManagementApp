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
using Newtonsoft.Json;

namespace SportsTeamManagementApp.ViewModels
{
    public class TeamButtonsConfigurationWindowViewModel : BaseViewModel
    {
        private readonly TeamButtonsConfigurationWindowView _view;
        private int DataBaseButtonId;

        public TeamButtonsConfigurationWindowViewModel(TeamButtonsConfigurationWindowView view)
        {
            _view = view;
            FirstButton = new TeamButtonModel();
            SecondButton = new TeamButtonModel();
            ThirdButton = new TeamButtonModel();

            OnLoad();
        }

        private void OnLoad()
        {
            FirstButton.IndexNumber = 1;
            SecondButton.IndexNumber = 2;
            ThirdButton.IndexNumber = 3;

            DataBaseButtonId = 0;

            GetButtonsInfo();
        }

        private void GetButtonsInfo()
        {
            var buttonsDomain = ButtonsDbAction.GetButtons();
            if (buttonsDomain != null)
            {
                var buttonsList = JsonConvert.DeserializeObject<List<TeamButtonModel>>(buttonsDomain.ButtonsJSON);

                FirstButton = buttonsList[0];
                SecondButton = buttonsList[1];
                ThirdButton = buttonsList[2];

                DataBaseButtonId = buttonsDomain.Id;
            }
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

            string json = JsonConvert.SerializeObject(abc, Formatting.Indented);
            if (DataBaseButtonId != 0)
            {
                ButtonsDbAction.SaveEditButtons(json, DataBaseButtonId);
            }
            else
            {
                ButtonsDbAction.AddButton(json);
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                _view.Close();
            });
        }

    }
}
