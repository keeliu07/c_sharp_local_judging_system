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
            problems.Add(new ProgramProblem("1","Test Problem 1", "Hi", 0, 30, 100));
            problems.Add(new ProgramProblem("2", "Test Problem 2", "Hi", 1, 50, 150));
            
            users = new List<User>();
            users.Add(new User("1", "admin", "admin"));
        }

        public void registerUser()
        {
            User newUser = new User();
        }

        public void login(string username, string password) {

        }

        public void logout() { 
            loginUser = null;
        }

        public List<ProgramProblem> browse_problem_list() {
            return problems;
        }

        public void browse_problem() { }
        public void browse_statistics() { }
        public void load_admin_page() { }

    }
}
