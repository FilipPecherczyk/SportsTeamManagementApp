using SportsTeamManagementApp.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Models.GridPagerModels
{
    public class BestResultsScoreboardGridPagerModel : BaseModel
    {
        public BestResultsScoreboardGridPagerModel()
        {
            Exercises = new ObservableCollection<ExerciseResultModel>();
            SelectedModel = new ExerciseResultModel();
        }

        private ObservableCollection<ExerciseResultModel> _exercises;
        public ObservableCollection<ExerciseResultModel> Exercises
        {
            get { return _exercises; }
            set
            {
                if (_exercises != value)
                {
                    _exercises = value;
                    OnPropertyChanged();
                }
            }
        }

        private ExerciseResultModel _selectedModel;
        public ExerciseResultModel SelectedModel
        {
            get { return _selectedModel; }
            set
            {
                if (value != _selectedModel)
                {
                    _selectedModel = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
