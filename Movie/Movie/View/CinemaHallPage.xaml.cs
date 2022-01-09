using Movie.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Movie.View
{
    /// <summary>
    /// Interaction logic for CinemaHallPage.xaml
    /// </summary>
    public partial class CinemaHallPage : Page
    {
        public CinemaHallPage(CinemaHallViewModel cinemaHallViewModel)
        {
            InitializeComponent();
            this.DataContext = cinemaHallViewModel;
        }
    }
}
