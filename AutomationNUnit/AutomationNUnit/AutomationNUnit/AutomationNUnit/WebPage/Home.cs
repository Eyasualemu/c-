using System;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;

namespace AutomationNUnit.WebPage
{
    class Home: Common
    {

        /// <summary>
        /// This method naviagte the url
        /// </summary>
        /// <param name="driver">Initialized RemoteWebDriver instance</param>
        /// <param name="reporter">Initialized report instance</param>
        /// <param name="url">URL of the application</param>
        public static void NavigateTo(RemoteWebDriver driver, String url)
        {
            Selenide.NavigateTo(driver, url);
        }
       


        public static void Logout(RemoteWebDriver driver, string username)
        {
            ////(new Act("Logoutfrom application"));
            Selenide.Wait(driver, 4, true);
            Selenide.Click(driver, Locator.Get(LocatorType.XPath, "//span[text()='" + username + "']"));            
            Selenide.WaitForElementVisible(driver, Util.GetLocator("signOutLink"));
            Selenide.Click(driver, Util.GetLocator("signOutLink"));
            test.Log(LogStatus.Pass, "Log out");
        }


    }
}
