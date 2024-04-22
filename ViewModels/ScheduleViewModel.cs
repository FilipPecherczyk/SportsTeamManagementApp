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
    public class ScheduleViewModel : BaseViewModel
    {
        private readonly ScheduleView View;
        public ObservableCollection<CalendarEventModel> Events { get; set; }  = new ObservableCollection<CalendarEventModel>();

        public ScheduleViewModel(ScheduleView view)
        {
            View = view;

            OnLoad();
        }

        private void OnLoad()
        {
            Events = new ObservableCollection<CalendarEventModel>()
            {
                new CalendarEventModel { Name = "Trening", Date = DateTime.Today, Time = "16:00" },
                new CalendarEventModel { Name = "Odnowa", Date = DateTime.Today, Time = "18:30" }
            };
        }
    }
}
