using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalJudgingSystem.src
{
    public class User
    {
        protected string ID, name, password;
        protected int usertype;
        protected List<ProgramProblem> submitted_problems;

        public User() { }
        public User(string ID, string name, string password, int usertype) {
            this.ID = ID;
            this.name = name;
            this.password = password;
            this.usertype = usertype;
            submitted_problems = new List<ProgramProblem>();
        }
        // runtime polymorphism
        public string Username { get { return name; } }
        public string Password { get { return password; } }
        public string UserType
        { // Data abstraction, read-only property
            get
            {
                if (usertype == 1) return "Admin";
                else if (usertype == 2) return "Student";
                return "Undefined";
            }
        }

        public virtual void edit_profile(string name, string password) { }
        public void submit_problem(ProgramProblem problem) {
            submitted_problems.Add(problem);
        }
        public void select_problem(string problemID) { }
        public void upload_program(string problemID) { }
    }

    public class Admin : User
    {
        public Admin(string ID, string name, string password, int usertype) : base(ID, name, password, usertype){ } // constructor
        public override void edit_profile(string name, string password) { }
        void create_problem() { }
        void check_record() { }
        void view_statistics() { }
    }

    public class Student : User
    {
        public Student(string ID, string name, string password, int usertype) : base(ID, name, password, usertype) { } // constructor
        public override void edit_profile(string name, string password) { }
    }
}
