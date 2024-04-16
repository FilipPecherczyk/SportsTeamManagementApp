﻿using SportsTeamManagementApp.Common;
using SportsTeamManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly HomeView View;

        public HomeViewModel(HomeView view)
        {
            View = view;
        }
    }
}