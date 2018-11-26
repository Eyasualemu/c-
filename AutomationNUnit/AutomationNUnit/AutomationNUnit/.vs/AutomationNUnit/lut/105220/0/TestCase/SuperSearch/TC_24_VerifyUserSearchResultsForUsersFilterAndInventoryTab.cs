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
    /* Verifying User Search Results For Users Filter And Inventory Tab 
       Client ID =0
    */
    class TC_24_VerifyUserSearchResultsForUsersFilterAndInventoryTab : Browser
    {
        [Category("SuperSearch")]
        [Test]
        [TestCaseSource(typeof(TestCaseDataBase), "PrepareTestCases", new object[] { "SuperSearchData\\SuperSearchTestCases24" })]
        public void testTC_24_VerifyUserSearchResultsForUsersFilterAndInventoryTab(Dictionary<String, String> TestData)
        {
            //Login to Application
            Common.NavigateTo(driver, Util.EnvironmentSettings["Server"]);
            Common.Login(driver, TestData["InternalUserName"], TestData["InternalPassword"]);
            Dashboard.VerifyPage(driver);

            //This step is to Click on Super Search and Select Users icon
            Dashboard.ClickOnClosePopUp(driver);
            Dashboard.ClickSuperSearchIcon(driver);
            Dashboard.ClickAnIconInSuperSearch(driver, "users");

            //This step is to Verify Super Search bar and Icon selected in Super Search
            Dashboard.VerifySuperSearchBar(driver);
            Dashboard.VerifySuperSearchSelectedFilterIsActive(driver, "users");

            //This step is to Enter User in Super Search and Verify the result
            string[] results = { "Name", "Email", "Client Name", "Client ID" };
            Dashboard.EnterTextInSuperSearch(driver, TestData["User"]);
            Dashboard.VerifySuperSearchLocationResults(driver, results);

            //This step is to Click on Inventory tab,Click on Open Inventory button and Verify Inventory page user
            Dashboard.ClickTabInSuperSearch(driver, "Inventory");
            Dashboard.ClickOpenInventoryButton(driver);
            Selenide.SwitchtoNewWindow(driver);
            Dashboard.VerifyInventoryPageUser(driver, TestData["User"]);
        }

    }
}
