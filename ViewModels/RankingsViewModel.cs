using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Players = new ObservableCollection<string>()
            {
                "Jan Kowalski",
                "Rafał Paciorek",
                "Robert Lewandowski",
                "Adam Małysz",
                "Monika Kowalska",
                "Joanna Jędrzejczyk"
            };

            Exercise = new ObservableCollection<string>()
            {
                "Wyciskanie klatki leżąc",
                "Bieg na 100m",
                "Skok w dal"
            };

        }

        #region Collectinos

        private ObservableCollection<string> _players;
        public ObservableCollection<string> Players
        {
            get { return _players; }
            set
            {
                if (_players != value)
                {
                    _players = value;
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


    }
}
