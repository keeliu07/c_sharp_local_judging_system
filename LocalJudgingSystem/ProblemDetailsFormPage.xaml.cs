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
    /// Interaction logic for ProblemDetailsFormPage.xaml
    /// </summary>
    public partial class ProblemDetailsFormPage : Page
    {
        JudgeSystem judgeSystem;
        ProgramProblem problem;
        Boolean isCreation = false;
        List<TestCase> testCases;
        public ProblemDetailsFormPage(JudgeSystem judgeSystem)
        {
            InitializeComponent();
            this.judgeSystem = judgeSystem;
            TitleBox.Text = "Create Problem";
            testCases = new List<TestCase>();
            TestCaseList.ItemsSource = testCases;
            isCreation = true;
        }
        public ProblemDetailsFormPage(JudgeSystem judgeSystem, ProgramProblem problem)
        {
            InitializeComponent();
            this.judgeSystem = judgeSystem;
            this.problem = problem;
            testCases = problem.browse_test_cases();
            TestCaseList.ItemsSource = testCases;
            title.Text = problem.Title;
            content.Text = problem.Content;
            difficulty.Text = problem.Difficulty;
            timelimit.Text = problem.TimeLimit.ToString();
            memorylimit.Text = problem.MemoryLimit.ToString();
        }

        private void onClickSubmitButton(object sender, RoutedEventArgs e)
        {
            int diff = 0;
            switch (difficulty.Text)
            {
                case "Easy":
                    diff = 0;
                    break;
                case "Moderate":
                    diff = 1;
                    break;
                case "Hard":
                    diff = 2;
                    break;
            }
            MainWindow MainWindowObj = (MainWindow)Window.GetWindow(this);
            if (!isCreation && int.TryParse(timelimit.Text, out int time) && int.TryParse(memorylimit.Text, out int memory))
            {
                problem.edit_problem(title.Text, content.Text, diff, time, memory);
                MainWindowObj.MainFrame.Content = new AdminPage(judgeSystem);
            }
            else if (isCreation && int.TryParse(timelimit.Text, out int time2) && int.TryParse(memorylimit.Text, out int memory2))
            {
                User? user = judgeSystem.LoginUser;
                if (user != null && user.UserType == "Admin")
                {
                    Admin? admin = user as Admin;
                    if (admin != null){
                        int problemId = judgeSystem.browse_problem_list().Count + 1;
                        ProgramProblem problem = admin.create_problem(problemId.ToString(), title.Text, content.Text, admin, testCases, diff, time2, memory2);
                        judgeSystem.add_problem(problem);
                    }
                }
                MainWindowObj.MainFrame.Content = new AdminPage(judgeSystem);
            }
            else
            {
                MessageBox.Show("Diffculty and TimeLimit and MemoryLimit must be integers.");
            }
        }

        private void onClickAddTestCase(object sender, RoutedEventArgs e)
        {
            if (TestInputBox != null && TestOutputBox != null)
            {
                testCases.Add(new TestCase(TestInputBox.Text, TestOutputBox.Text));
                TestCaseList.Items.Refresh();
                TestInputBox.Text = "";
                TestOutputBox.Text = "";
            }
        }

        private void onClickEditTestCase(object sender, RoutedEventArgs e)
        {
            testCases[TestCaseList.SelectedIndex].edit_testcase(TestInputBox.Text, TestOutputBox.Text);
            TestCaseList.Items.Refresh();
        }
        private void onClickDeleteTestCase(object sender, RoutedEventArgs e)
        {
            testCases.RemoveAt(TestCaseList.SelectedIndex);
            TestCaseList.Items.Refresh();
        }
    }
}
