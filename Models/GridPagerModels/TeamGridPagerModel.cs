using SportsTeamManagementApp.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Models.GridPagerModels
{
    public class TeamGridPagerModel : BaseViewModel
    {
        public TeamGridPagerModel()
        {
            List = new ObservableCollection<UserModel>();
            SelectedModel = new UserModel();
        }

        private ObservableCollection<UserModel> _list;
        public ObservableCollection<UserModel> List
        {
            get { return _list; }
            set
            {
                if (_list != value)
                {
                    _list = value;
                    OnPropertyChanged();
                }
            }
        }

        private UserModel _selectedModel;
        public UserModel SelectedModel
        {
            get { return _selectedModel; }
            set
            {
                if (_selectedModel != value)
                {
                    _selectedModel = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
