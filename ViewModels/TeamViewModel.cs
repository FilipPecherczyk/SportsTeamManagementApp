using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.ViewModels
{
    public class TeamViewModel : BaseViewModel
    {
        private readonly TeamView View;

        public TeamViewModel(TeamView view)
        {
            View = view;
        }
    }
}
