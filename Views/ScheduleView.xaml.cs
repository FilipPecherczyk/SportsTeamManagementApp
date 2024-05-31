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
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        public ScheduleView()
        {
            InitializeComponent();
            var model = new ScheduleViewModel(this);
            this.DataContext = model;
        }

        private void NameToAnotherType_Tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            Regex regex = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regex.IsMatch(e.Text) || textBox.Text.Length + e.Text.Length > 16)
            {
                e.Handled = true;
            }
        }

        private void OpponentName_Tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            Regex regex = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regex.IsMatch(e.Text) || textBox.Text.Length + e.Text.Length >= 20)
            {
                e.Handled = true;
            }
        }
    }
}
