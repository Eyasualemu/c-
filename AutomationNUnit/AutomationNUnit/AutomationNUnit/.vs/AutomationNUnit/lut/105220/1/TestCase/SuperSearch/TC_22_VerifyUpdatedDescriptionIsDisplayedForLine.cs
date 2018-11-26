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

    /* Verifying Updated Description Is Displayed For Service Line by Searching from Supersearch Location Results
       Client ID = 9994
    */
    class TC_22_VerifyUpdatedDescriptionIsDisplayedForLine : Browser
    {
        [Category("SuperSearch")]
        [Test]
        [TestCaseSource(typeof(TestCaseDataBase), "PrepareTestCases", new object[] { "SuperSearchData\\SuperSearchTestCases22" })]
        public void testTC_22_VerifyUpdatedDescriptionIsDisplayedForLine(Dictionary<String, String> TestData)
        {
            //This step is to Login to Application
            Common.NavigateTo(driver, Util.EnvironmentSettings["Server"]);
            Common.Login(driver, TestData["InternalUserName"], TestData["InternalPassword"]);
            Dashboard.VerifyPage(driver);

            //This step is to Select ClientID
            Dashboard.ClickOnClosePopUp(driver);
            Dashboard.SetClient(driver, TestData["ClientId"]);

            //Click on Services link
            Dashboard.ClickCombinedMenu(driver);
            Dashboard.ClickLeftMenuServicesLink(driver);
            Dashboard.ClickCombinedMenu(driver);
            Dashboard.ClickByGeographyLink(driver);

            //Verify Assets by Organisation page should be displayed
            AssetsByGeography.VerifyByGeographyPage(driver);

            //Click first line
            string count = AssetsByGeography.SelectLines(driver, TestData["Number"]);

            //Get line number
            List<string> linedetails = AssetsByGeography.GetDetailsOfSelectedLine(driver);

            //Click on quick edit button
            AssetsByGeography.ClickOnQuickEditButton(driver);

            //Verify Quickedit page
            AssetsByGeography.VerifyQuickeditPage(driver, linedetails);

            //Change values in Quick edit page
            AssetsByGeography.UpdateLineDescriptionQuickEdit(driver, TestData["Desc"]);

            //save the changes
            AssetsByGeography.ClickSaveQuickEditchanges(driver);
            AssetsByGeography.VerifyQuickEditsave(driver);

            //Verify Updated Line Description through Global search results
            Dashboard.ClickSuperSearchIcon(driver);
            Dashboard.EnterTextInSuperSearch(driver, linedetails[0]);
            Dashboard.ClickOpenLocationButton(driver);

            //Verifying Line Description
            Dashboard.VerifyDescriptionLine(driver, TestData["Desc"]);
            
        }

    }
}
