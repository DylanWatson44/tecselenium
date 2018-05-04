using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo
{
    class MasterSqlTableObj
    {
        public List<KPIpage> KPIpages = new List<KPIpage>();

        public List<string> Urls = new List<string>();
        // public List<int> AppsToIgnore = new List<int>() { }; // { 149, 72, 109, 110, 91, 92 } 
        public List<int> AppsToIgnore;
        private static string constr = "Data Source=ADC-DEV-DWVM15;Initial Catalog=Master;Integrated Security=SSPI;MultipleActiveResultSets=True";
        private string DevOrProd;
        public string date;
        public string reallylongcommand = "";
        public bool updateOverride = false;
        public string lastignore;

        public MasterSqlTableObj(string devprod, bool Override, List<int> filterlist)
        {
            updateOverride = Override;
            date = DateTime.Now.ToString("yyyy-MM-dd");
            Console.WriteLine(date);
            DevOrProd = devprod;

            AppsToIgnore = filterlist;
            if (filterlist == null)
            {
                AppsToIgnore = new List<int>();
            }

            string commandText = @"SELECT * FROM [DWControl].[dbo].[AppTestTable]";

            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                Console.WriteLine("Fetching All urls to test and their associated queries...\n");

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<QueryObject> currentQOList = null;

                        while (reader.Read())
                        {
                            int appId = reader.GetInt32(0);

                            if (!AppsToIgnore.Contains(appId))
                            {
                                Console.WriteLine("Reading data for query with ID number: " + reader.GetInt32(14));

                                int urlToRead;
                                urlToRead = DevOrProd == "Dev" ? 2 : 3;

                                int valueToRead;
                                valueToRead = DevOrProd == "Dev" ? 8 : 9;

                                string url = reader.GetString(urlToRead);

                                //if the list of urls does not already have this url, add the url to 
                                //our list and make a new list of queryobjects to associate to it in the dictionary
                                if (!Urls.Contains(url))
                                {
                                    KPIpage page = new KPIpage(url);
                                   // Console.WriteLine("New Url found, filling dictionary with queries");
                                    Urls.Add(url);
                                    KPIpages.Add(page);
                                    currentQOList = page.getKPIs();

                                }

                                if (reader.GetString(4) != "Not set")
                                {
                                    QueryObject QO = new QueryObject(reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(14));

                                    //attempt to set the value for this query object, if it fails the table value is probably null so we set the QO value to null.
                                    try
                                    {
                                        QO.SetValue(reader.GetString(valueToRead));
                                    }
                                    catch (Exception e)
                                    {
                                        QO.SetValue(null);
                                    }

                                    currentQOList.Add(QO);

                                    //check to see if the last time this object was checked was today. If it wasnt, then set the object to be updated (later) and update when it was 
                                    //last checked to today (these update commands are all added to one long string that gets executed once instead of using several executions)
                                    try
                                    {

                                        if (reader.GetDateTime(7).ToString("yyyy-MM-dd") != date)
                                        {
                                            //Console.WriteLine("Test " + reader.GetDateTime(7).ToString("yyyy-MM-dd") + "date " + date);
                                            QO.valueMustBeUpdated = true;
                                            addCommand(QO, url);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Error with date, most likely set to NULL in database");
                                        QO.valueMustBeUpdated = true;
                                        addCommand(QO, url);
                                    }
                                    if (updateOverride)
                                    {
                                        Console.WriteLine("update override is ON! Program will fetch values from database and re-update them");
                                        QO.valueMustBeUpdated = true;
                                    }
                                }

                            }
                            else
                            {
                                if (lastignore != ("App " + appId + " ignored\n"))
                                {
                                    Console.WriteLine("App " + appId + " ignored\n");
                                    lastignore = "App " + appId + " ignored\n";
                                }
                            }
                        }
                        reader.Close();
                        Console.WriteLine("All queries scanned");
                        if (reallylongcommand != "")
                        {
                            updateDates();
                        }
                    }
                }
            }

        }
        private void addCommand(QueryObject QO, string url)
        {
            string commandText = "\nUPDATE DWControl.dbo.AppTestTable SET [Last Date Tested] = '" + date + "' Where " + DevOrProd + "Url = '" + url + "' and [KPI Name] = '" + QO.GetName() + "'";
            reallylongcommand += commandText;
        }

        private void updateDates()
        {
            Console.WriteLine("\nAttempting to update dates...");
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(reallylongcommand, connection))
                {
                    SqlTransaction transaction;
                    transaction = connection.BeginTransaction("A transaction");
                    command.Transaction = transaction;
                    //command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                    command.Transaction.Commit();
                    connection.Close();
                }

            }
        }

        public void updateEverythingElse(string longcommand)
        {
            Console.WriteLine("Attempting to update test results...");
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(longcommand, connection))
                {
                    SqlTransaction transaction;
                    transaction = connection.BeginTransaction("A transaction");
                    command.Transaction = transaction;
                    //command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                    command.Transaction.Commit();
                    connection.Close();
                    Console.WriteLine("Update successful");
                }

            }
        }

    }
}
