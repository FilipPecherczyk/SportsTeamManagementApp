using SportsTeamManagementApp.Common;
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
        public ICommand ScoreboardCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeViewModel();
        private void Scoreboard(object obj) => CurrentView = new ScoreboardViewModel();

        public NavigationViewModel()
        {
            HomeCommand = new RelayCommand(Home);
            ScoreboardCommand = new RelayCommand(Scoreboard);

            // Startup Page
            CurrentView = new HomeViewModel();

        }
    }
}
