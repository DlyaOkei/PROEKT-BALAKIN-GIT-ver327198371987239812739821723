using Programm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace Programm.Views
{
    /// <summary>
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        private readonly samoylenkoBDEntities dbContext = AppData.db;

        public WelcomePage()
        {
            InitializeComponent();
            Loaded += SignUpPage_Loaded;
        }

        private void SignUpPage_Loaded(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Height = 800;
            Window.GetWindow(this).Width = 1200;
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

                NavigationService.Navigate(new SignInPage());
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BuyPage());
        }
    }
}
