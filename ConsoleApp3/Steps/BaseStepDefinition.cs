using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Configuration;
using System.Net;
using System;
using ConsoleApp3.Core;


namespace ConsoleApp3.Steps
{
    [Binding]
    public class BaseStepDefinition
    {
        public static IWebDriver driver = null;
        [BeforeTestRun]
        private static void WarmUpIis()
        {
            var webClient = new WebClient { Proxy = null };
            var requestUrl = ConfigurationManager.AppSettings["URL"];
            webClient.DownloadString(requestUrl);
        }

        [BeforeFeature]
        public static void BeforeScenario()
        {

            driver = WebDriverFactory.CreateDriver((DriverType)Enum.Parse(typeof(DriverType), ConfigurationManager.AppSettings["DriverType"]));
           

        }
        [AfterFeature]
        public static void AfterScenario()
        {

            driver.Quit();
        }
        [AfterStep]
        private void AfterStep()
        {
            if (ScenarioContext.Current.TestError == null)
            {
                return;
            }

            Console.WriteLine("INFO: Failed at URL:" + driver.Url);
        }

    }


}
