using SportsTeamManagementApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Models.SearchCriteria
{
    public class RankingSearchCriteriaModel : BaseModel
    {
        private string _exerciseName;
        public string ExerciseName
        {
            get { return _exerciseName; }
            set
            {
                if (_exerciseName != value)
                {
                    _exerciseName = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _SelectedDate;
        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set
            {
                if (_SelectedDate != value)
                {
                    _SelectedDate = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
