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
    /* Verifying User With One Hierarchy Cannot Search WTN which BelongsTo Other Hierarchy
      Client ID =0
   */
    class TC_17_VerifyUserWithLowHiearchyCannotSearchWTNwhichBelongsToLowerHierarchy : Browser

    {

        [Category("SuperSearch")]
        [Test]
        [TestCaseSource(typeof(TestCaseDataBase), "PrepareTestCases", new object[] { "SuperSearchData\\SuperSearchTestCases17" })]
        public void testTC_17_VerifyUserWithLowHiearchyCannotSearchWTNwhichBelongsToLowerHierarchy(Dictionary<String, String> TestData)
        {
            //This step is to Login to Application
            Common.NavigateTo(driver, Util.EnvironmentSettings["Server"]);
            Common.Login(driver, TestData["InternalUserName"], TestData["InternalPassword"]);
            Dashboard.VerifyPage(driver);

            //This step is to Click on Super Search and Select Locations icon
            Dashboard.ClickOnClosePopUp(driver);
            Dashboard.ClickSuperSearchIcon(driver);
            Dashboard.ClickAnIconInSuperSearch(driver, "Locations");

            //This step is to Verify Super Search bar and Icon selected in Super Search
            Dashboard.VerifySuperSearchBar(driver);
            Dashboard.VerifySuperSearchSelectedFilterIsActive(driver, "locations");

            //This step is to Enter text in Super Search and Verify the result
            Dashboard.EnterTextInSuperSearch(driver, TestData["WTN_Num"]);

            //Step = "Location search results should not display";
            Dashboard.VerifyOtherClientWTNSearchResults(driver, TestData["WTN_Num"]);

        }

    }
}
