using Programm.Model;
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

namespace Programm.Views
{
    /// <summary>
    /// Логика взаимодействия для OrderViewPage.xaml
    /// </summary>
    public partial class OrderViewPage : Page
    {
        public OrderViewPage()
        {
            InitializeComponent();
            Loaded += OrdersPage_Loaded;
        }
        private void OrdersPage_Loaded(object sender, RoutedEventArgs e)
        {
            var orderData = from o in AppData.db.Order
                            join u in AppData.db.User on o.orderLogin equals u.login
                            select new
                            {
                                o.idOrder,
                                o.decorFirst,
                                o.decorSecond,
                                o.decorThird,
                                o.typeOfClothing,
                                o.orderLogin,
                                u.UserType.nameUserType,
                            };
            var clientData = from c in AppData.db.Client
                             join u in AppData.db.User on c.loginUserClient equals u.login
                             select new
                             {
                                 c.firstName,
                                 c.secondName,
                                 c.lastName,
                                 c.phoneNumber,
                                 c.adress,
                                 c.loginUserClient,
                                 u.UserType.nameUserType,
                             };

            var combinedData = from o in orderData
                               join c in clientData on o.orderLogin equals c.loginUserClient
                               select new
                               {
                                   o.idOrder,
                                   o.decorFirst,
                                   o.decorSecond,
                                   o.decorThird,
                                   o.typeOfClothing,
                                   c.firstName,
                                   c.secondName,
                                   c.lastName,
                                   c.phoneNumber,
                                   c.adress,
                                   o.orderLogin,
                                   o.nameUserType,
                               };

            OrdersGrid.ItemsSource = combinedData.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
