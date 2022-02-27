using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace FenixMusic
{
    class Helper
    {
        public bool check_url(string url)
        {
            bool response = false;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)webRequest.GetResponse();
                resp.Close();
                response = true;
            }
            catch (WebException e)
            {
                response = false;
            }
            return response;
        }
    }
}
