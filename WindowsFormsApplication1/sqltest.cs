using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class sqltest
    {
        public sqltest()
        {

        }
        public BindingSource getBindingSource()
        {
           // old working sql command string commandText = "SELECT * FROM sys.databases";
            string commandText = @"SELECT                 
                    cast(round(SUM([Value of Units of Learning])*2,-1)/2 as bigint) as 'Value of Delivery',
                    cast(round(SUM([Units of Learning])*2,-1)/2 as bigint) As 'Volume Of delivery',
                    round(Count(Distinct [NSN])*2,-1)/2  as 'Number Of Students'
                
                    FROM DW.presentation.learner_TertiaryProvision Where [Reporting Year]>'2010'
                    AND [Funding Source] NOT IN ('02 - International Fee-Paying Student',
                    '03 - Domestic Full Fee Paying Student',
                    '05 - S.T.A.R. Funded Student',
                    '06 - Training Opportunities (also includes Training for Work)',
                    '07 - Youth Training - Ceased 31/12/2011; refer to Youth Guarantee',
                    '09 - Prison Education (Department of Corrections)',
                    '10 - Ministry of Health','11 - I.T.O. Off Job Training',
                    '12 - Other (including other contracts)',
                    '15 - Secondary Pre-Service Teacher Education Contracts',
                    '20 - NZAID and Commonwealth Scholarships',
                    '21 - ITO Off Job Training Foreign Student',
                    '31 - Non-funded confirmed student enrolments')";

            string constr = "Data Source=adc-uat-dw01;Initial Catalog=Master;Integrated Security=SSPI;";

            BindingSource oBindingSource = new BindingSource();

            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = commandText;
                    //cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    

                    dataAdapter.Fill(dataTable);
                    oBindingSource.DataSource = dataTable;
                   

                    //wsPrograms.Load(cmd.ExecuteReader());
                    //dataGridView2.DataSource = wsPrograms;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    con.Close();
                }
            }
            return oBindingSource;
        }

        //static void Main(string[] args)
        //{
           
        //}
    }
}
