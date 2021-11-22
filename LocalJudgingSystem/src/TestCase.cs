using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalJudgingSystem.src
{
    public class TestCase
    {
        protected string testInput, testOutput;

        public TestCase(string testInput, string testOutput)
        {
            this.testInput = testInput;
            this.testOutput = testOutput;
        }

        public string TestInput { get { return testInput; } }
        public string TestOutput { get { return testOutput; } }

        public void edit_testcase(string test_input, string test_output)
        {
            testInput = test_input;
            testOutput = test_output;
        }
    }
}
