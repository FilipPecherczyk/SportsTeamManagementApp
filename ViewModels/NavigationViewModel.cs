using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.ViewModels;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportsTeamManagementApp.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand TeamCommand { get; set; }
        public ICommand ScheduleCommand { get; set; }
        public ICommand ScoreboardCommand { get; set; }
        public ICommand RankingsCommand { get; set; }
        public ICommand ProfileCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeViewModel(new HomeView());
        private void Team(object obj) => CurrentView = new TeamViewModel(new TeamView());
        private void Schedule(object obj) => CurrentView = new ScheduleViewModel(new ScheduleView());
        private void Scoreboard(object obj) => CurrentView = new ScoreboardViewModel(new ScoreboardView());
        private void Rankings(object obj) => CurrentView = new RankingsViewModel(new RankingsView());
        private void Profile(object obj) => CurrentView = new ProfileViewModel(new ProfileView());

        public NavigationViewModel()
        {
            HomeCommand = new RelayCommand(Home);
            TeamCommand = new RelayCommand(Team);
            ScheduleCommand = new RelayCommand(Schedule);
            ScoreboardCommand = new RelayCommand(Scoreboard);
            RankingsCommand = new RelayCommand(Rankings);
            ProfileCommand = new RelayCommand(Profile);

            // Startup Page
            CurrentView = new HomeViewModel(new HomeView());

        }
    }
}
