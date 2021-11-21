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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        JudgeSystem judgeSystem;
        public RegisterPage(JudgeSystem judgeSystem)
        {
            InitializeComponent();
            this.judgeSystem = judgeSystem;
        }

        private void OnClickRegisterButton(object sender, RoutedEventArgs e)
        {
            int usertype = 0;
            switch (UsertypeBox.Text)
            {
                case "Teacher/TA":
                    usertype = 1;
                    break;
                case "Student":
                    usertype = 2;
                    break;
            }
            judgeSystem.registerUser(UsernameBox.Text, PasswordBox.Password.ToString(), usertype);
            MainWindow MainWindowObj = (MainWindow)Window.GetWindow(this);
            MainWindowObj.MainFrame.Content = new LoginPage(judgeSystem);
        }
    }
}
