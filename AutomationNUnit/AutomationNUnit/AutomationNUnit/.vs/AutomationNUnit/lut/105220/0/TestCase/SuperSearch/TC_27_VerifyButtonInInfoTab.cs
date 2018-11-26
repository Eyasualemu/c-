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
    /* Verifying Reset Password button and Verify message Displayed 
       Client ID =0
    */
    class TC_27_VerifyButtonInInfoTab : Browser
    {
        [Category("SuperSearch")]
        [Test]
        [TestCaseSource(typeof(TestCaseDataBase), "PrepareTestCases", new object[] { "SuperSearchData\\SuperSearchTestCases27" })]
        public void testTC_27_VerifyButtonInInfoTab(Dictionary<String, String> TestData)
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
            Dashboard.SelectSearchResults(driver, "Client ID", "0");

            //This step is to Click on Tickets tab, Click Edit User Info button and Verify Users page
            Dashboard.ClickTabInSuperSearch(driver, "Info");
            Dashboard.ClickEditUserInfoButton(driver);
            Selenide.SwitchtoNewWindow(driver);
            UserPage.VerifyUsersPage(driver);

            //This step is to Navigate back to Info tab, Click on Reset Password button and Verify message
            Selenide.SwithToFirstWindow(driver);
            Dashboard.ClickResetPasswordButton(driver);
            Dashboard.VerifySuccessfulResetPasswordMessage(driver);

            //This step is to Click on Log in as User and Verify message
            Dashboard.ClickLoginAsUserButton(driver);
            Dashboard.VerifyLoginAsUserMessage(driver);
        }

    }
}
