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
                new ExerciseResultModel() { Name = "Wyciskanie klatki leżąc", Result = 70, Unit = "kg" },
                new ExerciseResultModel() { Name = "Bieg na 100m", Result = 12.3, Unit = "sec" },
                new ExerciseResultModel() { Name = "Skok w dal", Result = 4.32, Unit = "m" },
            };

            HistoryOfExerciseList = new ObservableCollection<ExerciseResultHistoryModel>()
            {
                new ExerciseResultHistoryModel() { Date = DateTime.Today.ToString("dd.MM.yyyy"), Result = 70, PercentageDifference = "+4"},
                new ExerciseResultHistoryModel() { Date = "11.04.2024", Result = 66, PercentageDifference = "+4"},
                new ExerciseResultHistoryModel() { Date = "27.02.2024", Result = 62, PercentageDifference = "+12"},
                new ExerciseResultHistoryModel() { Date = "01.12.2023", Result = 50, PercentageDifference = "0"},
            };
        }
    }
}
