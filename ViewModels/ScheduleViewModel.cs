using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.DbAction;
using SportsTeamManagementApp.Entities;
using SportsTeamManagementApp.Enums;
using SportsTeamManagementApp.Extensions;
using SportsTeamManagementApp.Mappings;
using SportsTeamManagementApp.Models;
using SportsTeamManagementApp.Models.GridPagerModels;
using SportsTeamManagementApp.Models.SearchCriteria;
using SportsTeamManagementApp.STMApp;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
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
            EventPanelData.PropertyChanged += EventPanelData_PropertyChanged;
            NewEventModel = new CalendarEventModel();
            NewEventModel.PropertyChanged += NewEventModel_PropertyChanged;

            OnLoad();
        }



        private void OnLoad()
        {
            EventPanelData.TitleData = DateTime.Today;

            EventTitles = new ObservableCollection<string>()
            {
                EnumTools.GetDescription(EventNameTypeEnum.Game),
                EnumTools.GetDescription(EventNameTypeEnum.Training),
                EnumTools.GetDescription(EventNameTypeEnum.Other)
            };

            EventTimeHour = new ObservableCollection<string>();
            for (int i = 0; i <= 24; i++)
            {
                EventTimeHour.Add(i.ToString("00"));
            }

            EventTimeMinute = new ObservableCollection<string>();
            for (int i = 0; i <= 60; i++)
            {
                EventTimeMinute.Add(i.ToString("00"));
            }

            SetVisibilityAndEnabled();
        }

        private void EventPanelData_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ScheduleItemsControlModel.TitleData))
            {
                var eventDomainList = EventDbAction.GetEventsByDate(EventPanelData.TitleData);
                EventPanelData.Events = Mapping.EventDomainListToCalendarEventModelObservableCollection(eventDomainList);
            }
        }

        private void NewEventModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CalendarEventModel.Type))
            {
                if (NewEventModel.Type.Equals(EnumTools.GetDescription(EventNameTypeEnum.Other)))
                {
                    OtherEventTitleNameTBVisibility = Visibility.Visible;
                }
                else
                {
                    OtherEventTitleNameTBVisibility = Visibility.Collapsed;
                }

                if (NewEventModel.Type.Equals(EnumTools.GetDescription(EventNameTypeEnum.Game)))
                {
                    GameDetailsVisibility = Visibility.Visible;
                }
                else
                {
                    GameDetailsVisibility = Visibility.Collapsed;
                }
            }
        }

        private void SetVisibilityAndEnabled()
        {
            CalendarEventPanelVisibility = Visibility.Visible;
            CreateNewEventPanelVisibility = Visibility.Hidden;
            CalendarEnabled = true;
            SaveCancelNewEventBtnVisibility = Visibility.Hidden;
            OtherEventTitleNameTBVisibility = Visibility.Collapsed;
            GameDetailsVisibility = Visibility.Collapsed;

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

        private ObservableCollection<string> _eventTitles;
        public ObservableCollection<string> EventTitles
        {
            get { return _eventTitles; }
            set
            {
                if (_eventTitles != value)
                {
                    _eventTitles = value;
                    OnPropertyChanged();
                }
            }

        }

        private ObservableCollection<string> _eventTimeHour;
        public ObservableCollection<string> EventTimeHour
        {
            get { return _eventTimeHour; }
            set
            {
                if (_eventTimeHour != value)
                {
                    _eventTimeHour = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<string> _eventTimeMinute;
        public ObservableCollection<string> EventTimeMinute
        {
            get { return _eventTimeMinute; }
            set
            {
                if (_eventTimeMinute != value)
                {
                    _eventTimeMinute = value;
                    OnPropertyChanged();
                }
            }
        }

        #region Visibility && Enabled

        private Visibility _otherEventTitleNameTBVisibility;
        public Visibility OtherEventTitleNameTBVisibility
        {
            get { return _otherEventTitleNameTBVisibility; }
            set
            {
                if (_otherEventTitleNameTBVisibility != value)
                {
                    _otherEventTitleNameTBVisibility = value;
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

        private Visibility _gameDetailsVisibility;
        public Visibility GameDetailsVisibility
        {
            get { return _gameDetailsVisibility; }
            set
            {
                if (_gameDetailsVisibility != value)
                {
                    _gameDetailsVisibility = value;
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
            NewEventModel.Date = EventPanelData.TitleDataDisplay;
            NewEventModel.Name = "";
            NewEventModel.Opponent = "";
            NewEventModel.IsHomeGame = true;
            NewEventModel.Type = EnumTools.GetDescription(EventNameTypeEnum.Game);
            NewEventModel.TimeHour = DateTime.Now.Hour.ToString();
            NewEventModel.TimeMinute = DateTime.Now.Minute.ToString();

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
            if (NewEventModel.Type.Equals(EnumTools.GetDescription(EventNameTypeEnum.Other)) && String.IsNullOrWhiteSpace(NewEventModel.Name))
            {
                System.Windows.MessageBox.Show(
                    "Uzupełnij tytuł wydarzenia.",
                    "Powiadomienie",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }
            if (NewEventModel.Type.Equals(EnumTools.GetDescription(EventNameTypeEnum.Game)) && String.IsNullOrWhiteSpace(NewEventModel.Opponent))
            {
                System.Windows.MessageBox.Show(
                    "Uzupełnij nazwę przeciwnika.",
                    "Powiadomienie",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }


            if (NewEventModel.Type == EnumTools.GetDescription(EventNameTypeEnum.Game))
            {
                var eventM = CreateEventDomain(NewEventModel);
                var eventModel2 = CreateGameDomain(NewEventModel);

                EventDbAction.AddEventWithGame(eventM, eventModel2);
            }
            else
            {
                var model = CreateEventDomain(NewEventModel);
                EventDbAction.AddEvent(model);
            }

            SetVisibilityAndEnabled();
        }

        private EventDomain CreateEventDomain(CalendarEventModel calendarModel)
        {
            var finalModel = new EventDomain();

            finalModel.TeamId = STMAppMainData.LogedUserTeam.Id;
            finalModel.Date = DateTime.ParseExact(calendarModel.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            finalModel.Time = $"{calendarModel.TimeHour}:{calendarModel.TimeMinute}";
            finalModel.Title = calendarModel.Type != EnumTools.GetDescription(EventNameTypeEnum.Other) ? calendarModel.Type : calendarModel.Name;

            return finalModel;
        }

        private GameDomain CreateGameDomain(CalendarEventModel calendarModel)
        {
            var finalModel = new GameDomain();

            finalModel.Opponent = calendarModel.Opponent;
            finalModel.IsHomeGame = calendarModel.IsHomeGame;

            return finalModel;
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
