using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;



namespace ConsoleApp3.Core
{
    public class WebDriverFactory
    {

        public static IWebDriver CreateDriver(DriverType driverType)
        {
            switch (driverType)
            {
                case DriverType.Ie:
                    return new InternetExplorerDriver();
                case DriverType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--start-maximized");
                    chromeOptions.AddArguments("--incognito");
                    chromeOptions.AddArguments("--disable-popup-blocking");
                    chromeOptions.AddArguments("--disable-extensions");
                    chromeOptions.AddArguments("--disable-notifications");
                    chromeOptions.AddArguments("--disable-infobars");
                    return new ChromeDriver(chromeOptions);
                default:
                    return new FirefoxDriver();
            }
        }
    }
}
