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
    /* Verifying Edit User Info Button And TicketLink In TicketsTab By Selecting Users In Supersearch
       Client ID =0
    */
    class TC_26_VerifyEditUserInfoButtonAndTicketLinkInTicketsTab : Browser
    {
        [Category("SuperSearch")]
        [Test]
        [TestCaseSource(typeof(TestCaseDataBase), "PrepareTestCases", new object[] { "SuperSearchData\\SuperSearchTestCases26" })]
        public void testTC_26_VerifyEditUserInfoButtonAndTicketLinkInTicketsTab(Dictionary<String, String> TestData)
        {
            //Login to Application";
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
            Dashboard.SelectSearchResults(driver, "Client ID", "0");
            
            //This step is to Click on Tickets tab, Click Edit User Info button and Verify Users page
            Dashboard.ClickTabInSuperSearch(driver, "Tickets");
            Dashboard.ClickEditUserInfoButton(driver);
            Selenide.SwitchtoNewWindow(driver);
            UserPage.VerifyUsersPage(driver);
            Selenide.SwithToFirstWindow(driver);

            //This step is to Click on Tickets tab, Click a Ticket link and Verify Tickets page
            Dashboard.ClickTabInSuperSearch(driver, "Tickets");
            Dashboard.ClickTicketLinkInSuperSearchTicketsTab(driver);
            Selenide.SwithToLastWindow(driver);
            HelpDesk.VerifyTicketingPage(driver);
        }

    }
}
