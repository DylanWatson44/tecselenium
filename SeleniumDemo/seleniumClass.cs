using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;
using Excel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;


namespace SeleniumDemo
{
    public class seleniumHandler
    {
        // private string seleniumPath = "C:\\xInstall\\Selenium\\SeleniumTestOutput\\";
        private string baseURL;
        private static string user = "dwatson"; //tec\\dwatson
        private static string password = "1silverfireNEW!";
        //private string driverType; // should be "browser" or "headless"
        public RemoteWebDriver webdriver;
        private WebDriverWait wait;

        /// <summary>
        /// Make a new selenium handler, go to specified url, and log in. 
        /// driverType should be  browser or headless
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="driverType"></param>
        public seleniumHandler(string Url, string driverType)
        {
            ChromeOptions options = new ChromeOptions();

            if (driverType == "headless")
            {
                options.AddArguments("headless", "disable-gpu", "window-size=1900,1200", "--user-agent=New User Agent");
            }
            else
            {
                options.AddArguments("window-size=1900,1200", "--user-agent=New User Agent");
            }
            //Console.WriteLine("File " + System.IO.Path.GetDirectoryName(Application.ExecutablePath));
            //Console.WriteLine("File " + System.IO.Path.GetDirectoryName(Application.StartupPath));

            webdriver = new ChromeDriver("Resources\\packages", options);
          //  webdriver = new ChromeDriver("..\\..\\..\\packages", options);
            baseURL = Url;

            wait = new WebDriverWait(webdriver, TimeSpan.FromMilliseconds(2000));

            webdriver.Navigate().GoToUrl(baseURL);

            loginSelenium();
        }

        /// <summary>
        /// Do all the tests
        /// </summary>
        /// <param name="overRide"></param>
        /// <param name="DevProd"></param>
        /// <param name="Headless"></param>
        /// <param name="filters"></param>
        public static bool doTests(string username, string pass, bool overRide, string DevProdstring, string Headless, MasterSqlTableObj mst)
        {
            user = "tec\\" + username;
            password = pass;
            int pagesTested = 0, pagesPassed = 0;
            Stopwatch watch = new Stopwatch();
            string headOrHeadless = Headless;
            watch.Start();
            string bigupdatestatement = "";
            string DevProd = DevProdstring;
      
            string date = mst.date;

            List<KPIpage> Kpipages = mst.KPIpages;
            string baseUrl = "http://bi-dev/hub/stream/107d4dc1-f574-4e22-bd0b-39c483cb51f4";
            seleniumHandler mySelenium = new seleniumHandler(baseUrl, headOrHeadless);

            //foreach url in the dictionary, test its list of queryobjects
            foreach (KPIpage KP in Kpipages)
            {
                TimeSpan time = watch.Elapsed;
               
                if (KP.getKPIs().Count == 0)
                {
                    Console.WriteLine("No queries to test for url: \n" + KP.getUrl() + "\n");
                }
                else
                {
                    List<QueryObject> toBeUpdatedQOs = new List<QueryObject>();
                    List<string> valuesToTest = new List<string>();
                    //  foreach (QueryObject QO in pair.Value)
                    foreach (QueryObject QO in KP.getKPIs())
                    {
                        if (QO.valueMustBeUpdated == true)
                        {
                            toBeUpdatedQOs.Add(QO);
                        }
                        else
                        {
                            Console.WriteLine("\nUsing previously stored value for " + QO.GetName() + "\n>" + QO.GetValue());
                            //valuesToTest.Add(QO.GetValue());
                        }
                    }
                    pagesTested++;
                    // mySelenium.GotoUrl(pair.Key);
                    mySelenium.GotoUrl(KP.getUrl());
                    var waittask = Task.Run(() =>
                    {
                        bool bl = true;
                        while (bl)
                        {
                            //loop to make the program stall while it waits for the page to load
                            try
                            {
                                //mySelenium.webdriver.FindElementByXPath("//div[@id='qv-init-ui-blocker' and @style='display: none;']");
                                mySelenium.webdriver.FindElementByXPath("//div[@class='rain rain-loader qv - block - ui ng - scope']");
                                bl = false;
                                System.Threading.Thread.Sleep(500);
                            }
                            catch (Exception e)
                            {
                                //System.Threading.Thread.Sleep(500);
                            }
                        }
                    });

                    sqlExecuter Executer = new sqlExecuter(toBeUpdatedQOs);

                    Executer.executeQueries();

                    foreach (QueryObject QO in toBeUpdatedQOs)
                    {
                        bigupdatestatement += QO.formUpdateCommandValue(DevProd);
                    }

                    int KpisPassed = 0, KpisTested = 0;
                    Task.WaitAll(new[] { waittask }, 9000);
                    bigupdatestatement += mySelenium.ListKPIs(KP.getKPIs());
                    foreach (QueryObject QO in KP.getKPIs())
                    {
                        try
                        {
                            KpisTested++;
                            mySelenium.highlightKPI(QO.GetValue());
                            KpisPassed++;
                            bigupdatestatement += QO.formUpdateCommandPassFail(DevProd, true);
                            bigupdatestatement += QO.formUpdateCommandDateLastPassed(DevProd, date);
                            QO.setPassed(true);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Failed to find kpi with value: " + QO.GetValue() + "\n");
                            mySelenium.highlightKPIred(QO);
                            
                            bigupdatestatement += QO.formUpdateCommandPassFail(DevProd, false);
                            QO.setPassed(false);
                        }
                    }
                    pagesPassed = KpisPassed == KpisTested ? pagesPassed + 1 : pagesPassed;
                    Console.WriteLine("\n" + KpisPassed + "/" + KpisTested + " KPIs found correctly for url: \n" + KP.getUrl() + "\n");
                    KpisPassed = 0;
                    KpisTested = 0;
                    Console.WriteLine("Time taken for this page= " + (watch.Elapsed - time));

                    if (headOrHeadless == "browser")
                    {
                        System.Threading.Thread.Sleep(2500);
                    }
                }
            }
            mst.updateEverythingElse(bigupdatestatement);
            watch.Stop();
            Console.WriteLine(pagesPassed + " out of " + pagesTested + " passed.");
            Console.WriteLine("Total time elapsed= {0}", watch.Elapsed);
            mySelenium.webdriver.Quit();
            //if(pagesPassed == pagesTested)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return pagesPassed == pagesTested;
        }
        /// <summary>
        /// 
        /// </summary>
        public void loginSelenium()
        {
            Console.WriteLine("\nLogging in...\n");
            System.Threading.Thread.Sleep(1000);
            //wait.Until(driver1 => ((IJavaScriptExecutor)webdriver).ExecuteScript("return document.readyState").Equals("complete"));
            webdriver.FindElementByXPath("//*[@id='login-form']/input[1]").SendKeys(user);
            System.Threading.Thread.Sleep(500);

            webdriver.FindElementByXPath("//*[@id='login-form']/input[2]").SendKeys(password);
            System.Threading.Thread.Sleep(500);

            webdriver.FindElementByXPath("//*[@id='loginbtn']").Click();
            System.Threading.Thread.Sleep(5000);
        }

       
        public void find_and_highlight_element(string xPath, string methodName)
        {
            highlightElement(xPath, methodName);
        }

