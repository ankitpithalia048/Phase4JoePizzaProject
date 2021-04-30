using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoePizzaTesting
{
    [TestFixture]
    class ManageOrder
    {
        [Test]
        public void Login()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://localhost:44307/");
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                         d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                         );
                //Console.Read();s
                var loginButton = driver.FindElementByClassName("login");
                Assert.IsNotNull(loginButton);
                loginButton.Click();

                var uname = driver.FindElementByName("UserName");
                Assert.IsNotNull(uname);
                uname.SendKeys("ankitadmin");
                WebDriverWait enterFname = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                var Password = driver.FindElementByName("Password");
                Assert.IsNotNull(uname);
                Password.SendKeys("Ankit!2");
                WebDriverWait enterPassword = new WebDriverWait(driver, TimeSpan.FromSeconds(5));


                var login = driver.FindElementByClassName("loginbtn");
                Assert.IsNotNull(loginButton);
                login.Click();

                var MangeOrder = driver.FindElementByLinkText("Manage Pizza");
                Assert.IsNotNull(MangeOrder);
                MangeOrder.Click();

                var text = driver.PageSource.Contains("Pizza Menu");
                Assert.IsTrue(text);

                var delete = driver.FindElementByXPath("//a[@href='/Home/Delete/1']");
                Assert.IsNotNull(delete);
                delete.Click();
                var del = driver.FindElementByClassName("btn-danger");
                Assert.IsNotNull(del);
                del.Click();

                
              
            }
        }
    }
}
