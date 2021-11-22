using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.IO;

namespace LocalJudgingSystem.src
{
    public class ProgramProblem
    {
        protected string ID, title, content;
        protected User author;
        protected int trial, accepted, difficulty, timeLimit, memoryLimit;
        protected double acRate, tags;
        protected bool isLive;
        protected List<TestCase> testCases;

        public ProgramProblem(string ID, string title, string content, User author, List<TestCase> testCases, int difficulty,
        int timeLimit, int memoryLimit) {
            this.ID = ID;
            this.title = title;
            this.content = content;
            this.difficulty = difficulty;
            this.timeLimit = timeLimit;
            this.memoryLimit = memoryLimit;
            this.testCases = testCases;
            this.author = author;
            trial = 0;
            accepted = 0;
            isLive = true;
        } // constructors
        public ProgramProblem(string filename) { }

        public string ProblemID { get { return ID; } } // read-only property
        public string Title { get {return title;} } // read-only property
        public string Content { get { return content; } } // read-only property
        public User Author { get { return author; } } // read-only property
        public string Difficulty
        { // Data abstraction, read-only property
            get
            {
                if (difficulty == 0) return "Easy";
                else if (difficulty == 1) return "Moderate";
                else if (difficulty == 2) return "Difficult";
                return "";
            }
        }
        public double TimeLimit
        { // Data abstraction, read-only property
            get { return timeLimit / 1000; } // ms to sec
        }
        public double MemoryLimit
        { // Data abstraction, read-only property
            get { return memoryLimit / 1000000; } // Byte to MB
        }
        public double ACRate
        { // read-only property
            get { 
                if(trial == 0) return 0.0;
                System.Diagnostics.Debug.WriteLine(accepted);
                System.Diagnostics.Debug.WriteLine(trial);
                return (double) accepted / (double)trial; }
        }
        public int Trial
        { // read-only property
            get { return trial; }
        }

        public int Accepted
        { // read-only property
            get { return accepted; }
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        public void Send(Key key)
        {
            if (Keyboard.PrimaryDevice != null)
            {
                if (Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var e1 = new System.Windows.Input.KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, key) { RoutedEvent = Keyboard.KeyDownEvent };
                    bool b = InputManager.Current.ProcessInput(e1);
                }
            }
        }

        public async void turnCodeintoFile(ProgramProblem problem, string code)
        {
            await File.WriteAllTextAsync(string.Format("E:\\problem{0}.c", problem.ProblemID), code);
        }

        public (string, Boolean) compileAndExecute(ProgramProblem problem, string code)
        {
            turnCodeintoFile(problem, code);
            Process proc = new Process();
            proc.StartInfo.FileName = "E:\\CodeBlocks\\MinGW\\bin\\mingw32-gcc-5.1.0.exe";
            proc.StartInfo.Arguments = string.Format("E:\\problem{0}.c -o E:\\problem{0}", problem.ProblemID);
            proc.StartInfo.RedirectStandardError = true;
            proc.Start();
            string output = proc.StandardError.ReadToEnd();
            System.Diagnostics.Debug.WriteLine(output);
            Boolean pass = false;
            if (output.Length == 0)
            {
                (output, pass) =  execute(problem);
            }
            return (output, pass);
        }

        public (string, Boolean) execute(ProgramProblem problem)
        {
            Boolean pass = true;
            string terminal = "";
            foreach (var testcase in testCases){
                Process proc2 = new Process();
                proc2.StartInfo.FileName = string.Format("E:\\problem{0}.exe", problem.ProblemID);
                proc2.StartInfo.RedirectStandardOutput = true;
                proc2.StartInfo.RedirectStandardInput = true;
                proc2.Start();
                if (testcase.TestInput != "")
                {
                    proc2.StandardInput.WriteLine(testcase.TestInput);
                    proc2.StandardInput.WriteLine(Environment.NewLine);
                    while (proc2.StandardOutput.Peek() > -1)
                    {
                        //System.Diagnostics.Debug.WriteLine((char)proc2.StandardOutput.Read());
                        proc2.StandardOutput.Read();
                        if (proc2.StandardOutput.Peek() == ':')
                        {
                            //System.Diagnostics.Debug.WriteLine((char)proc2.StandardOutput.Read());
                            proc2.StandardOutput.Read();
                            break;
                        }
                    }
                }
                string result = proc2.StandardOutput.ReadLine();
                terminal += result + "\n";
                if (result != testcase.TestOutput)
                { 
                    pass = false;
                }
            }
            return (terminal, pass);
        }

        // compile time polymorphism
        public void edit_problem(string title) {
            this.title = title;
        }
        public void edit_problem(string title, string content) {
            this.title = title;
            this.content = content;
        }
        public void edit_problem(string title, string content, int difficulty,
        int timeLimit, int memoryLimit)
        {
            this.title = title;
            this.content = content;
            this.difficulty = difficulty;
            this.timeLimit = timeLimit;
            this.memoryLimit = memoryLimit;
        }

        public void edit_statistics(int trial, int accepted) {
            this.trial = trial;
        }
        public void add_trial()
        {
            trial++;
        }

        public void add_accepted()
        {
            accepted++;
        }

        public List<TestCase> browse_test_cases()
        {
            return testCases;
        }
    }

}

