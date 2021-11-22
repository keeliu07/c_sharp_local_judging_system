using LocalJudgingSystem.src;
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
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        JudgeSystem judgeSystem;
        public AdminPage(JudgeSystem judgeSystem)
        {
            InitializeComponent();
            this.judgeSystem = judgeSystem;
            AdminProblemList.ItemsSource = judgeSystem.browse_problem_list();
            MainWindow MainWindowObj = (MainWindow)Window.GetWindow(this);
        }

        private void onClickEditButton(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            int index = AdminProblemList.Items.IndexOf(item);
            ProgramProblem selectedProblem = judgeSystem.browse_problem(index);
            ProblemDetailsFormPage problemDetailsFormPage = new ProblemDetailsFormPage(judgeSystem, selectedProblem);
            NavigationService.Navigate(problemDetailsFormPage);
        }
    }
}
