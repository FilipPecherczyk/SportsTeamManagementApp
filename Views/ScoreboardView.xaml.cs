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
    /// Interaction logic for ScoreboardView.xaml
    /// </summary>
    public partial class ScoreboardView : UserControl
    {
        public ScoreboardView()
        {
            InitializeComponent();
            var model = new ScoreboardViewModel(this);
            this.DataContext = model;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[+-]?\d*(\.\d*)?$");

            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
    }
}