        /// <summary>
        ///  Saves a snapshot of the browser and saves the jpeg to a specific file path. Can run in headless mode
        /// </summary>
        /// <param name="BrowserInstance"></param>
        /// <param name="Path"></param>
        /// <param name="FileName"></param>
        /// <param name="Format"></param>
        //private void TakeBrowserSnapshot(RemoteWebDriver BrowserInstance, string Path, string FileName, OpenQA.Selenium.ScreenshotImageFormat Format)
        //{

        //    ScreenCounter++; //Updates the number of screenshots that we took during the execution

        //    StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss.fff"));

        //    DirectoryInfo Validation = new DirectoryInfo(Path); //System IO object

        //    if (Validation.Exists == true)
        //    { //Capture screen if the path is available

        //        ((OpenQA.Selenium.ITakesScreenshot)BrowserInstance).GetScreenshot().SaveAsFile(Path + FileName + "." + ScreenCounter.ToString() + "." + TimeAndDate.ToString() + "." + Format, Format);

        //    }

        //    else //Create the folder and then Capture the screen
        //    {
        //        Validation.Create();

        //        ((OpenQA.Selenium.ITakesScreenshot)BrowserInstance).GetScreenshot().SaveAsFile(Path + FileName + "." + ScreenCounter.ToString() + "." + TimeAndDate.ToString() + "." + Format, Format);
        //    }
        //}

        /// <summary>
        /// Finds a web element using a n xpath, then sets that element to have a green background.
        /// </summary>
        /// <param name="elementString"></param>
        /// <param name="methodName"></param>
        private void highlightElement(string elementString, string methodName)
        {
            IWebElement element = webdriver.FindElement(OpenQA.Selenium.By.XPath(elementString));
            webdriver.ExecuteScript("arguments[0].setAttribute('style', arguments[1]); ", element, "background-color: rgba(0, 255, 0, 0.3);"); // Green
        }

