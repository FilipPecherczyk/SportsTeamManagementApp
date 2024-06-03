using SportsTeamManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportsTeamManagementApp.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            var model = new HomeViewModel(this);
            this.DataContext = model;
        }

        private void OnlyNumbers_Tb(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+$");

            TextBox textBox = sender as TextBox;

            if (!regex.IsMatch(e.Text) || textBox.Text.Length >= 3)
            {
                e.Handled = true;
            }

        }
    }
}
