using System.Collections.Generic;

namespace SeleniumDemo
{
    public class KPIpage
    {
        private string url;
        private string appName;
        private List<QueryObject> KPIs;

        public KPIpage(string vurl, string vname)
        {
            url = vurl;
            appName = vname;
            KPIs = new List<QueryObject>();
        }

        public void addKPI(QueryObject QO)
        {
            KPIs.Add(QO);
        }
        public List<QueryObject> getKPIs()
        {
            return KPIs;
        }
        public string getUrl()
        {
            return url;
        }
        public string getAppName()
        {
            return appName;
        }
    }
}
