using Engineering.UAFClientConnectorLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string token;
            string error;
            TokenManager.GetWindowsAuthenticationToken(100, out token);
            var response = Get($"{SitSvcEngPath}PublicUsers", token, out error);

        }


        private const string SitSvcEngPath = "http://localhost/sit-svc/engineering/odata/";

        //public IQueryable<TEntity> EngineeringProjectionQuery<TEntity>(string odataQuery) where TEntity : IPrimitiveEntity
        //{

        //    string entityName = typeof(TEntity).Name;
        //    string error;
        //    string sitSvcEngPath = string.Format(SitSvcEngPath, HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host);
        //    var response = Get($"{sitSvcEngPath}{entityName}{odataQuery}", _token, out error);
        //    if (string.IsNullOrEmpty(response))
        //    {
        //        return new List<TEntity>().AsQueryable();
        //    }
        //    return JsonConvert.DeserializeObject<OdataQueryResult<List<TEntity>>>(response).value.AsQueryable();
        //}

        


        private static string Get(string url, string token, out string err)
        {
            try
            {
                string output = string.Empty;
                err = string.Empty;
                bool flag = true;
                HttpWebRequest httpWebRequest;

                string statusDescription = string.Empty;

                WebResponse response = null;
                bool authorized = false;
                int retry = 0;
                while (!authorized)
                {
                    if (retry >= 3) break;
                    try
                    {
                        httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                        httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                        httpWebRequest.Accept = "application/json, text/plain, */*";
                        httpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, sdch*");
                        httpWebRequest.Timeout = -1;
                        httpWebRequest.Method = "GET";
                        response = httpWebRequest.GetResponse();
                    }
                    catch (WebException ex)
                    {
                        response = ex.Response;
                        flag = false;
                    }

                    statusDescription = ((HttpWebResponse)response).StatusDescription;
                    authorized = statusDescription != "Unauthorized";
                    if (!authorized)
                    {
                        token = string.Empty;
                    }
                    retry++;
                }

                if (response != null)
                {
                    Stream responseStream = response.GetResponseStream();
                    using (var streamreader = new StreamReader(responseStream))
                    {
                        string str3 = streamreader.ReadToEnd();
                        if (!flag)
                        {
                            err = str3;
                        }
                        else
                        {
                            output = str3;
                        }
                        responseStream.Close();
                        //response.Close();
                    }
                }
                else
                {
                    err = "Null Response";
                }
                return output;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return string.Empty;
            }
        }
    }
}
