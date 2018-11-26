using System;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutomationNUnit;
using NUnit.Framework;
using System.Configuration;
using RelevantCodes.ExtentReports;

namespace AutomationNUnit.WebPage
{
    public class Dashboard : Browser
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



        public static void VerifyNavigationBar(RemoteWebDriver driver)
        {
            //(new Act("Navigation bar should display"));
            // Selenide.WaitForElementVisible(driver, Util.GetLocator("NavigationBar"));
            Selenide.Query.isElementVisible(driver, Util.GetLocator("NavigationBar"));
            test.Log(LogStatus.Pass, "Verified Navigation bar displayed");

        }

        public static void Verifyradius(RemoteWebDriver driver)
        {
            //(new Act("Navigation bar should display"));
            // Selenide.WaitForElementVisible(driver, Util.GetLocator("NavigationBar"));
            Selenide.Query.isElementVisible(driver, Util.GetLocator("NavigationBar"));

        }
        public static void EnterSearchInput(RemoteWebDriver driver, string searchinput)
        {
            //Enter the search input: what is the size of the sun
            Selenide.ScrollToElement(driver, Util.GetLocator("NavigationBar"));
            Selenide.SetText(driver, Util.GetLocator("NavigationBar"), Selenide.ControlType.Textbox, searchinput);
            Selenide.Click(driver, Util.GetLocator("search_Btn"));
            test.Log(LogStatus.Pass, "Entered the search input text is 'what is the size of the sun'");


        }
        public static void ValidateRadius(RemoteWebDriver driver)
        {
            //Verify that the radius of the sun is 432300 miles.
            Selenide.WaitForElementVisible(driver, Util.GetLocator("Radiussun432300"));
            Selenide.Query.isElementVisible(driver, Util.GetLocator("Radiussun432300"));
            test.Log(LogStatus.Pass, "The radius of the sun is 432300 miles displayed");



        }


        public static void ValidateLifeTimeSun(RemoteWebDriver driver)
        {
            //    //Validate the lifetime of the sun
            Selenide.WaitForElementVisible(driver, Util.GetLocator("Lifetimeofsun"));
            Selenide.Query.isElementVisible(driver, Util.GetLocator("Lifetimeofsun"));
            test.Log(LogStatus.Pass, "Verified the lifetime of the sun is 9.8 billion years");


        }



        public static void Lifetime(RemoteWebDriver driver)
        {
            //(new Act("Validate the lifetime of the sun"));
            // Selenide.WaitForElementVisible(driver, Util.GetLocator("NavigationBar"));
            Selenide.Query.isElementVisible(driver, Util.GetLocator("search_Btn"));

        }


        /// <summary>
        /// Click on ok button for verification
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickOkButton(RemoteWebDriver driver)
        {
            //(new Act("Click on Ok button"));
            Selenide.Click(driver, Util.GetLocator("Security_ok"));

        }


        public static void VerifyAllFooterLinks(RemoteWebDriver driver)
        {
            //(new Act("All footer links should display"));            
            Selenide.ScrollToElement(driver, Util.GetLocator("footerlnk_pro"));

            string[] footerlinks = { "Pro", "Web Apps", "Mobile Apps", "Products", "Business Solutions", "API & Developer Solutions", "About", "Resources & Tools", "Blog", "Community", "Contact", "Connect" };

            int leanth = footerlinks.Length;
            for (int i = 0; i < leanth; i++)
            {
                if (footerlinks[i] == "Connect")
                {
                    Selenide.WaitForElementVisible(driver, Util.GetLocator("footerlnk_pro"));
                    Selenide.Query.isElementVisible(driver, Locator.Get(LocatorType.XPath, "//li[@id='footer-top-links']/descendant::a[contains(text(),'" + footerlinks[i] + "')]"));
                }
                else
                {

                    Selenide.WaitForElementVisible(driver, Util.GetLocator("footerlnk_pro"));
                    Selenide.Query.isElementVisible(driver, Locator.Get(LocatorType.XPath, "//li[@id='footer-top-links']/descendant::a[text()='" + footerlinks[i] + "']"));
                }
            }

            //last bottom links
            string[] bottomlinks = { "wolfram.com", "Wolfram Language", "Wolfram for Education", "Wolfram Demonstrations", "Mathematica", "MathWorld" };

            int bleanth = bottomlinks.Length;
            for (int i = 0; i < bleanth; i++)
            {
                Selenide.Query.isElementVisible(driver, Locator.Get(LocatorType.XPath, "//a[text()='" + bottomlinks[i] + "']"));
            }

            test.Log(LogStatus.Pass, "Verified all footer links");

        }


