using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ConsoleApp3.Core
{
    public static class ElementFinder
    {
        public static IWebElement FindControl(this IWebDriver driver, By findBy, bool ensureVisibility = false,
            bool isClickable = false, bool moveElement = false)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                var element = wait.Until(drv => drv.FindElement(findBy));

                if (ensureVisibility)
                {
                    wait.Until(drv => element.Displayed);
                    wait.Until(drv => element.Enabled);
                }

                if (isClickable)
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                }

                if (moveElement)
                {
                    IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

                    jse.ExecuteScript("scroll(0, 250)");
                }

                return element;
            }
            catch (Exception)
            {
                Console.WriteLine($"INFO: Element not found.\n{findBy}");
                throw;
            }
        }
    }
}
