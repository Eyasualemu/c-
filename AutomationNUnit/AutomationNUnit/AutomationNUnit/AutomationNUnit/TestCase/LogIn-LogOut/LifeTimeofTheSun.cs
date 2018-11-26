using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using AutomationNUnit.TestCaseData;
using AutomationNUnit.WebPage;

namespace AutomationNUnit.TestCase
{
    class LifeTimeofTheSun : Browser
    {
        [Category("LogInLogOut")]
        [Test]
        [TestCaseSource(typeof(TestCaseDataBase), "PrepareTestCases", new object[] { "LogIn-LogOut\\LifeTimeofTheSun" })]
        public void testLifeTimeofTheSun(Dictionary<String, String> TestData)
        {

            //"Opening Browser and Navigating to the Application";
            Common.NavigateTo(driver, Util.EnvironmentSettings["Server"]);
            
            // = "Verification of navigation bar";
            Dashboard.VerifyNavigationBar(driver);

            // = "Verify all footer links";
            Dashboard.VerifyAllFooterLinks(driver);

            // = "Enter the search input";
            Dashboard.EnterSearchInput(driver,TestData["SearchInput"]);

            // = "verify  the radius of the sun is in Miles";
            Dashboard.ValidateRadius(driver);

            //Click the "Non Show Metric" button and verify what the radius of the sun is in kilometers now
            Dashboard.ClickMetricBtn(driver);


            //Validate the lifetime of the sun
            Dashboard.ValidateLifeTimeSun(driver);


            //Click Sign in from the navigation bar
            Dashboard.ClickSigninBtn(driver);

            //  "login to Wolferamton with In valid credentials";
            Dashboard.LoginToWolframWithInvalidCredentials(driver, TestData["InvalidUsername"], TestData["InvalidPassword"]);
            
            
            //  "login to Wolferamton with valid credentials";
            Dashboard.LoginToWolfram(driver, TestData["UserName"], TestData["Password"]);

            //  "Log out";
            Home.Logout(driver, TestData["UserName"]);


        }
    }

}