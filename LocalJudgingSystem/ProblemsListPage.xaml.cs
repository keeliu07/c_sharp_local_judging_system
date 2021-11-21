﻿using System;
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
    /// Interaction logic for Problems.xaml
    /// </summary>
    public partial class ProblemsListPage : Page
    {
        public ProblemsListPage(JudgeSystem judgeSystem)
        {
            InitializeComponent();
            problemList.ItemsSource = judgeSystem.browse_problem_list();
        }

        private void problemList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProblemPage problemPage = new ProblemPage();
            NavigationService.Navigate(problemPage);
        }
    }
}
