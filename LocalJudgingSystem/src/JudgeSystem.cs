using LocalJudgingSystem.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalJudgingSystem
{
    public class JudgeSystem
    {
        protected List<ProgramProblem> problems;
        protected List<User> users;
        protected User? loginUser;
        public User? LoginUser { get { return loginUser; } } // read-only property
        
        public JudgeSystem()
        {
            initialization();
        } // constructor
        private void initialization() {
            problems = new List<ProgramProblem>();
            List<TestCase> testCases = new List<TestCase>() ;
            testCases.Add(new TestCase("N/A", "Hello World"));
            problems.Add(new ProgramProblem("1", "Print Hello World", "Output text \"Hello World\" ", testCases, 0, 30, 100));
            
            testCases = new List<TestCase>();
            testCases.Add(new TestCase( "3", "Prime"));
            testCases.Add(new TestCase("2", "Not Prime"));
            problems.Add(new ProgramProblem("2", "Is Prime Number", "Check if an integer is a prime number", testCases, 1, 50, 150));
            
            users = new List<User>();
            users.Add(new Admin("1", "Admin", "Admin", 1));
            users.Add(new Student("2", "ChanSiuMing", "20000101", 2));
            users.Add(new Student("3", "ChanTaiMing", "asdfghjkl;’", 2));
            users.Add(new Student("4", "CatChu", "catcatcat", 2));
        }

        private User? createUser(string username, string password, int usertype)
        {
            int user_id = users.Count + 1;
            User? newUser = null;
            switch (usertype)
            {
                case 1:
                    newUser = new Admin(user_id.ToString(), username, password, usertype);
                    break;
                case 2:
                    newUser = new Student(user_id.ToString(), username, password, usertype);
                    break;
                default:
                    break;
            }
            return newUser;
        }

        public void registerUser(string username, string password, int usertype)
        {
            User? newUser = createUser(username, password, usertype);
            if (newUser != null)
            {
                users.Add(newUser);
            }
        }

        public User? login(string username, string password) {
            User? target = users.Find(x => x.Username == username && x.Password == password);
            if (target != null)
            {
                System.Diagnostics.Debug.WriteLine("Login as {0}", username);
                loginUser = target;
            }
            return target;
        }

        public void logout() { 
            loginUser = null;
        }

        public void add_problem(string title, string content, List<TestCase> testCases, int difficulty,
        int timeLimit, int memoryLimit)
        {
            int problemId = problems.Count + 1;
            problems.Add(new ProgramProblem(problemId.ToString(), title, content, testCases, difficulty, timeLimit, memoryLimit));
        }

        public List<ProgramProblem> browse_problem_list() {
            return problems;
        }

        public ProgramProblem browse_problem(int index) {
            return problems[index];
        }
        public void browse_statistics() { }

    }
}
