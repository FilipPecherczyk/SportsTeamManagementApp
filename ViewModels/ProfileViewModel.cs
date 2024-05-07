using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly ProfileView View;

        public ProfileViewModel(ProfileView view)
        {
            View = view;
        }
    }
}
