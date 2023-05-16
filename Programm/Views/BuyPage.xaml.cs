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
    /// Логика взаимодействия для BuyPage.xaml
    /// </summary>
    public partial class BuyPage : Page
    {
        public BuyPage()
        {
            InitializeComponent();

            // Получение информации о клиенте текущего пользователя
            var client = AppData.db.Client.FirstOrDefault(c => c.loginUserClient.Equals(AppData.currentUser.login));
            
            // Заполнение текстовых полей
            TxbFirstName.Text = client.firstName;
            TxbSecondName.Text = client.secondName;
            TxbLastName.Text = client.lastName;
            TxbPhoneNumber.Text = client.phoneNumber;
            TxbAddress.Text = client.adress;
            Loaded += SignUpPage_Loaded;

        }

        private void SignUpPage_Loaded(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Height = 500;
            Window.GetWindow(this).Width = 850;
        }


        private void BtnConfirmBuy_Click(object sender, RoutedEventArgs e)
        {
            
            using (var context = new samoylenkoBDEntities())
            {
                string typeOfClothing = typeOfClothingBox.Text;
                string decorFirst = decorFirstBox.Text;
                string decorSecond = decorSecondBox.Text;
                string decorThird = decorThirdBox.Text;
                int maxIdOrder = context.Order.Any() ? context.Order.Max(o => o.idOrder) : 0;

                context.Order.Add(new Order
                {
                    typeOfClothing = typeOfClothing,
                    decorFirst = decorFirst,
                    decorSecond = decorSecond,
                    decorThird = decorThird,
                    orderLogin = AppData.currentUser.login,
                    idOrder = maxIdOrder + 1
                });
                int result = context.SaveChanges();

                if (result > 0)
                {
                    MessageBox.Show("Вы успешно зарегистрированы!");
                }
                else
                {
                    MessageBox.Show("Что-то пошло не так. Попробуйте еще раз.");
                }
            }
        }

        private void BtnLeave_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WelcomePage());
        }


    } 
}
