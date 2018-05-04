using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo
{
    class sqlExecuter
    {
        private List<QueryObject> myQueries;
        private string constr = "Data Source=adc-uat-dw01;Initial Catalog=Master;Integrated Security=SSPI;";
        private List<string> rowdata;

        public sqlExecuter(List<QueryObject> queries)
        {
            myQueries = queries;
        }

        public void executeQueries()
        {
        //    public List<string> executeQueries()
        //{
            rowdata = new List<string>();



            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                foreach (QueryObject q in myQueries)
                {

                    Console.WriteLine("\nFetching query data for " + q.GetName());
                    string commandText = q.GetCommand();

                    //spinner animation so one can tell that the program is running
                    bool task1completion = false;
                    var task1 = Task.Run(() =>
                    {
                        SeleniumDemo.spinner.ConsoleSpiner spin = new SeleniumDemo.spinner.ConsoleSpiner();
                        //Console.WriteLine("Working....");
                        while (!task1completion)
                        {
                            spin.Turn();
                        }
                    }
                    );

                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.CommandTimeout = 100000;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string result = string.Format("{0:n0}", reader.GetInt64(0)); ;
                                if (q.GetqueryType() == "Money")
                                {
                                    rowdata.Add("$" + result);
                                    q.SetValue("$" + result);
                                }
                                else
                                {
                                    rowdata.Add(result);
                                    q.SetValue(result);
                                }
                                task1completion = true;
                                Task.WaitAll(new[] { task1 }, 20000);
                                Console.WriteLine("> " + result);
                                
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Requested data fetched");
           // return rowdata;
        }

    }
}
