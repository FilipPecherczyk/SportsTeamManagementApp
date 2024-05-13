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
            var teamUsers = TeamDbAction.GetTeamUsersByTeamId(STMAppMainData.LogedUserTeam.Id).OrderBy(t => t.Role).ThenBy(t=> t.Name).ThenBy(t => t.LastName).ToList();
            GridDataSheet.List = Mapping.TeamUsersListToObservableCollectionMap(teamUsers);
            var annoucement = AnnouncementDbAction.GetLatestAnnoucementByTeamId(STMAppMainData.LogedUserTeam.Id);
            if (annoucement != null) Annoucement = annoucement.Text;
        }

        #region Properties

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

        private string _Annoucement;
        public string Annoucement
        {
            get { return _Annoucement; }
            set
            {
                if (_Annoucement != value)
                {
                    _Annoucement = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion
    }
}