        public static void LoginToWolfram(RemoteWebDriver driver, string userName, string password)
        {

            //(new Act("Enter User name"));
            Selenide.SetText(driver, Util.GetLocator("User_EmailTextBox"), Selenide.ControlType.Textbox, userName);

            //(new Act("Enter Password"));
            Selenide.SetText(driver, Util.GetLocator("User_PasswordTextBox"), Selenide.ControlType.Textbox, password);

            //(new Act("clickon sig in button"));
            Selenide.Click(driver, Util.GetLocator("Login_SiginBtn"));

            //Verify successfully logged in to application
            //Verify that the user name is Present in the nav bar
            Selenide.WaitForElementVisible(driver, Locator.Get(LocatorType.XPath, "//span[text()='" + userName + "']"));
            Selenide.Query.isElementVisible(driver, Locator.Get(LocatorType.XPath, "//span[text()='" + userName + "']"));
            test.Log(LogStatus.Pass, "User " + userName + "Logged in successfully");


        }

        public static void ClickSigninBtn(RemoteWebDriver driver)
        {
            Selenide.BrowserBack(driver);
            //"Click Sign in from the navigation bar"
            Selenide.Wait(driver, 5, true);
            Selenide.ScrollToElement(driver, Util.GetLocator("Signin_btn"));
            Selenide.Click(driver, Util.GetLocator("Signin_btn"));
        }

        public static void ClickMetricBtn(RemoteWebDriver driver)
        {
            //Click the "Non Show Metric" button
            Selenide.Wait(driver, 5, true);
            Selenide.ScrollToElement(driver, Util.GetLocator("ShowMetricBtn"));
            Selenide.Click(driver, Util.GetLocator("ShowMetricBtn"));
            Selenide.Wait(driver, 5, true);
            //Verify that the non-metric value is not present
            //Validate in kilometers
            Selenide.Query.isElementVisible(driver, Util.GetLocator("Kilometers695700"));
            test.Log(LogStatus.Pass, "The radius of the sun is 432300 kilometers displayed");

            bool nonmetricvalue = Selenide.Query.isElementVisibleboolValue2(driver, Util.GetLocator("Radiussun432300"));
            if (!nonmetricvalue)
            {
                test.Log(LogStatus.Pass, "The metric value is not present");
            }
            else
            {
                throw new Exception("The non metric value displayed");
            }
        }


        public static void LoginToWolframWithInvalidCredentials(RemoteWebDriver driver, string userName, string password)
        {

            //(new Act("Enter User name"));
            Selenide.WaitForElementVisible(driver, Util.GetLocator("User_EmailTextBox"));
            Selenide.SetText(driver, Util.GetLocator("User_EmailTextBox"), Selenide.ControlType.Textbox, userName);

            //(new Act("Enter Password"));
            Selenide.SetText(driver, Util.GetLocator("User_PasswordTextBox"), Selenide.ControlType.Textbox, password);

            //(new Act("clickon sig in button"));
            Selenide.Click(driver, Util.GetLocator("Login_SiginBtn"));

            //Verify successfully logged in to application
            Selenide.WaitForElementVisible(driver, Util.GetLocator("ErrorLogin"));
            Selenide.Query.isElementVisible(driver, Util.GetLocator("ErrorLogin"));
            test.Log(LogStatus.Pass, "Error message displayed");


        }



    }
}


