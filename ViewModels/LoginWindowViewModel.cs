using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Enums;
using SportsTeamManagementApp.Extensions;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows;
using SportsTeamManagementApp.Models;
using System.Security.Cryptography;
using SportsTeamManagementApp.DbAction;
using System.Windows.Media;
using Microsoft.VisualBasic.Logging;

namespace SportsTeamManagementApp.ViewModels
{
    public class LoginWindowViewModel : BaseViewModel
    {
        private readonly LoginWindowView View;
        

        public LoginWindowViewModel(LoginWindowView view)
        {
            View = view;
            LoginData = new AccountInfoModel();
            RegistrationData = new AccountInfoModel();
            OnLoad();
        }

        private void OnLoad()
        {
            Roles = new ObservableCollection<string>()
            {
                EnumTools.GetDescription(UserCategoriesEnum.Player),
                EnumTools.GetDescription(UserCategoriesEnum.Coach)
            };

            WrongLoginTextVisibility = Visibility.Collapsed;
            WrongRegistrationTextVisibility = Visibility.Collapsed;
            LoginBorderColor = new SolidColorBrush(Colors.LightGray);
            RegistrationBorderColor = new SolidColorBrush(Colors.LightGray);
        }

        #region Properties 

        private AccountInfoModel _loginData;
        public AccountInfoModel LoginData
        {
            get { return _loginData; }
            set
            {
                if (_loginData != value)
                {
                    _loginData = value;
                    OnPropertyChanged();
                }
            }
        }

        private AccountInfoModel _registrationData;
        public AccountInfoModel RegistrationData
        {
            get { return _registrationData; }
            set
            {
                if (_registrationData != value)
                {
                    _registrationData = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _wrongLoginTextVisibility;
        public Visibility WrongLoginTextVisibility
        {
            get { return _wrongLoginTextVisibility; }
            set
            {
                if (_wrongLoginTextVisibility != value)
                {
                    _wrongLoginTextVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _wrongRegistrationTextVisibility;
        public Visibility WrongRegistrationTextVisibility
        {
            get { return _wrongRegistrationTextVisibility; }
            set
            {
                if (_wrongRegistrationTextVisibility != value)
                {
                    _wrongRegistrationTextVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _wrongRegistrationText;
        public string WrongRegistrationText
        {
            get { return _wrongRegistrationText; }
            set
            {
                if (_wrongRegistrationText != value)
                {
                    _wrongRegistrationText = value;
                    OnPropertyChanged();
                }
            }
        }

        private SolidColorBrush _loginBorderColor;
        public SolidColorBrush LoginBorderColor
        {
            get { return _loginBorderColor; }
            set
            {
                if (_loginBorderColor != value)
                {
                    _loginBorderColor = value;
                    OnPropertyChanged();
                }
            }
        }

        private SolidColorBrush _registrationBorderColor;
        public SolidColorBrush RegistrationBorderColor
        {
            get { return _registrationBorderColor; }
            set
            {
                if (_registrationBorderColor != value)
                {
                    _registrationBorderColor = value;
                    OnPropertyChanged();
                }
            }
        }


        #endregion


        #region Collectinos

        private ObservableCollection<string> _roles;
        public ObservableCollection<string> Roles
        {
            get { return _roles; }
            set
            {
                if (_roles != value)
                {
                    _roles = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion


        #region Operations

        public ICommand LogInCommand
        {
            get
            {
                string commandName = "LogInCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.LogInExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void LogInExecute()
        {
            if (LoginData.Login != null && LoginData.Password != null)
            {
                var logedUser = LoginAndRegisterDbAction.GetUserIdIfLoginAndPasswordAreCorrect(LoginData.Login, HashPassword(LoginData.Password));
                if (logedUser == null)
                {
                    LoginBorderColor = new SolidColorBrush(Colors.Red);
                    WrongLoginTextVisibility = Visibility.Visible;

                    return;
                }
                else
                {
                    LoginBorderColor = new SolidColorBrush(Colors.LightGray);
                    WrongLoginTextVisibility = Visibility.Collapsed;
                }
            }
            else
            {
                LoginBorderColor = new SolidColorBrush(Colors.Red);
                WrongLoginTextVisibility = Visibility.Visible;

                return;
            }

            await Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MainWindow newWindow = new MainWindow();
                    newWindow.Show();
                });

                Application.Current.Dispatcher.Invoke(() =>
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.DataContext == this)
                        {
                            window.Close();
                            break;
                        }
                    }
                });
            });


        }

        private string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedpassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedpassword);
        }


        public ICommand RegisterCommand
        {
            get
            {
                string commandName = "RegisterCommand";
                if (_relayCommands.TryGetValue(commandName, out RelayCommand command))
                {
                    return command;
                }
                command = new RelayCommand(param => this.RegisterExecute());
                return _relayCommands[commandName] = command;
            }

            set { }
        }

        private async void RegisterExecute()
        {
            await Task.Run(() =>
            {
                Register();
            });
        }

        private void Register()
        {
            if (!IsRegistrationLoginCorrect(RegistrationData.Login))
            {
                WrongRegistrationTextVisibility = Visibility.Visible;
                WrongRegistrationText = $"Login nie spełnia wymogów";
                return;
            }

            if (!IsRegistrationPasswordCorrect(RegistrationData.Password))
            {
                WrongRegistrationTextVisibility = Visibility.Visible;
                WrongRegistrationText = $"Hasło nie spełnia wymogów";
                return;
            }

            if (!IsRegistrationRoleOrCodeCorrect(RegistrationData.Role, RegistrationData.JoinCode))
            {
                WrongRegistrationTextVisibility = Visibility.Visible;
                WrongRegistrationText = $"Rola lub kod nie poprawny";
                return;
            }



            var salt = DateTime.Now.ToString();
            var hashedPW = HashPassword(RegistrationData.Password);

            LoginAndRegisterDbAction.AddUser(RegistrationData.Login, $"{hashedPW}{salt}", RegistrationData.Role, RegistrationData.JoinCode, salt);

            WrongRegistrationTextVisibility = Visibility.Collapsed;
            WrongRegistrationText = String.Empty;



            RegistrationData = new AccountInfoModel();

            // koniec na 24 minucie

        }

        private bool IsRegistrationLoginCorrect(string login)
        {
            if (login is null || login.Count() <= 4)
            {
                return false;
            }

            return true;
        }


        private bool IsRegistrationPasswordCorrect(string password)
        {
            if (password is null || password.Count() <= 6 || password.Count() > 15 || !password.Any(char.IsDigit))
            {
                return false;
            }           

            return true;
        }

        private bool IsRegistrationRoleOrCodeCorrect(string role, string code)
        {
            if (role is null || code is null || code.Count() != 9)
            {
                return false;
            }

            return true;
        }


        #endregion

    }
}
