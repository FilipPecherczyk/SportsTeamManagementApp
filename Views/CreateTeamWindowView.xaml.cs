using SportsTeamManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SportsTeamManagementApp.Views
{
    /// <summary>
    /// Interaction logic for CreateTeamWindowView.xaml
    /// </summary>
    public partial class CreateTeamWindowView : Window
    {
        public CreateTeamWindowView()
        {
            InitializeComponent();
            var model = new CreateTeamWindowViewModel(this);
            this.DataContext = model;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow((Button)sender);

            if (window != null)
            {
                window.Close();
            }
        }
    }
}
