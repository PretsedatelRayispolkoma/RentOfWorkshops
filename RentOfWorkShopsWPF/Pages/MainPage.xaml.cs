using RentOfWorkshopsCore.DBConnection;
using RentOfWorkshopsCore.DBContext;
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

namespace RentOfWorkShopsWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SpacesLv_Loaded(object sender, RoutedEventArgs e)
        {
            SpacesLv.ItemsSource = SQLConnection.GetAllSpaces().Where(p => p.StatusId == 1);
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedSpace = SpacesLv.SelectedItem as Space;
            NavigationService.Navigate(new SpaceUpdatePage(selectedSpace));
        }
    }
}
