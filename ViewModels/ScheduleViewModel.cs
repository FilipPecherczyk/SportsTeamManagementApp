using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Enums;
using SportsTeamManagementApp.Extensions;
using SportsTeamManagementApp.Models;
using SportsTeamManagementApp.Models.GridPagerModels;
using SportsTeamManagementApp.Models.SearchCriteria;
using SportsTeamManagementApp.STMApp;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SportsTeamManagementApp.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        private readonly ScheduleView View;

        public ScheduleViewModel(ScheduleView view)
        {
            View = view;
            EventPanelData = new ScheduleItemsControlModel();
            OnLoad();
        }

        private void OnLoad()
        {
            EventPanelData.TitleData = DateTime.Today;

            SetVisibilityAndEnabled();
        }

        private void SetVisibilityAndEnabled()
        {
            CalendarEventPanelVisibility = Visibility.Visible;
            CreateNewEventPanelVisibility = Visibility.Hidden;
            CalendarEnabled = true;
            SaveCancelNewEventBtnVisibility = Visibility.Hidden;

            // Depends of role
            if (STMAppMainData.LogedUserPermissionRole == EnumTools.GetDescription(UserCategoriesEnum.Coach))
            {
                CreateNewEventBtnVisibility = Visibility.Visible;
            }
            else
            {
                CreateNewEventBtnVisibility = Visibility.Hidden;
            }
        }

        #region Properties

        private CalendarEventModel _NewEventModel;
        public CalendarEventModel NewEventModel
        {
            get { return _NewEventModel; }
            set
            {
                if (_NewEventModel != value)
                {
                    _NewEventModel = value;
                    OnPropertyChanged();
                }
            }
        }

        private ScheduleItemsControlModel _eventPanelData;
        public ScheduleItemsControlModel EventPanelData
        {
            get { return _eventPanelData; }
            set
            {
                if (_eventPanelData != value)
                {
                    _eventPanelData = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _createNewEventBtnVisibility;
        public Visibility CreateNewEventBtnVisibility
        {
            get { return _createNewEventBtnVisibility; }
            set
            {
                if (_createNewEventBtnVisibility != value)
                {
                    _createNewEventBtnVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _saveCancelNewEventBtnVisibility;
        public Visibility SaveCancelNewEventBtnVisibility
        {
            get { return _saveCancelNewEventBtnVisibility; }
            set
            {
                if (_saveCancelNewEventBtnVisibility != value)
                {
                    _saveCancelNewEventBtnVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _calendarEventPanelVisibility;
        public Visibility CalendarEventPanelVisibility
        {
            get { return _calendarEventPanelVisibility; }
            set
            {
                if (_calendarEventPanelVisibility != value)
                {
                    _calendarEventPanelVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _createNewEventPanelVisibility;
        public Visibility CreateNewEventPanelVisibility
        {
            get { return _createNewEventPanelVisibility; }
            set
            {
                if (_createNewEventPanelVisibility != value)
                {
                    _createNewEventPanelVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _calendarEnabled;
        public bool CalendarEnabled
        {
            get { return _calendarEnabled; }
            set
            {
                if (_calendarEnabled != value)
                {
                    _calendarEnabled = value;
                    OnPropertyChanged();
                }
            }
        }




        #endregion

        #region Operations

        // New event
        public ICommand CreateNewEventCommand
        {
            get
            {
                string commandName = "CreateNewEventCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.CreateNewEventExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void CreateNewEventExecute()
        {
            await Task.Run(() =>
            {
                CreateNewEvent();
            });
        }

        private void CreateNewEvent()
        {
            NewEventModel = new CalendarEventModel()
            {   Date = EventPanelData.TitleData.Date.ToString(),
                Name = "próba",
                Time = "12:00"
            };

            CalendarEventPanelVisibility = Visibility.Hidden;
            CreateNewEventPanelVisibility = Visibility.Visible;

            SaveCancelNewEventBtnVisibility = Visibility.Visible;
            CalendarEnabled = false;
        }

        // Save event
        public ICommand SaveNewEventCommand
        {
            get
            {
                string commandName = "SaveNewEventCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.SaveNewEventExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void SaveNewEventExecute()
        {
            await Task.Run(() =>
            {
                SaveNewEvent();
            });
        }

        private void SaveNewEvent()
        {
            SetVisibilityAndEnabled();
        }

        // Cancel event
        public ICommand CancelNewEventCommand
        {
            get
            {
                string commandName = "CancelNewEventCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.CancelNewEventExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void CancelNewEventExecute()
        {
            await Task.Run(() =>
            {
                CancelNewEvent();
            });
        }

        private void CancelNewEvent()
        {
            SetVisibilityAndEnabled();
        }

        #endregion

    }
}
