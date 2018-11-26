using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationNUnit.TestCaseData
{
    class TestCaseDataBase
    {
        public static IEnumerable<Dictionary<String, String>> PrepareTestCases(string param1)
        {
            string name = param1;
            //if(name.Equals("\\TC_12_"))
            //{
            //    Console.WriteLine("");
            //}

            return Util.ReadTestDataCSVContent(name);
        }

    }
}
