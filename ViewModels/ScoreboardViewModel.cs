using Microsoft.VisualBasic.ApplicationServices;
using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.DbAction;
using SportsTeamManagementApp.Mappings;
using SportsTeamManagementApp.Models;
using SportsTeamManagementApp.Models.GridPagerModels;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace SportsTeamManagementApp.ViewModels
{
    public class ScoreboardViewModel : BaseViewModel
    {
        private readonly ScoreboardView View;

        public ScoreboardViewModel(ScoreboardView view)
        {
            View = view;
            BestResultsData = new BestResultsScoreboardGridPagerModel();
            BestResultsData.PropertyChanged += BestResultsData_PropertyChanged;
            HistoryOfExerciseList = new ObservableCollection<ExerciseResultHistoryModel>();

            OnLoad();
        }

        private void OnLoad()
        {
            BestResultsData.Exercises = ExerciseDbAction.GetBestsExerciseResultsObservalbeCollection();

            HistoryOfExerciseListVisibility = Visibility.Visible;
            AddExerciseScoreVisibility = Visibility.Hidden;
            AddExerciseBtnScoreVisibility = Visibility.Hidden;

            BestResultsDataGridEnabled = true;
        }

        private void BestResultsData_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BestResultsScoreboardGridPagerModel.SelectedModel))
            {
                var exerciseDomainList = ExerciseDbAction.GetExerciseListByCompetitionId(BestResultsData.SelectedModel.CompetitionId).ToList();
                HistoryOfExerciseList = Mapping.ExerciseDomainListToObservableCollectionHistoryModelMap(exerciseDomainList);

                var compModel = CompetitionDbAction.GetCompetition(BestResultsData.SelectedModel.CompetitionId);

                ChosenCompetitionDisplay = compModel != null ? $"{compModel.Name} ({compModel.Unit})" : "";

                if (BestResultsData.SelectedModel.CompetitionId != 0)
                {
                    AddExerciseBtnScoreVisibility = Visibility.Visible;
                }
            }
        }


        #region Properties

        private BestResultsScoreboardGridPagerModel _bestResultsData;
        public BestResultsScoreboardGridPagerModel BestResultsData
        {
            get { return _bestResultsData; }
            set
            {
                if (_bestResultsData != value)
                {
                    _bestResultsData = value;
                    OnPropertyChanged();
                }
            }

        }

        private ObservableCollection<ExerciseResultHistoryModel> _historyOfExerciseList;
        public ObservableCollection<ExerciseResultHistoryModel> HistoryOfExerciseList
        {
            get { return _historyOfExerciseList; }
            set
            {
                if (_historyOfExerciseList != value)
                {
                    _historyOfExerciseList = value;
                    OnPropertyChanged();
                }
            }

        }

        private string _chosenCompetitionDisplay;
        public string ChosenCompetitionDisplay
        {
            get { return _chosenCompetitionDisplay; }
            set
            {
                if (_chosenCompetitionDisplay != value)
                {
                    _chosenCompetitionDisplay = value;
                    OnPropertyChanged();
                }
            }
        }


        private Visibility _addExerciseScoreVisibility;
        public Visibility AddExerciseScoreVisibility
        {
            get { return _addExerciseScoreVisibility; }
            set
            {
                if (_addExerciseScoreVisibility != value)
                {
                    _addExerciseScoreVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _historyOfExerciseListVisibility;
        public Visibility HistoryOfExerciseListVisibility
        {
            get { return _historyOfExerciseListVisibility; }
            set
            {
                if (_historyOfExerciseListVisibility != value)
                {
                    _historyOfExerciseListVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _addExerciseBtnScoreVisibility;
        public Visibility AddExerciseBtnScoreVisibility
        {
            get { return _addExerciseBtnScoreVisibility; }
            set
            {
                if (_addExerciseBtnScoreVisibility != value)
                {
                    _addExerciseBtnScoreVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _bestResultsDataGridEnabled;
        public bool BestResultsDataGridEnabled
        {
            get { return _bestResultsDataGridEnabled; }
            set
            {
                if (_bestResultsDataGridEnabled != value)
                {
                    _bestResultsDataGridEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Operations

        // Add score
        public ICommand AddExerciseScoreCommand
        {
            get
            {
                string commandName = "AddExerciseScoreCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.AddExerciseScoreExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void AddExerciseScoreExecute()
        {
            await Task.Run(() =>
            {
                AddExerciseScore();
            });
        }

        private void AddExerciseScore()
        {
            HistoryOfExerciseListVisibility = Visibility.Hidden;
            AddExerciseScoreVisibility = Visibility.Visible;
            AddExerciseBtnScoreVisibility = Visibility.Hidden;

            BestResultsDataGridEnabled = false;
        }

        // Save score
        public ICommand SaveExerciseScoreCommand
        {
            get
            {
                string commandName = "SaveExerciseScoreCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.SaveExerciseScoreExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void SaveExerciseScoreExecute()
        {
            await Task.Run(() =>
            {
                SaveExerciseScore();
            });
        }

        private void SaveExerciseScore()
        {
            HistoryOfExerciseListVisibility = Visibility.Visible;
            AddExerciseScoreVisibility = Visibility.Hidden;
            AddExerciseBtnScoreVisibility = Visibility.Visible;

            BestResultsDataGridEnabled = true;
        }


        // Cancel
        public ICommand CancelExerciseScoreCommand
        {
            get
            {
                string commandName = "CancelExerciseScoreCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.CancelExerciseScoreExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void CancelExerciseScoreExecute()
        {
            await Task.Run(() =>
            {
                CancelExerciseScore();
            });
        }

        private void CancelExerciseScore()
        {
            HistoryOfExerciseListVisibility = Visibility.Visible;
            AddExerciseScoreVisibility = Visibility.Hidden;
            AddExerciseBtnScoreVisibility = Visibility.Visible;

            BestResultsDataGridEnabled = true;
        }
        #endregion


    }
}
