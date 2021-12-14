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

using DLL.Models;

using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Movie.View;

namespace Movie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void employeeAction_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new EmployeePage();
        }

        private void cinemaHallAction_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new CinemaHallPage();
        }

        private void sessionAction_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new SessionPage();
        }

        private void titcketAction_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new TicketPage();
        }

        private void filmAction_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new FilmPage();
        }

        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            //GridBackground.ContextMenu.IsEnabled = false;
        }
    }
}
