using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.ViewModels
{
    public class CreateTeamWindowViewModel : BaseViewModel
    {
        private readonly CreateTeamWindowView View;

        public CreateTeamWindowViewModel(CreateTeamWindowView view)
        {
            View = view;
        }
    }
}
