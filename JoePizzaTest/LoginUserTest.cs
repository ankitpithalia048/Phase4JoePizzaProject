using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace JoePizzaTesting
{
    [TestFixture]
    public class LoginUserTest
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
                uname.SendKeys("ankituser");
                WebDriverWait enterFname = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                var Password = driver.FindElementByName("Password");
                Assert.IsNotNull(uname);
                Password.SendKeys("Qwerty!23");
                WebDriverWait enterPassword = new WebDriverWait(driver, TimeSpan.FromSeconds(5));


                var login = driver.FindElementByClassName("loginbtn");
                Assert.IsNotNull(loginButton);
                login.Click();
            }
        }

        


    }
}
