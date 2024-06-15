using Microsoft.VisualBasic.ApplicationServices;
using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.DbAction;
using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.Enums;
using SportsTeamManagementApp.Extensions;
using SportsTeamManagementApp.Mappings;
using SportsTeamManagementApp.Models;
using SportsTeamManagementApp.Models.SearchCriteria;
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
            Competition = new CompetitionModel();
            RankingList = new ObservableCollection<RankingModel>();
            Criteria = new RankingSearchCriteriaModel();
            OnLoad();
        }


        private void OnLoad()
        {


            CompetitionList = new ObservableCollection<string>();

            var competitionDomainList = CompetitionDbAction.GetCompetitionList();
            

            Criteria.SelectedDate = DateTime.Now;
            //Criteria.ExerciseName = competitionDomainList.FirstOrDefault().Name;


            foreach (var competitionDomain in competitionDomainList)
            {
                CompetitionList.Add(competitionDomain.Name);
            }

            SetVisibilityAndEnabled();
        }


        private void SetVisibilityAndEnabled()
        {
            SaveCancelNewExerciseVisiblity = Visibility.Hidden;

            RankingDataGridVisibility = Visibility.Visible;
            NewExercisePanelVisibility = Visibility.Hidden;
            LeftPanelEnabled = true;

            Competition.Name = "";
            Competition.Unit = "";

            if (STMAppMainData.LogedUserPermissionRole == EnumTools.GetDescription(UserCategoriesEnum.Coach))
            {
                AddNewExerciseBtnVisibility = Visibility.Visible;
            }
            else
            {
                AddNewExerciseBtnVisibility = Visibility.Hidden;
            }
        }

        #region Properties

        private RankingSearchCriteriaModel _criteria;
        public RankingSearchCriteriaModel Criteria
        {
            get { return _criteria; }
            set
            {
                if (_criteria != value)
                {
                    _criteria = value;
                    OnPropertyChanged();
                }
            }

        }

        private ObservableCollection<string> _competitionList;
        public ObservableCollection<string> CompetitionList
        {
            get { return _competitionList; }
            set
            {
                if (_competitionList != value)
                {
                    _competitionList = value;
                    OnPropertyChanged();
                }
            }

        }

        private ObservableCollection<RankingModel> _rankingList;
        public ObservableCollection<RankingModel> RankingList
        {
            get { return _rankingList; }
            set
            {
                if (_rankingList != value)
                {
                    _rankingList = value;
                    OnPropertyChanged();
                }
            }
        }

        private CompetitionModel _competition;
        public CompetitionModel Competition
        {
            get { return _competition; }
            set
            {
                if (_competition != value)
                {
                    _competition = value;
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

        #region Visibility && Enabled

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

        #endregion

        #endregion

        #region Operations

        // Add new exercise CleanCriteriaCommand
        public ICommand GenerateRankingCommand
        {
            get
            {
                string commandName = "GenerateRankingCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.GenerateRankingExercise());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void GenerateRankingExercise()
        {
            await Task.Run(() =>
            {
                GenerateRanking();
            });
        }

        private void GenerateRanking()
        {
            if (Criteria.ExerciseName != null)
            {
                RankingList = RankingDbAction.GetExerciseRankingObservalbeCollection(Criteria.ExerciseName, Criteria.SelectedDate);

                var compModel = CompetitionDbAction.GetCompetition(Criteria.ExerciseName);

                ChosenCompetitionDisplay = compModel != null ? $"{compModel.Name} ({compModel.Unit})" : "";
            }

        }


        // Clean criteria CleanCriteriaCommand
        public ICommand CleanCriteriaCommand
        {
            get
            {
                string commandName = "CleanCriteriaCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.CleanCriteriaExercise());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void CleanCriteriaExercise()
        {
            await Task.Run(() =>
            {
                CleanCriteria();
            });
        }

        private void CleanCriteria()
        {
            Criteria.ExerciseName = null;
            Criteria.SelectedDate = DateTime.Now;

            ChosenCompetitionDisplay = null;
        }



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
                command = new RelayCommand(param => this.AddNewExercise());
                return _relayCommands[commandName] = command;
            }

            set { }
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
            var competitionDomain = Mapping.CompetitionModelToDomainMap(Competition);
            CompetitionDbAction.AddCompetition(competitionDomain, TeamDbAction.GetTeamTeamPlayers().ToList());

            SetVisibilityAndEnabled();
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
            SetVisibilityAndEnabled();
        }

        #endregion


    }
}
