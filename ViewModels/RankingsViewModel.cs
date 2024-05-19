using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Enums;
using SportsTeamManagementApp.Extensions;
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
    public class RankingsViewModel : BaseViewModel
    {
        private readonly RankingsView View;

        public RankingsViewModel(RankingsView view)
        {
            View = view;
            OnLoad();
        }


        private void OnLoad()
        {

            Exercise = new ObservableCollection<string>()
            {
                "Wyciskanie klatki leżąc",
                "Bieg na 100m",
                "Skok w dal"
            };


            SetVisibilityAndEnabled();
        }


        private void SetVisibilityAndEnabled()
        {
            if (STMAppMainData.LogedUserPermissionRole == EnumTools.GetDescription(UserCategoriesEnum.Coach))
            {
                AddNewExerciseVisibility = Visibility.Visible;
            }
            else
            {
                AddNewExerciseVisibility = Visibility.Hidden;
            }
        }

        #region Collectinos

        private Visibility _addNewExerciseVisibility;
        public Visibility AddNewExerciseVisibility
        {
            get { return _addNewExerciseVisibility; }
            set
            {
                if (_addNewExerciseVisibility != value)
                {
                    _addNewExerciseVisibility = value;
                    OnPropertyChanged();
                }
            }
        }


        private ObservableCollection<string> _exercise;
        public ObservableCollection<string> Exercise
        {
            get { return _exercise; }
            set
            {
                if (_exercise != value)
                {
                    _exercise = value;
                    OnPropertyChanged();
                }
            }

        }

        #endregion


    }
}
