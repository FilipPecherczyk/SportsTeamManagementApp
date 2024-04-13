using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        private readonly ScheduleView View;

        public ScheduleViewModel(ScheduleView view)
        {
            View = view;
        }
    }
}
