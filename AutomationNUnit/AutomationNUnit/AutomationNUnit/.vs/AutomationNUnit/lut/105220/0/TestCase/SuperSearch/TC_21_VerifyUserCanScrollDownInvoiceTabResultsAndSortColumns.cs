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
    /* Verifying User Can SortColumns of  Invoice Tab Results
       Client ID = 9994
    */
    class TC_21_VerifyUserCanScrollDownInvoiceTabResultsAndSortColumns : Browser
    {
        [Category("SuperSearch")]
        [Test]
        [TestCaseSource(typeof(TestCaseDataBase), "PrepareTestCases", new object[] { "SuperSearchData\\SuperSearchTestCases21" })]
        public void testTC_21_VerifyUserCanScrollDownInvoiceTabResultsAndSortColumns(Dictionary<String, String> TestData)
        {
            //This step is to Login to Application
            Common.NavigateTo(driver, Util.EnvironmentSettings["Server"]);
            Common.Login(driver, TestData["InternalUserName"], TestData["InternalPassword"]);
            Dashboard.VerifyPage(driver);

            //This step is to Select ClientID
            Dashboard.ClickOnClosePopUp(driver);
            Dashboard.SetClient(driver, TestData["ClientId"]);
           
            //This step is to Click on Super Search and Select Locations icon
            Dashboard.ClickSuperSearchIcon(driver);
            Dashboard.ClickAnIconInSuperSearch(driver, "locations");

            //This step is to Verify Super Search bar and Icon selected in Super Search
            Dashboard.VerifySuperSearchBar(driver);
            Dashboard.VerifySuperSearchSelectedFilterIsActive(driver, "locations");

            //This step is to Enter address in Super Search and Verify the result
            string[] results = { "Address", "City", "State", "Zip" };
            Dashboard.EnterTextInSuperSearch(driver, TestData["Address"]);
            Dashboard.VerifySuperSearchLocationResults(driver, results);

            //This step is to Click on Invoice tab and scrol down
            Dashboard.ClickTabInSuperSearch(driver, "Invoices");
            Selenide.ScrolUpOrDown(driver, "down");

            //This step is to Sort a column and Verify column is sorted
            string value = Dashboard.GetColumnFirstValue(driver, "Invoice Date");
            Dashboard.InventoryTabColumnsSort(driver, "Invoice Date");
            Dashboard.VerifyInventoryTabColumnSort(driver, value, "Invoice Date");

            //This step is to Sort a column and Verify column is sorted
            string value2 = Dashboard.GetColumnFirstValue(driver, "Account");
            Dashboard.InventoryTabColumnsSort(driver, "Account");
            Dashboard.VerifyInventoryTabColumnSort(driver, value, "Account");
                                             
        }

    }
}
