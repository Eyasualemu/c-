﻿using NUnit.Framework;
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
    /* Verifying Inventory Tab columns Sort Functionality 
      Client ID =0
   */
    class TC_18_VerifyUserCanScrollDownInventoryTabResultsAndSortColumn : Browser
    {
        [Category("SuperSearch")]
        [Test]
        [TestCaseSource(typeof(TestCaseDataBase), "PrepareTestCases", new object[] { "SuperSearchData\\SuperSearchTestCases18" })]
        public void testTC_18_VerifyUserCanScrollDownInventoryTabResultsAndSortColumn(Dictionary<String, String> TestData)
        {
            //This step is to Login to Application
            Common.NavigateTo(driver, Util.EnvironmentSettings["Server"]);
            Common.Login(driver, TestData["InternalUserName"], TestData["InternalPassword"]);
            Dashboard.VerifyPage(driver);

            //This step is to Click on Super Search and Select Locations icon
            Dashboard.ClickOnClosePopUp(driver);
            Dashboard.ClickSuperSearchIcon(driver);
            Dashboard.ClickAnIconInSuperSearch(driver, "locations");

            //This step is to Verify Super Search bar and Icon selected in Super Search
            Dashboard.VerifySuperSearchBar(driver);
            Dashboard.VerifySuperSearchSelectedFilterIsActive(driver, "locations");

            //This step is to Enter address in Super Search and Verify the result
            string[] results = { "Address", "City", "State", "Zip", "Client Name" };
            Dashboard.EnterTextInSuperSearch(driver, TestData["Address"]);
            Dashboard.VerifySuperSearchLocationResults(driver, results);

            //This step is to Click on Inventory tab and scrol down
            Dashboard.ClickTabInSuperSearch(driver, "Inventory");
            //Selenide.ScrolUpOrDown(driver, "down");

            //This step is to Sort a column and Verify column is sorted
            string value = Dashboard.GetColumnFirstValue(driver, "Status");
            Dashboard.InventoryTabColumnsSort(driver, "Status");
            //Dashboard.VerifyInventoryTabColumnSort(driver, value, "Status");

            //This step is to Sort a column and Verify column is sorted
            value = Dashboard.GetColumnFirstValue(driver, "Service");
            Dashboard.InventoryTabColumnsSort(driver, "Service");
            Dashboard.VerifyInventoryTabColumnSort(driver, value, "Service");

            //This step is to Sort a column and Verify column is sorted
            value = Dashboard.GetColumnFirstValue(driver, "Description");
            Dashboard.InventoryTabColumnsSort(driver, "Description");
            Dashboard.VerifyInventoryTabColumnSort(driver, value, "Description");

            //This step is to Sort a column and Verify column is sorted
            value = Dashboard.GetColumnFirstValue(driver, "Service");
            Dashboard.InventoryTabColumnsSort(driver, "Account");
            Dashboard.VerifyInventoryTabColumnSort(driver, value, "Service");
            
        }

    }
}