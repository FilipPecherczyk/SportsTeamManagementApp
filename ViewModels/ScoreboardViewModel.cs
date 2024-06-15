using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.DbAction;
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
        public ObservableCollection<ExerciseResultHistoryModel> HistoryOfExerciseList { get; set; } = new ObservableCollection<ExerciseResultHistoryModel>();


        public ScoreboardViewModel(ScoreboardView view)
        {
            View = view;
            BestResultsData = new BestResultsScoreboardGridPagerModel();
            
            OnLoad();
        }

        private void OnLoad()
        {
            BestResultsData.Exercises = ExerciseDbAction.GetBestsExerciseResultsObservalbeCollection();

            HistoryOfExerciseList = new ObservableCollection<ExerciseResultHistoryModel>()
            {
                new ExerciseResultHistoryModel() { Date = DateTime.Today.ToString("dd.MM.yyyy"), Result = 70, PercentageDifference = "+4"},
                new ExerciseResultHistoryModel() { Date = "11.04.2024", Result = 66, PercentageDifference = "+4"},
                new ExerciseResultHistoryModel() { Date = "27.02.2024", Result = 62, PercentageDifference = "+12"},
                new ExerciseResultHistoryModel() { Date = "01.12.2023", Result = 50, PercentageDifference = "0"},
            };

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

        #endregion
    }
}
