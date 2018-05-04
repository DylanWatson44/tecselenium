using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo
{
    class KPIpage
    {
        private string url;
        private List<QueryObject> KPIs;

        public KPIpage(string vurl)
        {
            url = vurl;
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
    }
}
