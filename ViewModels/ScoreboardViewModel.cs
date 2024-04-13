using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
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
        }
    }
}
