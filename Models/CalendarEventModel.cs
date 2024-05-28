using SportsTeamManagementApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Models
{
    public class CalendarEventModel : BaseModel
    {
        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _date;
        public string Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _time;
        public string Time
        {
            get { return _time; }
            set
            {
                if (_time != value)
                {
                    _time = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _timeHour;
        public string TimeHour
        {
            get { return _timeHour; }
            set
            {
                if (_timeHour != value)
                {
                    _timeHour = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _timeMinute;
        public string TimeMinute
        {
            get { return _timeMinute; }
            set
            {
                if (_timeMinute != value)
                {
                    _timeMinute = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _opponent;
        public string Opponent
        {
            get { return _opponent; }
            set
            {
                if (_opponent != value)
                {
                    _opponent = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isHomeGame;
        public bool IsHomeGame
        {
            get { return _isHomeGame; }
            set
            {
                if (_isHomeGame != value)
                {
                    _isHomeGame = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
