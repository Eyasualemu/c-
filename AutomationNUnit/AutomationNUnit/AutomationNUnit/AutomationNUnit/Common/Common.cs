using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;
using RelevantCodes.ExtentReports;

namespace AutomationNUnit
{
    public class Common : Browser
    {

  
        //Handle sync just time
        public static int HandleSync(RemoteWebDriver driver, bool invoked = true)
        {
            string s = ConfigurationManager.AppSettings.Get("HandleSync").ToString();
            int time = Convert.ToInt32(ConfigurationManager.AppSettings.Get("HandleSyncTime").ToString());
            if (invoked)
            {
                if (s.Contains("Y") && invoked)
                {
                    Selenide.Wait(driver, time, true);
                }
            }
            return time;
        }


        /// <summary>
        /// Navigates page to specific location
        /// </summary>
        /// <param name="Driver">Initialized RemoteWebDriver instance</param>
        /// <param name="location">Location to navigate</param>
        public static void NavigateTo(RemoteWebDriver driver, String location)
        {

            Selenide.NavigateTo(driver, location);
            test.Log(LogStatus.Pass, "Navigated to" + location);

            System.Threading.Thread.Sleep(1000);
            
        }

        public static void NavigateToGivenURl(RemoteWebDriver driver, String location)
        {
           driver.Navigate().GoToUrl(location);
            driver.Manage().Window.Maximize();

        }


        public static void search(RemoteWebDriver driver, string text)
        {
            Selenide.SetText(driver, Util.GetLocator("Googlesearch"), Selenide.ControlType.Textbox, text);

        }

        
        /// <summary>
        /// Refreshs The Browser
        /// </summary>
        /// <param name="Driver">Initialized RemoteWebDriver instance</param>
        /// <param name="location">Location to navigate</param>
        public static void RefreshBrowser(RemoteWebDriver driver)
        {
            Selenide.BrowserRefresh(driver);
        }

        /// <summary>
        /// Browser back
        /// </summary>
        /// <param name="Driver">Initialized RemoteWebDriver instance</param>
        /// <param name="location">Location to navigate</param>
        public static void ClickBackBrowser(RemoteWebDriver driver)
        {
            Selenide.BrowserBack(driver);
            System.Threading.Thread.Sleep(5000);
        }

      

        public static void HandleSync(RemoteWebDriver driver, Locator ElementToNoLongerVisible)
        {
            Selenide.Wait(driver, 1, true);
            try
            {
                Selenide.WaitforElementDisappear(driver, ElementToNoLongerVisible);
            }
            catch (Exception e)
            {
                //Selenide.Wait(driver,Common.HandleSync(driver), true);

            }
        }

       
        

        public static void TakeScreenshot(IWebDriver driver)
        {
            string testName = TestContext.CurrentContext.Test.ClassName;
            string location = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            string fileName = location.Replace("AutomationNUnit.DLL", testName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
            Console.WriteLine("fileName is " + fileName);
            string localPath = new Uri(fileName).LocalPath;
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            //ITakesScreenshot ssdriver = driver;
            Screenshot screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
        }
    }
}

