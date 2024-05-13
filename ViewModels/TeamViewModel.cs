using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.DbAction;
using SportsTeamManagementApp.Mappings;
using SportsTeamManagementApp.Models;
using SportsTeamManagementApp.Models.GridPagerModels;
using SportsTeamManagementApp.STMApp;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.ViewModels
{
    public class TeamViewModel : BaseViewModel
    {
        private readonly TeamView View;

        public TeamViewModel(TeamView view)
        {
            View = view;
            OnLoad();
        }

        public void OnLoad()
        {
            GridDataSheet = new TeamGridPagerModel();
            var teamUsers = TeamDbAction.GetTeamUsersByTeamId(STMAppMainData.LogedUserTeam.Id);
            GridDataSheet.List = Mapping.TeamUsersListToObservableCollectionMap(teamUsers);

        }

        private TeamGridPagerModel _gridDataSheet;
        public TeamGridPagerModel GridDataSheet
        {
            get { return _gridDataSheet; }
            set
            {
                if (_gridDataSheet != value)
                {
                    _gridDataSheet = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
