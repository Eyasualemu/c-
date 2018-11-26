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
    /* Verifying Super Search Location Results By Passing Service Line From Inventory By Geography
     Client ID =9994
  */
    class TC_19_VerifyStatusOfLineIsDisplayingCorrectWithMettelClient : Browser
    {
        [Category("SuperSearch")]
        [Test]
        [TestCaseSource(typeof(TestCaseDataBase), "PrepareTestCases", new object[] { "SuperSearchData\\SuperSearchTestCases19" })]
        public void testTC_19_VerifyStatusOfLineIsDisplayingCorrectWithMettelClient(Dictionary<String, String> TestData)
        {
            //This step is to Login to Application
            Common.NavigateTo(driver, Util.EnvironmentSettings["Server"]);
            Common.Login(driver, TestData["InternalUserName"], TestData["InternalPassword"]);
            Dashboard.VerifyPage(driver);

            //This step is to Select ClientID
            Dashboard.ClickOnClosePopUp(driver);
            Dashboard.SetClient(driver, TestData["ClientId"]);

            //This Step is to Navigate to Inventory page
            Dashboard.ClickCombinedMenu(driver);
            Dashboard.ClickInventory(driver);
            Dashboard.SelectByGeography(driver);

            //This Step to Notice the status for any inventory Ex: 9177083346
            string service = AssetsByGeography.GetServiceNumber(driver);
            string serviceOriginal = AssetsByGeography.GetServiceNumberOriginal(driver);
            string status = AssetsByGeography.GetFirstServiceStatus(driver);

            //This step is to Click on Super Search and Select Locations icon
            Dashboard.ClickSuperSearchIcon(driver);
            Dashboard.ClickAnIconInSuperSearch(driver, "Locations");
            
            //This step is to Verify Super Search bar and Icon selected in Super Search
            Dashboard.VerifySuperSearchBar(driver);
            Dashboard.VerifySuperSearchSelectedFilterIsActive(driver, "locations");

            //This step is to Enter text in Super Search and Verify the result
            Dashboard.EnterTextInSuperSearch(driver, serviceOriginal);

            //This Step is to Verify Location search results displayed";
            Dashboard.VerifyServiceLineShouldDisplay(driver, service);

        }

    }
}
