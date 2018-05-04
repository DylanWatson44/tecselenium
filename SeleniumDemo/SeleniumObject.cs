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
using OpenQA.Selenium.Interactions;
using System.Windows.Forms;
using Excel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace SeleniumDemo
{
    class SeleniumObject
    {
        private string user;
        private string password;
        // int pagesTested = 0, pagesPassed = 0
        private string headOrHeadless;
        private string DevProd;

        public SeleniumObject(string vuser, string vpassword, string vheadOrHeadless, string vDevProd)
        {
            user = vuser;
            password = vpassword;
            headOrHeadless = vheadOrHeadless;
            DevProd = vDevProd;

            ChromeOptions options = new ChromeOptions();

            if (headOrHeadless == "headless")
            {

                options.AddArguments("headless", "disable-gpu", "window-size=1900,1200", "--user-agent=New User Agent");
            }
            else
            {
                options.AddArguments("window-size=1900,1200", "--user-agent=New User Agent");
            }


        }
    }
}
