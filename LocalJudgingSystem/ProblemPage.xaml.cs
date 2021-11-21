﻿using LocalJudgingSystem.src;
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
    /// Interaction logic for ProblemPage.xaml
    /// </summary>
    public partial class ProblemPage : Page
    {
        ProgramProblem problem;
        public ProblemPage(ProgramProblem problem)
        {
            InitializeComponent();
            this.problem = problem;
        }
    }
}
