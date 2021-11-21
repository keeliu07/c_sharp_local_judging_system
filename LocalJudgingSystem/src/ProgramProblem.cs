using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalJudgingSystem.src
{
    public class ProgramProblem
    {
        protected string ID, title, content, author, test_input, test_output;
        protected int trial, accepted, difficulty, timeLimit, memoryLimit;
        protected double acRate, tags;
        protected bool isLive;

        public ProgramProblem(string ID, string title, string content, int difficulty,
        int timeLimit, int memoryLimit) {
            this.ID = ID;
            this.title = title;
            this.content = content;
            this.difficulty = difficulty;
            this.timeLimit = timeLimit;
            this.memoryLimit = memoryLimit;
            trial = 0;
            accepted = 0;
            isLive = true;
        } // constructors
        public ProgramProblem(string filename) { }
        public string Title { get {return title;} } // read-only property
        public string Content { get { return content; } } // read-only property
        public string Author { get { return author; } } // read-only property
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
            get { return acRate; }
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
        public void edit_testcases(string test_input, string test_output) {
            this.test_input = test_input;
            this.test_output = test_output;
        }
        public void edit_statistics(int trial, int accepted) {
            this.trial = trial;

        }
    }

}

