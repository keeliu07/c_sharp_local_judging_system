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
    /// Interaction logic for UserProfilePage.xaml
    /// </summary>
    public partial class UserProfilePage : Page
    {
        JudgeSystem judgeSystem;

        public UserProfilePage(JudgeSystem judgeSystem)
        {
            InitializeComponent();
            this.judgeSystem = judgeSystem;
            username.Text = judgeSystem.LoginUser.Username;
            SubmittedProblemList.ItemsSource = judgeSystem.LoginUser.SubmittedProblems;
        }
    }
}
