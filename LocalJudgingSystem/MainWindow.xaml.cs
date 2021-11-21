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
using LocalJudgingSystem.src;

namespace LocalJudgingSystem
{
    public partial class MainWindow : Window
    {
        JudgeSystem judgeSystem = new JudgeSystem();
        ProblemsListPage problemsListPage;
        MainWindow MainWindowObj;
        public MainWindow()
        {
            InitializeComponent();
            MainWindowObj = (MainWindow)Window.GetWindow(this);
            MainWindowObj.LogoutButton.Visibility = Visibility.Collapsed;
            problemsListPage = new ProblemsListPage(judgeSystem);
            MainFrame.Content = problemsListPage;
        }

        void OnClickLogin(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new LoginPage(judgeSystem);
        }

        void OnClickLogout(object sender, RoutedEventArgs e)
        {
            judgeSystem.logout();
            MainFrame.Content = new ProblemsListPage(judgeSystem);
            MainWindowObj.LoginButton.Visibility = Visibility.Visible;
            MainWindowObj.RegisterButton.Visibility = Visibility.Visible;
            MainWindowObj.LogoutButton.Visibility = Visibility.Collapsed;
        }

        void OnClickRegister(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new RegisterPage(judgeSystem);
        }

        void OnClickProblems(object sender, RoutedEventArgs e)
        {
            if (judgeSystem.LoginUser != null && judgeSystem.LoginUser.UserType == "Admin")
            {
                MainFrame.Content = new AdminPage(judgeSystem);
            }
            else
            {
                MainFrame.Content = problemsListPage;
            }
        }
    }
}
