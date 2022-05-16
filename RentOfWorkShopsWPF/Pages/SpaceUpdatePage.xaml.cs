using Microsoft.Win32;
using RentOfWorkshopsCore.DBConnection;
using RentOfWorkshopsCore.DBContext;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для SpaceUpdatePage.xaml
    /// </summary>
    public partial class SpaceUpdatePage : Page
    {
        private Space _space;

        public SpaceUpdatePage()
        {
            InitializeComponent();
        }

        public SpaceUpdatePage(Space space)
        {
            InitializeComponent();
            if(space != null)
            {
                _space = SQLConnection.AttachSpace(space);
            }
        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.jpg|*.jpg|*.png|*.png"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                _space.Picture = File.ReadAllBytes(openFileDialog.FileName);
                SpaceImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SQLConnection.Save();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            this.NavigationService.GoBack();
        }
    }
}
