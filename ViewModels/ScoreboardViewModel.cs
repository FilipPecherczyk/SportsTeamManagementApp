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
        }

        private void BestResultsData_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BestResultsScoreboardGridPagerModel.SelectedModel))
            {
                var exerciseDomainList = ExerciseDbAction.GetExerciseListByCompetitionId(BestResultsData.SelectedModel.CompetitionId).ToList();
                HistoryOfExerciseList = Mapping.ExerciseDomainListToObservableCollectionHistoryModelMap(exerciseDomainList);

                var compModel = CompetitionDbAction.GetCompetition(BestResultsData.SelectedModel.CompetitionId);

                ChosenCompetitionDisplay = compModel != null ? $"{compModel.Name} ({compModel.Unit})" : "";
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

        #endregion
    }
}