        private void highlightKPI(string value)
        {
            IWebElement element = webdriver.FindElement(OpenQA.Selenium.By.XPath("//span[@class='ng-binding' and @title='" + value + "']"));  
            webdriver.ExecuteScript("arguments[0].setAttribute('style', arguments[1]); ", element, "background-color: rgba(0, 255, 0, 0.3);"); // Green
        }
        private void highlightKPIred(QueryObject QO) {
            try {
                IWebElement element = webdriver.FindElement(OpenQA.Selenium.By.XPath("//div[@class='measure-title ellips-text' and @title='" + QO.getQueryName() + "']/parent::*/parent::*"));
                webdriver.ExecuteScript("arguments[0].setAttribute('style', arguments[1]); ", element, "background-color: rgba(255, 0, 0, 0.3);"); //Red
            }catch(Exception e)
            {
                Console.WriteLine("Couldn't find desired KPI at all (highlight failed!)");
            }
        }

        /// <summary>
        /// Method to both output to the console which Kpis discoverable on the page, as well as update the actual value field for a query object.
        /// </summary>
        /// <param name="QOlist"></param>
        /// <returns></returns>
        private string ListKPIs(List<QueryObject> QOlist)
        {
            string returncommandstring = "";
            IList<IWebElement> elementlist = new List<IWebElement>();
            foreach (IWebElement ele in webdriver.FindElementsByXPath("//span[@class='ng-binding']"))
            {
                elementlist.Add(ele);
                Console.WriteLine("\nwebelement found: " + ele.Text);
            }
            for(int i = 0; i < elementlist.Count;i++)
            {
                foreach(QueryObject QO in QOlist)
                {
                    if(elementlist[i].Text == QO.getQueryName())
                    {
                        QO.setActual(elementlist[i+1].Text);
                        returncommandstring += QO.formUpdateCommandActual();
                    }
                }
            }
            return returncommandstring;
        }

        /// <summary>
        /// Unused method for downloading data from a qlik chart.
        /// </summary>
        /// <param name="elementString"></param>
        private void rightclickelement(string elementString)
        {
            System.Threading.Thread.Sleep(500);
            Actions action = new Actions(webdriver);
            IWebElement element = webdriver.FindElement(OpenQA.Selenium.By.XPath(elementString));

            action.ContextClick(element).Build().Perform();
            System.Threading.Thread.Sleep(500);
            webdriver.FindElement(OpenQA.Selenium.By.XPath("//span[@class='lui-list__text ng-binding' and @title='Export data']")).Click();
            System.Threading.Thread.Sleep(500);

            IWebElement downloadelement = webdriver.FindElement(OpenQA.Selenium.By.XPath("//a[@target='_blank']"));
            string filestring = downloadelement.GetAttribute("href");
            int firstsub = filestring.LastIndexOf("/");
            int lastsub = filestring.IndexOf("?");
            int length = lastsub - firstsub - 1;

            string filename = filestring.Substring(firstsub + 1, length);
            Console.WriteLine(filename);
            //Console.ReadLine();
            System.Threading.Thread.Sleep(2000);


            downloadelement.Click();

            //SendKeys.SendWait("{ENTER}");
            System.Threading.Thread.Sleep(2000);

            int counter = 0;
            foreach (var worksheet in Workbook.Worksheets(@"C:\Users\xpdwatson\Downloads\" + filename))
            {
                Console.WriteLine(worksheet.ToString());
                foreach (var row in worksheet.Rows)
                {
                    foreach (var cell in row.Cells)
                    {
                        if (counter < 24 && counter % 2 == 0)
                        {
                            counter++;
                            Console.Write(cell.Text + " | ");
                        }
                        else if (counter < 24)
                        {
                            counter++;
                            int value;
                            if (!int.TryParse(cell.Text, out value))
                            {
                                Console.WriteLine(cell.Text + " ");
                            }
                            else
                            {
                                Console.WriteLine(cell.Value);
                            }
                        }
                    }
                }
            }
            Console.ReadLine();
            //var colnames = book.GetColumnNames(worknames[0]);
            // The 'Microsoft.ACE.OLEDB.12.0' provider is not registered on the local machine.
        }

        public void GotoUrl(string url)
        {
            Console.WriteLine("Going to address: " + url);
            webdriver.Navigate().GoToUrl(url);
        }

        //variables in the program: file path to web driver (should be relative, might have to change for .exe), log in details (name, password),
        //data sources (currently using Data Source=ADC-DEV-DWVM15 and Data Source=adc-uat-dw01),
        //dataOverride, filters, devprod, and HeadOrHeadless mode
        static int Main(string[] args)
        {
            //string[] AppsToIgnore = new string[2] { "149", "72" }; // { 149, 72, 109, 110, 91, 92 } 

            string headOrHeadless = "browser";
            bool overRide = false;
            string DevProd = "Dev";
            if (doTests(user, password, overRide, DevProd, headOrHeadless, null) == true)
            {
                return 0;
            }
            else return 1;
        }
    }
}
