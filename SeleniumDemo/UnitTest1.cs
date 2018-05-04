
namespace SeleniumDemo
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;
    using System.IO;
    using System.Collections;
    //using System.Drawing.Imaging;
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;


    [TestClass]
    public class testClass
    {
        private static seleniumHandler handle;
        public TestContext TestContext { get; set; }

        [ClassInitialize()]
        public static void MyTestInitialize(TestContext tc)
        {
            tc.WriteLine("Beginning tests...");
           // Console.ReadKey();
            string baseUrl = "http://bi-dev/sense/app/9fab24a5-9c52-451e-b4cf-0a52a2176391/sheet/e4d1adce-b4bd-49f1-a008-78ba3b04e93e/state/analysis";
            handle = new seleniumHandler(baseUrl, "browser");
        }

        [TestMethod()]
        [TestCategory("Selenium")]
        [Priority(1)]
        [Owner("Chrome")]
        public void Number_of_learners()
        {
            string currentMethodName = this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            //string myXPath = "//div[(@class='kpi-data') and ((.//div/@class = 'measure-title ellips-text') and (.//div/@title = 'Number of learners') )]//span[@class='ng-binding' and @title='2,456,530']";
            string myXPath = "//span[@class='ng-binding' and @title='2,456,530']";
            handle.find_and_highlight_element(myXPath, currentMethodName);

            
        }

        [TestMethod()]
        [TestCategory("Selenium")]
        [Priority(2)]
        [Owner("Chrome")]
        public void Volume_of_Delivery_EFTS()
        {
            string currentMethodName = this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string myXPath = "//div[(@class='kpi-data') and ((.//div/@class = 'measure-title ellips-text') and (.//div/@title = 'Volume of delivery (EFTS)') )]//span[@class='ng-binding' and @title='3,571,830']";
            handle.find_and_highlight_element(myXPath, currentMethodName);
        }
        [TestMethod()]
        [TestCategory("Selenium")]
        [Priority(3)]
        [Owner("Chrome")]
        public void Value_of_Delivery()
        {
            string currentMethodName = this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string myXPath = "//span[@class='ng-binding' and @title='$28,464,473,909']";
            handle.find_and_highlight_element(myXPath, currentMethodName);
        }

        //   [TestMethod()]
        public void Volume_of_Delivery_EFTS_Failure()
        {
            string currentMethodName = this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name;
            string myXPath = "//div[(@class='kpi-datazzzzzzzzzzzzzzzzz') and ((.//div/@class = 'measure-title ellips-text') and (.//div/@title = 'Volume of delivery (EFTS)') )]//span[@class='ng-binding' and @title='3,571,830']";
            handle.find_and_highlight_element(myXPath, currentMethodName);
        }

        //   [TestCleanup()]
        public void MyTestCleanup()
        {
            handle.webdriver.Close();
            handle.webdriver.Quit();
        }
    }
}

