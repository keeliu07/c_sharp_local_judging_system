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
        public User() { } // constructors
        public User(string ID, string name, string password) {
            this.ID = ID;
            this.name = name;
            this.password = password;
        }
        // runtime polymorphism

        public string UserType
        { // Data abstraction, read-only property
            get
            {
                if (usertype == 0) return "Admin";
                else if (usertype == 1) return "Student";
                return "Undefined";
            }
        }

        public virtual void edit_profile(string name, string password) { }
        public void submit_problem(string problemID) { }
        public void select_problem(string problemID) { }
        public void upload_program(string problemID) { }
    }

    public class Admin : User
    {
        public Admin() { } // constructor
        public override void edit_profile(string name, string password) { }
        void create_problem() { }
        void check_record() { }
        void view_statistics() { }
    }

    public class Student : User
    {
        public Student() { } // constructor
        public override void edit_profile(string name, string password) { }
    }
}
