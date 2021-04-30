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
    class AddPizza
    {
        [Test]
        public void Add()
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

                var add = driver.FindElementByLinkText("Add New Item");
                Assert.IsNotNull(add);
                add.Click();

                
                var id = driver.FindElementByName("ID");
                Assert.IsNotNull(id);
                id.SendKeys("1");

                var Pizza_Name = driver.FindElementByName("Pizza_Name");
                Assert.IsNotNull(Pizza_Name);
                Pizza_Name.SendKeys("Veg Pizza");
                var Img_Url = driver.FindElementByName("Img_Url");
                Assert.IsNotNull(Img_Url);
                Img_Url.SendKeys("https://www.wallpaperbetter.com/wallpaper/786/792/888/veggie-pizza-1080P-wallpaper.jpg");
                var Price = driver.FindElementByName("Price");
                Assert.IsNotNull(Price);
                Price.SendKeys("150");
                var Description = driver.FindElementByName("Description");
                Assert.IsNotNull(Description);
                Description.SendKeys("vegetable pizza images. 251,137 vegetable pizza stock photos, vectors, and illustrations are available royalty-free. See vegetable pizza stock video clips. of 2,512.");

                var additem = driver.FindElementByClassName("btn-primary");
                Assert.IsNotNull(additem);
                additem.Click();

            }
        }
    }
}
