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

namespace AutomationNUnit.TestCase.SuperSearch
{
    /* Verifying Super Search  Hirearchy Results By Passing WTN Number Belonging to Other Client
     Client ID =9994
  */
    class TC_15_SearchHierarchyAndWTNWhichBelongsToAnotherClient : Browser

    {
        [Category("SuperSearch")]
        [Test]
        [TestCaseSource(typeof(TestCaseDataBase), "PrepareTestCases", new object[] { "SuperSearchData\\SuperSearchTestCases15" })]
        public void testTC_15_SearchHierarchyAndWTNWhichBelongsToAnotherClient(Dictionary<String, String> TestData)
        {
            //This step is to Login to Application
            Common.NavigateTo(driver, Util.EnvironmentSettings["Server"]);
            Common.Login(driver, TestData["InternalUserName"], TestData["InternalPassword"]);
            Dashboard.VerifyPage(driver);

            //This step is to select a client
            Dashboard.ClickOnClosePopUp(driver);
            Dashboard.SetClient(driver, TestData["ClientId"]);

            //This step is to Click on Super Search and Select Locations icon
            Dashboard.ClickSuperSearchIcon(driver);
            Dashboard.ClickAnIconInSuperSearch(driver, "Locations");

            //This step is to Verify Super Search bar and Icon selected in Super Search
            Dashboard.VerifySuperSearchBar(driver);
            Dashboard.VerifySuperSearchSelectedFilterIsActive(driver, "locations");

            //This step is to Enter text in Super Search and Verify the result
            Dashboard.EnterTextInSuperSearch(driver, TestData["Hierarchy"]);
            Dashboard.VerifyOtherClientLocationSearchResults(driver, TestData["Hierarchy"]);
            Dashboard.ClearSearchText(driver);

            //This step is to Enter text in Super Search and Verify the result
            Dashboard.EnterTextInSuperSearch(driver, TestData["WTN_Num"]);
            Dashboard.VerifyOtherClientWTNSearchResults(driver, TestData["WTN_Num"]);
        }

    }
}
