using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;
using TatAutomationFramework.Common;


namespace AutomationNUnit
{
    public enum BrowserType
    {
        CHROMEHEADLESS,
        CHROME,
        FIREFOX,
        IE
    }
    [TestFixture]

    public class Browser  : BasicReport
    {
        //public static _browser brow;
        public static RemoteWebDriver driver = null;

        public static RemoteWebDriver SelectBrowser(BrowserType browser)
        {
            try
            {
                switch (browser)
                {
                    case BrowserType.CHROMEHEADLESS:
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("headless");
                        options.AddArgument("window-size=1920x1080");
                        driver = new ChromeDriver(options);
                        break;
                    case BrowserType.CHROME:
                        driver = new ChromeDriver();
                        driver.Manage().Window.Maximize();
                        break;
                    case BrowserType.FIREFOX:
                        driver = new FirefoxDriver();
                        break;
                    case BrowserType.IE:
                        driver = new InternetExplorerDriver();
                        break;
                    default:
                        throw new Exception("Invalid browser selection");

                }

                return driver;
            }
            catch (Exception Ex)
            {
                throw;
            }


        }

        [SetUp]
        public void BaseSetUp()
        {
            try
            {
                BrowserType BrowserName = (BrowserType)Enum.Parse(typeof(BrowserType), ConfigurationManager.AppSettings["SelectedBrowser"].ToUpper().ToString());
                SelectBrowser(BrowserName);
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message + "-----" + "Invalid browser selection. Please choose appropriate browser.");
            }
        }

        [TearDown]
        public void BaseTearDown()
        {
            string testName = TestContext.CurrentContext.Test.ClassName;
            string location = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            


            if (TestContext.CurrentContext.Result.Outcome == ResultState.Error)
            {
                //Console.WriteLine("Location is " + location);
                string fileName = location.Replace("AutomationNUnit.DLL", testName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
                Console.WriteLine("fileName is " + fileName);
                string localPath = new Uri(fileName).LocalPath;
                TakeScreenshot(driver, localPath);
                test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, stackTrace+ errorMessage);
                test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, test.AddScreenCapture(localPath));
            }
            else
            {
                //Console.WriteLine("Location is " + location);
                string fileName = location.Replace("AutomationNUnit.DLL", testName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
                Console.WriteLine("fileName is " + fileName);
                string localPath = new Uri(fileName).LocalPath;
                TakeScreenshot(driver, localPath);
               
            }

            driver.Close();
            driver.Quit();
        }

        public void TakeScreenshot(IWebDriver driver, string saveLocation)
        {
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            //ITakesScreenshot ssdriver = driver;
            Screenshot screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(saveLocation, ScreenshotImageFormat.Png);
        }

    }



}
