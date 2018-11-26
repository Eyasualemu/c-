using NUnit.Framework;
using RelevantCodes.ExtentReports;
using NUnit.Framework.Interfaces;
using System;
using AutomationNUnit.TestCaseData;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;

namespace TatAutomationFramework.Common
{
    [TestFixture]
    public class BasicReport
    {
        public ExtentReports extent;
        public static ExtentTest test;

        [OneTimeSetUp]
        public void StartReport()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            //string actualPath = path.Replace("AutomationNUnit.DLL", "Reports");
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\MyOwnReport.html";

            extent = new ExtentReports(reportPath, true);
            extent
            .AddSystemInfo("Host Name", "USAID")
            .AddSystemInfo("Environment", "TEST")
            .AddSystemInfo("User Name", "Sam");
            extent.LoadConfig(projectPath + "extent-config.xml");
            string testName = TestContext.CurrentContext.Test.ClassName;
            test = extent.StartTest(testName);
        }


        [TearDown]
        public void GetResult()
        {

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
            {
                test.Log(LogStatus.Pass, "Test", "");
            }

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Error)
            {
                test.Log(LogStatus.Fail, "", status + errorMessage);
            }
            extent.EndTest(test);
            //XmlReport.GetXMLFromObject(test);
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            extent.Flush();
            extent.Close();
        }
    }
}
