using LocalJudgingSystem.src;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ProblemPage.xaml
    /// </summary>
    public partial class ProblemPage : Page
    {
        ProgramProblem problem;
        JudgeSystem judgeSystem;
        public ProblemPage(JudgeSystem judgeSystem, ProgramProblem problem)
        {
            InitializeComponent();
            this.judgeSystem = judgeSystem;
            this.problem = problem;
        }
        private void onSubmitProblem(object sender, RoutedEventArgs e)
        {
            User? user = judgeSystem.LoginUser;
            if (user != null)
            {
                user.submit_problem(problem);
                (string output, Boolean pass) = problem.compileAndExecute(problem, CodeEditor.Text);
                TestResultBox.Text = string.Format("Pass or Not: {0}\n", pass);
                Terminal.Text = output;
            }
        }
        private void onUploadFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select a File";
            if(dialog.ShowDialog() == true)
            {
                string text = System.IO.File.ReadAllText(@dialog.FileName);
                CodeEditor.Text = text;
            }
        }

    }
}
