using SportsTeamManagementApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Models
{
    public class GameModel : BaseModel
    {
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

        private string _host;
        public string Host
        {
            get { return _host; }
            set
            {
                if (_host != value)
                {
                    _host = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _dateAndTime;
        public string DateAndTime
        {
            get { return _dateAndTime; }
            set
            {
                if (_dateAndTime != value)
                {
                    _dateAndTime = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
