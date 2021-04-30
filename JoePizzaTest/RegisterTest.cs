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
    public class RegisterTest
    {
        
        [Test]
        public void GoToRegister()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://localhost:44307/");
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                //Console.Read();s
                var loginButton = driver.FindElementByClassName("register");
                Assert.IsNotNull(loginButton);
                loginButton.Click();


                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );

                var pageTitle = driver.PageSource.Contains("Enter Your Address WIth Pin Code");
                Assert.IsTrue(pageTitle);


                var uname = driver.FindElementByName("Name");
                Assert.IsNotNull(uname);

                uname.SendKeys("Newuser");
                WebDriverWait enterFname = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                var Email = driver.FindElementByName("Email");
                Assert.IsNotNull(Email);

                Email.SendKeys("Newuser@gmail.com");
                WebDriverWait enterEmail = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                var Password = driver.FindElementByName("Password");
                Assert.IsNotNull(Password);
                Password.SendKeys("Ankit!23");
                WebDriverWait enterPassword = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                var CPassword = driver.FindElementByName("ConfirmPassword");
                Assert.IsNotNull(CPassword);
                CPassword.SendKeys("Ankit!23");
                WebDriverWait enterCPassword = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                var Address = driver.FindElementByName("Address");
                Assert.IsNotNull(Address);
                Address.SendKeys("ankit");
                WebDriverWait enterAddress = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                var Phone = driver.FindElementByName("Phone");
                Assert.IsNotNull(Phone);
                Phone.SendKeys("7898619861");
                WebDriverWait enterPhone = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                var Create = driver.FindElementByClassName("registerBtn");
                Assert.IsNotNull(Phone);
                Create.Click();

            }
        }
    }
}
