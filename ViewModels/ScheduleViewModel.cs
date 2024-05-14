using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Enums;
using SportsTeamManagementApp.Extensions;
using SportsTeamManagementApp.Models;
using SportsTeamManagementApp.STMApp;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                new CalendarEventModel { Name = "Trening", Date = DateTime.Today, Time = "16:00" },
                new CalendarEventModel { Name = "Trening", Date = DateTime.Today, Time = "16:00" },
                new CalendarEventModel { Name = "Trening", Date = DateTime.Today, Time = "16:00" },
                new CalendarEventModel { Name = "Odnowa", Date = DateTime.Today, Time = "18:30" },
                new CalendarEventModel { Name = "Odnowa", Date = DateTime.Today, Time = "18:30" },
                new CalendarEventModel { Name = "Odnowa", Date = DateTime.Today, Time = "18:30" },
                new CalendarEventModel { Name = "Odnowa", Date = DateTime.Today, Time = "18:30" }
            };

            SetVisibilityAndEnabled();
        }

        private void SetVisibilityAndEnabled()
        {
            if (STMAppMainData.LogedUserPermissionRole == EnumTools.GetDescription(UserCategoriesEnum.Coach))
            {
                CreateNewEventVisibility = Visibility.Visible;
            }
            else
            {
                CreateNewEventVisibility = Visibility.Hidden;
            }
        }

        private Visibility _createNewEventVisibility;
        public Visibility CreateNewEventVisibility
        {
            get { return _createNewEventVisibility; }
            set
            {
                if (_createNewEventVisibility != value)
                {
                    _createNewEventVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
