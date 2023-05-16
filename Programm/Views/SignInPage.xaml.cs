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
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
            Loaded += SignInPage_Loaded;
        }
        private void SignInPage_Loaded(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Height = 450;
            Window.GetWindow(this).Width = 800;
        }
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = AppData.db.User.FirstOrDefault(u => u.login.Equals(TxbLogin.Text) && u.password.Equals(TxbPassword.Text));

            if (currentUser != null)
            {
                UserType userType = AppData.db.UserType.FirstOrDefault(w => w.idUserType == currentUser.idUserType);
                if (userType.idUserType.Equals("Admin"))
                {
                    NavigationService.Navigate(new DataPage());
                }
                else
                {
                    // Сохранение текущего пользователя в приложении
                    AppData.currentUser = currentUser;

                    // Переход на страницу WelcomePage
                    NavigationService.Navigate(new WelcomePage());
                }
            }
            else
            {
                MessageBox.Show("Данного пользователя не существует", "Ошибка");
            }
        }

        private void BtnToSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUpPage());
        }
    }

}
