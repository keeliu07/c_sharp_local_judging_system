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
            users.Add(new User("1", "admin", "admin", 1));
        }

        public void registerUser(string username, string password, int usertype)
        {
            int user_id = users.Count + 1;
            User? newUser = null;
            switch (usertype)
            {
                case 1: newUser = new Admin(user_id.ToString(), username, password, usertype);
                        break;
                case 2: newUser = new Student(user_id.ToString(), username, password, usertype);
                        break;
                default:
                    break;
            }
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

        public List<ProgramProblem> browse_problem_list() {
            return problems;
        }

        public void browse_problem() { }
        public void browse_statistics() { }
        public void load_admin_page() { }

    }
}
