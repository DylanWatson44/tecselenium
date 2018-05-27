using System;

namespace SeleniumDemo
{
    /// <summary>
    /// Class representing all the values associated with a sql query needed for our kpi test
    /// </summary>
    public class QueryObject
    {
        private string QueryName;
        private string QueryCommand;
        private string QueryType;
        public bool valueMustBeUpdated = false;
        private string queryValue;
        private int testID;
        private string actualValue;
        private bool passed;
        public event EventHandler<TestResultEvent> resultReturnedEvent;

        public QueryObject(string QC, string QT, string QN, int ID)
        {
            QueryCommand = QC;
            QueryType = QT;
            QueryName = QN;
            testID = ID;
        }
        public string getQueryName()
        {
            return QueryName;
        }
        public string GetCommand()
        {
            return QueryCommand;
        }
        public void setActual(string value)
        {
            actualValue = value;
        }

        public string GetqueryType()
        {
            return QueryType;
        }

        public string GetName()
        {
            return QueryName;
        }
        public void SetValue(string val)
        {
            queryValue = val;
        }
        public string GetValue()
        {
            return queryValue;
        }
        public int GetID()
        {
            return testID;
        }

        public string formUpdateCommandValue(string DevProd)
        {
            string command = "\nUPDATE DWControl.dbo.AppTestTable SET [Query Result " + DevProd + "] = '" + GetValue() + "' Where TestID = " + GetID();

            return command;
        }
        public string formUpdateCommandPassFail(string DevProd, bool passed)
        {
            string command = "\nUPDATE DWControl.dbo.AppTestTable SET [Last Test Passed " + DevProd + "] = '" + passed.ToString() + "' Where TestID = " + GetID();
            return command;
        }
        public string formUpdateCommandDateLastPassed(string DevProd, string date)
        {
            string command = "\nUPDATE DWControl.dbo.AppTestTable SET [Date Last Passed " + DevProd + "] = '" + date + "' Where TestID = " + GetID();
            return command;
        }
        public string formUpdateCommandActual()
        {
            string command = "\nUPDATE DWControl.dbo.AppTestTable SET [Actual value found for last test] = '" + actualValue + "' Where TestID = " + GetID();
            return command;
        }
        public void setPassed(bool b)
        {
            passed = b;
            OnRaiseCustomEvent(new TestResultEvent(b));
        }
        protected virtual void OnRaiseCustomEvent(TestResultEvent e)
        {
            EventHandler<TestResultEvent> handler = resultReturnedEvent;
            if(handler != null)
            {      
                handler(this, e);
            }
        }
    }

    /// <summary>
    /// A class to return the result of a test in the form of a boolean: result.
    /// </summary>
    public class TestResultEvent : EventArgs
    {
        private bool result;
        public TestResultEvent(bool res)
        {
            result = res;
        }
        public bool getResult()
        {
            return result;
        }
    }
}
