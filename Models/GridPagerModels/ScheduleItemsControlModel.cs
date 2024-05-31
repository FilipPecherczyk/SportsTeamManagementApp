using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Models.SearchCriteria;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Models.GridPagerModels
{
    public class ScheduleItemsControlModel : BaseModel
    {
        public ScheduleItemsControlModel()
        {
            Events = new ObservableCollection<CalendarEventModel>();
        }


        private ObservableCollection<CalendarEventModel> _events;
        public ObservableCollection<CalendarEventModel> Events
        {
            get { return _events; }
            set
            {
                if (_events != value)
                {
                    _events = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _titleData;
        public DateTime TitleData
        {
            get { return _titleData; }
            set
            {
                if (_titleData != value)
                {
                    _titleData = value;
                    OnPropertyChanged();
                    TitleDataDisplay = value.Date.ToString("dd.MM.yyyy");
                }
            }
        }

        private string _titleDataDisplay;
        public string TitleDataDisplay
        {
            get { return _titleDataDisplay; }
            set
            {
                if (_titleDataDisplay != value)
                {
                    _titleDataDisplay = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
