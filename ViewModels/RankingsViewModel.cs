using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
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
        }


    }
}
