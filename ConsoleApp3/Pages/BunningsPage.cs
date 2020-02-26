using System.Configuration;
using OpenQA.Selenium;
using NUnit.Framework;
using System;
using ConsoleApp3.Core;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp3.Pages
{
    public  class BunningsPage : BasePage
    {
        public BunningsPage bunnings() {

            var requestUrl = ConfigurationManager.AppSettings["URL"];
            Driver.Navigate().GoToUrl(requestUrl);
            return this;
        }

        private IWebElement searchInput => Driver.FindControl(By.XPath("//input[@datav3-track-text='search']"));
        private IWebElement search => Driver.FindControl(By.XPath("//button[@datav3-track-text='search']"));
        private IWebElement addOneProduct => Driver.FindControl(By.XPath("//button[text()='Save to Wishlist']"));
        private IWebElement myWishList => Driver.FindControl(By.CssSelector("h2[class='primaryh2 custom-title']"));

        public BunningsPage bunnigsSerch() {

            var searchKey = ConfigurationManager.AppSettings["searchKey"];
            searchInput.SendKeys(searchKey);
            search.Click();

            return this;
        }

        public BunningsPage selectOneProduct() {

            String products = "//span[text()='product results']";
            String x = "//div[@class='codified-product-tile__product-image__image--product']";

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(e => e.FindElement(By.XPath(products)));

            IList<IWebElement> elements = Driver.FindElements(By.XPath(x));
            elements[2].Click();
            Console.WriteLine(""+ elements.Count);

            return this;
        }

        public BunningsPage addSelectedProduct() {

            addOneProduct.Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(e => e.FindElement(By.CssSelector("a[class='tooltip-wishlist-confirmation__link']")));

            Driver.FindElement(By.CssSelector("a[class='tooltip-wishlist-confirmation__link']")).Click();

            return this;
        }

        public void AssertProductList() {

            var MyWishList = ConfigurationManager.AppSettings["myWishList"];
            String myWishlist = "h2[class='primaryh2 custom-title']";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(e => e.FindElement(By.CssSelector(myWishlist)));
            Assert.AreEqual(MyWishList, myWishList.Text);
        }

    }
}
