using Microsoft.VisualBasic.ApplicationServices;
using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.DbAction;
using SportsTeamManagementApp.Enums;
using SportsTeamManagementApp.Extensions;
using SportsTeamManagementApp.Mappings;
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
    public class RankingsViewModel : BaseViewModel
    {
        private readonly RankingsView View;

        public RankingsViewModel(RankingsView view)
        {
            View = view;
            OnLoad();
        }


        private void OnLoad()
        {

            Exercise = new ObservableCollection<string>()
            {
                "Wyciskanie klatki leżąc",
                "Bieg na 100m",
                "Skok w dal"
            };


            SetVisibilityAndEnabled();
        }


        private void SetVisibilityAndEnabled()
        {
            SaveCancelNewExerciseVisiblity = Visibility.Hidden;

            RankingDataGridVisibility = Visibility.Visible;
            NewExercisePanelVisibility = Visibility.Hidden;
            LeftPanelEnabled = true;

            if (STMAppMainData.LogedUserPermissionRole == EnumTools.GetDescription(UserCategoriesEnum.Coach))
            {
                AddNewExerciseBtnVisibility = Visibility.Visible;
            }
            else
            {
                AddNewExerciseBtnVisibility = Visibility.Hidden;
            }
        }

        #region Collectinos

        private Visibility _addNewExerciseBtnVisibility;
        public Visibility AddNewExerciseBtnVisibility
        {
            get { return _addNewExerciseBtnVisibility; }
            set
            {
                if (_addNewExerciseBtnVisibility != value)
                {
                    _addNewExerciseBtnVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _saveCancelNewExerciseVisiblity;
        public Visibility SaveCancelNewExerciseVisiblity
        {
            get { return _saveCancelNewExerciseVisiblity; }
            set
            {
                if (_saveCancelNewExerciseVisiblity != value)
                {
                    _saveCancelNewExerciseVisiblity = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _rankingDataGridVisibility;
        public Visibility RankingDataGridVisibility
        {
            get { return _rankingDataGridVisibility; }
            set
            {
                if (_rankingDataGridVisibility != value)
                {
                    _rankingDataGridVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _newExercisePanelVisibility;
        public Visibility NewExercisePanelVisibility
        {
            get { return _newExercisePanelVisibility; }
            set
            {
                if (_newExercisePanelVisibility != value)
                {
                    _newExercisePanelVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _leftPanelEnabled;
        public bool LeftPanelEnabled
        {
            get { return _leftPanelEnabled; }
            set
            {
                if (_leftPanelEnabled != value)
                {
                    _leftPanelEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<string> _exercise;
        public ObservableCollection<string> Exercise
        {
            get { return _exercise; }
            set
            {
                if (_exercise != value)
                {
                    _exercise = value;
                    OnPropertyChanged();
                }
            }

        }

        #endregion

        #region Operations

        // Add new exercise
        public ICommand AddNewExerciseCommand
        {
            get
            {
                string commandName = "AddNewExerciseCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.AddNewExerciseExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void AddNewExerciseExecute()
        {
            await Task.Run(() =>
            {
                AddNewExercise();
            });
        }

        private void AddNewExercise()
        {
            SaveCancelNewExerciseVisiblity = Visibility.Visible;
            AddNewExerciseBtnVisibility = Visibility.Hidden;

            RankingDataGridVisibility = Visibility.Hidden;
            NewExercisePanelVisibility = Visibility.Visible;
            LeftPanelEnabled = false;
        }


        // Save new exercise
        public ICommand SaveNewExerciseBtnCommand
        {
            get
            {
                string commandName = "SaveNewExerciseBtnCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.SaveNewExerciseBtnExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void SaveNewExerciseBtnExecute()
        {
            await Task.Run(() =>
            {
                SaveNewExerciseBtn();
            });
        }

        private void SaveNewExerciseBtn()
        {
            SaveCancelNewExerciseVisiblity = Visibility.Hidden;
            AddNewExerciseBtnVisibility = Visibility.Visible;

            RankingDataGridVisibility = Visibility.Visible;
            NewExercisePanelVisibility = Visibility.Hidden;
            LeftPanelEnabled = true;
        }


        // Cancel new exercise
        public ICommand CancelSaveNewExerciseBtnCommand
        {
            get
            {
                string commandName = "CancelSaveNewExerciseBtnCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.CancelSaveNewExerciseBtnExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void CancelSaveNewExerciseBtnExecute()
        {
            await Task.Run(() =>
            {
                CancelSaveNewExerciseBtn();
            });
        }

        private void CancelSaveNewExerciseBtn()
        {
            SaveCancelNewExerciseVisiblity = Visibility.Hidden;
            AddNewExerciseBtnVisibility = Visibility.Visible;

            RankingDataGridVisibility = Visibility.Visible;
            NewExercisePanelVisibility = Visibility.Hidden;
            LeftPanelEnabled = true;
        }

        #endregion


    }
}
