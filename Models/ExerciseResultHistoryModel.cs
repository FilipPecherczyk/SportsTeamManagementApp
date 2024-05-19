using SportsTeamManagementApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Models
{
    public class ExerciseResultHistoryModel : BaseModel
    {
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

        private double _result;
        public double Result
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

        private string _percentageDifference;
        public string PercentageDifference
        {
            get { return _percentageDifference; }
            set
            {
                if (_percentageDifference != value)
                {
                    _percentageDifference = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
