using SportsTeamManagementApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Models
{
    public class UserModel : BaseModel
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _salt;
        public string Salt
        {
            get { return _salt; }
            set
            {
                if (_salt != value)
                {
                    _salt = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _role;
        public string Role
        {
            get { return _role; }
            set
            {
                if (_role != value)
                {
                    _role = value;
                    OnPropertyChanged();
                }
            }
        }

        private string? _name;
        public string? Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string? _lastName;
        public string? LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime? _birthday;
        public DateTime? Birthday
        {
            get { return _birthday; }
            set
            {
                if (_birthday != value)
                {
                    _birthday = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _joinDate;
        public DateTime JoinDate
        {
            get { return _joinDate; }
            set
            {
                if (_joinDate != value)
                {
                    _joinDate = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
