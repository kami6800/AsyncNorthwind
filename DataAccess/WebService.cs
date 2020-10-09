using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataAccess
{
    public class WebService
    {
        private string _url = "https://openexchangerates.org/api/latest.json?app_id=1117802588034b33b003dd622c794f8a";

        public WebService()
        {

        }

        public List<ExchangeRate> GetRates()
        {
            List<ExchangeRate> exchange = new List<ExchangeRate>();

            using(WebClient wc = new WebClient())
            {
                string json = wc.DownloadString(_url);

                exchange = JsonConvert.DeserializeObject<List<ExchangeRate>>(json);
            }

            return exchange;
        }

        /*private Task<string> CallWebApi(string url)
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString(_url);

                string exchange = JsonConvert.DeserializeObject<string>(json);

                return json;
            }
        }*/
    }
}
