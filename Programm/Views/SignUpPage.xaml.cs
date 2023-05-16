using Programm.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
            Loaded += SignUpPage_Loaded;
        }

        private void SignUpPage_Loaded(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Height = 800;
        }


        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new samoylenkoBDEntities())
            {
                string username = usernameBox.Text;
                string password = passwordBox.Password;
                string firstName = firstNameBox.Text;
                string secondName = secondNameBox.Text;
                string lastName = lastNameBox.Text;
                string phoneNumber = phoneNumberBox.Text;
                string adress = adressBox.Text;

                context.User.Add(new User
                {
                    login = username,
                    password = password,
                    idUserType = "User"
                });
                int maxIdClient = context.Client.Any() ? context.Client.Max(o => o.idClient) : 0;
                context.Client.Add(new Client
                {
                    firstName = firstName,
                    secondName = secondName,
                    lastName = lastName,
                    phoneNumber = phoneNumber,
                    adress = adress,
                    loginUserClient = username,
                    idClient = maxIdClient + 1

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

        private void BtnToSignIn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignInPage());
        }
    }
}
