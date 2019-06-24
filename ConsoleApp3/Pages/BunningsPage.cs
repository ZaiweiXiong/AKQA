using System.Configuration;
using OpenQA.Selenium;
using NUnit.Framework;
using System;
using ConsoleApp3.Core;

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
        private IWebElement seleOneProduct => Driver.FindControl(By.XPath("//section//article[1]/a/div/div[1]/div/div/img"));
        private IWebElement addOneProduct => Driver.FindControl(By.XPath("//span[text()='Add to Wish List']"));
        private IWebElement add => Driver.FindControl(By.XPath("//span[text()='Added']"));
        private IWebElement myWishList => Driver.FindControl(By.XPath("//strong[text()='Total']"));

        ////strong[text()='Total']
        //h2[text()='My Wish List']

        public BunningsPage bunnigsSerch() {

            var searchKey = ConfigurationManager.AppSettings["searchKey"];
            searchInput.SendKeys(searchKey);
            search.Click();

            return this;
        }

        public BunningsPage selectOneProduct() {

            seleOneProduct.Click();

            return this;
        }

        public BunningsPage addSelectedProduct() {

            addOneProduct.Click();
            var Added = ConfigurationManager.AppSettings["Added"];
            string str = add.Text;
            if (Added.Equals(str))
            {

                var listUrl = ConfigurationManager.AppSettings["listUrl"];
                Driver.Navigate().GoToUrl(listUrl);
            }
            else {

                Console.WriteLine("You currently don’t have any items in your Wish List!");
            }
           
           
            return this;
        }

        public void AssertProductList() {

            var MyWishList = ConfigurationManager.AppSettings["myWishList"];
            Assert.AreEqual(MyWishList, myWishList.Text);
        }

    }
}
