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
    /* Verifying Creating New Ticket By Selecting Users In Supersearch
       Client ID =0
    */
    class TC_25_VerifyCreatingNewTicket : Browser

    {
        [Category("SuperSearch")]
        [Test]
        [TestCaseSource(typeof(TestCaseDataBase), "PrepareTestCases", new object[] { "SuperSearchData\\SuperSearchTestCases25" })]
        public void testTC_25_VerifyCreatingNewTicket(Dictionary<String, String> TestData)
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


            //This step is to Select a Inventory and Click on New Ticket button
            Dashboard.SelectFirstCheckBoxInSuperSearchInventoryTab(driver);
            Dashboard.ClickNewTicketButtonInSuperSearchInventoryTab(driver);

            //This step is to select New Ticket service, Topic and Click Create Ticket button
            Dashboard.SelectNewTicketService(driver, "Repair Service");
            Dashboard.SelectGivenTopic(driver, "Wireless Device Not Working");
            Dashboard.ClickCreateTicketButton(driver);

            //This step is to Enter details on Details page and Click Next button
            HelpDesk.EnterTicketCreationDetails(driver);
            HelpDesk.ClickNext(driver);

            //This step is to Enter details on contact page and Click Next button
            HelpDesk.EnterDetailsOnContactsPage(driver);
            HelpDesk.ClickNext(driver);

            //This step is to Click submit button on Review page
            HelpDesk.ClickSubmitInReviewPage(driver);
            string ticketID = HelpDesk.VerifyTicketIsCreated(driver);

        }

    }
}
