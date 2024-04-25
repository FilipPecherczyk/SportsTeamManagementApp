using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Models;
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
        public ObservableCollection<ExerciseResultModel> Exercises { get; set; } = new ObservableCollection<ExerciseResultModel>();
        public ObservableCollection<ExerciseResultHistoryModel> HistoryOfExerciseList { get; set; } = new ObservableCollection<ExerciseResultHistoryModel>();


        public ScoreboardViewModel(ScoreboardView view)
        {
            View = view;
            OnLoad();
        }

        private void OnLoad()
        {
            Exercises = new ObservableCollection<ExerciseResultModel>()
            {
                new ExerciseResultModel() { Name = "Wyciskanie klatki leżąc", Result = 80, Unit = "kg" },
                new ExerciseResultModel() { Name = "Bieg na 100m", Result = 12.3, Unit = "sec" },
                new ExerciseResultModel() { Name = "Skok w dal", Result = 4.32, Unit = "m" },
            };

            HistoryOfExerciseList = new ObservableCollection<ExerciseResultHistoryModel>()
            {
                new ExerciseResultHistoryModel() { Date = DateTime.Today, Result = 80, PercentageDifference = "+12%"},
                new ExerciseResultHistoryModel() { Date = DateTime.Today, Result = 70, PercentageDifference = "+7%"},
                new ExerciseResultHistoryModel() { Date = DateTime.Today, Result = 60, PercentageDifference = "+10%"},
                new ExerciseResultHistoryModel() { Date = DateTime.Today, Result = 50, PercentageDifference = "0%"},
            };
        }
    }
}
