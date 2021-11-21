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

namespace LocalJudgingSystem
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        JudgeSystem judgeSystem;
        public LoginPage(JudgeSystem judgeSystem)
        {
            InitializeComponent();
            this.judgeSystem = judgeSystem;
        }

        private void OnClickLoginButton(object sender, RoutedEventArgs e)
        {
            var user = judgeSystem.login(UsernameBox.Text, PasswordBox.Password.ToString());
            if (user != null)
            {
                MainWindow MainWindowObj = (MainWindow)Window.GetWindow(this);
                switch (user.UserType)
                {
                    case "Admin":
                        MainWindowObj.MainFrame.Content = new AdminPage(judgeSystem);
                        break;
                    case "Student":
                        MainWindowObj.MainFrame.Content = new ProblemsListPage(judgeSystem);
                        break;
                    default:
                        break;
                }
                MainWindowObj.LoginButton.Visibility = Visibility.Collapsed;
                MainWindowObj.RegisterButton.Visibility = Visibility.Collapsed;
                MainWindowObj.LogoutButton.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Either User is not exist or Invalid Username or Invalid Password");
            }
        }
    }
}
