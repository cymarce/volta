using System;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Security.Principal;

namespace Engineering.UAFClientConnectorLibrary
{
    public class TokenManager
    {
        public TokenManager()
        {
            _hostName = Dns.GetHostEntry(Environment.MachineName).HostName;
            if (_hostName.Contains("."))
                _hostName = _hostName.Remove(_hostName.IndexOf("."));
            _domain = Environment.UserDomainName;
            _loggedUserName = Environment.UserName;
            _loggedUserPassword = "SwqaMe$1";
            _startReq = "http://" + _hostName + "/sit-auth/OAuth/Authorize?client_id=Siemens.SimaticIt.SolutionStudio&redirect_uri=http://" + _hostName + "/sit-ui/system/Studio/default.html&response_type=token&scope=read&state=14326517343870.9801154530141503";
        }

        public TokenManager(string UserName, string UserPW, string Domain, string HostUnified = null)
        {
            if (HostUnified != null)
            {
                _hostName = HostUnified;
                //TestHelper.HostUnified = this._hostName;
            }
            else
                _hostName = Dns.GetHostEntry(Environment.MachineName).HostName;
            _domain = Domain;
            _loggedUserName = UserName;
            _loggedUserPassword = UserPW;
            _startReq = "http://" + _hostName + "/sit-auth/OAuth/Authorize?client_id=123&redirect_uri=http://" + _hostName + "/sit-ui/system/Studio/default.html&response_type=token&scope=read&state=14326517343870.9801154530141503";
        }

        public TokenManager(string HostName, string UserName, string UserPW, string StartReq, string Domain)
        {
            _hostName = HostName;
            _domain = Domain;
            _loggedUserName = UserName;
            _loggedUserPassword = UserPW;
            _startReq = StartReq;
        }

        public string _tokenRenewal { get; private set; }

        public string _hostName { get; set; }

        public string _domain { get; set; }

        public string _loggedUserName { get; set; }

        public string _loggedUserPassword { get; set; }

        public string _startReq { get; set; }

        public string GetToken()
        {
            return GetToken(false);
        }

        public string GetTokenSSL()
        {
            return GetToken(true);
        }

        /// <summary>
        /// Create X.509 signed token
        /// </summary>
        /// <param name="x509Certificate2Collection">Array of certificates</param>
        /// <param name="token">Authentication token</param>
        /// <param name="tokenvalidity">Expiration time (minutes)</param>
        /// <returns>If request succeed</returns>
        public static bool GetWindowsAuthenticationToken(int tokenvalidity, out string token)
        {
            token = string.Empty;

            var now = DateTime.UtcNow;

            var tokenHandler = new JwtSecurityTokenHandler();

            //Logger.WriteLog(Logger.PLMLogEvent.Info, "Start retrieving token");

            try
            {
                var symmetricKey = GetRandomBytes(256 / 8);

                var utcNow = DateTime.UtcNow;
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = WindowsIdentity.GetCurrent(),
                    TokenIssuerName = "urn:unifiedoauth",
                    AppliesToAddress = "urn:unified",
                    Lifetime = new Lifetime(now.AddMinutes(-2), now.AddMinutes(tokenvalidity)),
                    SigningCredentials = new SigningCredentials(
                            new InMemorySymmetricSecurityKey(symmetricKey),
                            "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                            "http://www.w3.org/2001/04/xmlenc#sha256"),


                };

                var securityToken = tokenHandler.CreateToken(tokenDescriptor);

                token = tokenHandler.WriteToken(securityToken);

            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            //Logger.WriteLog(Logger.PLMLogEvent.Info, "Token retrieved, exspires in " + tokenvalidity + " minutes");

            return true;
        }

        private static byte[] GetRandomBytes(int v)
        {
            // Put random bytes into this array.
            byte[] array = new byte[v];
            // Use Random class and NextBytes method.
            Random random = new Random();
            random.NextBytes(array);
            return array;
        }


        /// <summary>
        /// Create X.509 signed token
        /// </summary>
        /// <param name="x509Certificate2Collection">Array of certificates</param>
        /// <param name="token">Authentication token</param>
        /// <param name="tokenvalidity">Expiration time (minutes)</param>
        /// <returns>If request succeed</returns>
        public static bool GetToken(X509Certificate2 certificate, int tokenvalidity, out string token)
        {
            token = string.Empty;

            var now = DateTime.UtcNow;

            var tokenHandler = new JwtSecurityTokenHandler();

            //Logger.WriteLog(Logger.PLMLogEvent.Info, "Start retrieving token");

            try
            {
                var x509SigningCredentials = new X509SigningCredentials(certificate);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject =
                        new ClaimsIdentity(
                            new[]
                            {
                                new Claim(ClaimTypes.Name, certificate.Issuer),
                                new Claim(ClaimTypes.Thumbprint, certificate.Thumbprint),
                                new Claim("urn:realm", "x.509"),
                                new Claim("urn:originator", "AppDAB")
                            }),
                    TokenIssuerName = "urn:unifiedoauth",
                    AppliesToAddress = "urn:unified",
                    Lifetime = new Lifetime(now.AddMinutes(-2), now.AddMinutes(tokenvalidity)),
                    SigningCredentials = x509SigningCredentials
                };

                var securityToken = tokenHandler.CreateToken(tokenDescriptor);

                token = tokenHandler.WriteToken(securityToken);

            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            //Logger.WriteLog(Logger.PLMLogEvent.Info, "Token retrieved, exspires in " + tokenvalidity + " minutes");

            return true;
        }

        private string GetToken(bool ssl)
        {
            string requestUri = (ssl ? "https" : "http") + "://" + _hostName + "/sit-auth/OAuth/token";
            ServicePointManager.ServerCertificateValidationCallback += (RemoteCertificateValidationCallback)((sender, cert, chain, sslPolicyErrors) => true);
            string userName = string.IsNullOrEmpty(_domain) ? _loggedUserName : _domain + "\\" + _loggedUserName;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", (object)"clientID", (object)"clientPsw"))));
                Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
          {
            "grant_type",
            "password"
          },
          {
            "username",
            userName
          },
          {
            "password",
            _loggedUserPassword
          },
          {
            "scope",
            "global"
          }
        };
                HttpResponseMessage result = httpClient.PostAsync(requestUri, (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)dictionary)).Result;
                HttpStatusCode statusCode = result.StatusCode;
                if (!statusCode.Equals((object)HttpStatusCode.Found))
                {
                    statusCode = result.StatusCode;
                    if (!statusCode.Equals((object)HttpStatusCode.OK))
                        throw new Exception("TokenNotFound");
                }
                return JObject.Parse(result.Content.ReadAsStringAsync().Result).Value<string>("access_token");
            }
        }

        public string RetrieveParameterFromHeader(HttpWebResponse Response, string CustomHeader)
        {
            return Response.Headers[CustomHeader];
        }

        public Cookie RetrieveCookieFromResponse(string CookieString)
        {
            string[] strArray = CookieString.Split(new char[2]
            {
        ';',
        '='
            });
            return new Cookie()
            {
                Name = strArray[0],
                Value = strArray[1],
                Path = "/",
                HttpOnly = true,
                Domain = _hostName
            };
        }

        public HttpWebResponse HttpGetMethod(string RequestUri, string GetReferer, CookieContainer RetrievedCookies)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(RequestUri);
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            httpWebRequest.Headers.Add("Accept-Language: it-IT,it;q=0.8,en-US;q=0.6,en;q=0.4");
            httpWebRequest.Referer = GetReferer;
            httpWebRequest.CookieContainer = new CookieContainer();
            httpWebRequest.CookieContainer = RetrievedCookies;
            httpWebRequest.AllowAutoRedirect = false;
            return (HttpWebResponse)httpWebRequest.GetResponse();
        }

        public HttpWebResponse HttpPostMethod(string RequestUri, string PostReferer, byte[] PostBytes, CookieContainer RetrievedCookies)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(RequestUri);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            httpWebRequest.Headers.Add("Accept-Language: it-IT,it;q=0.8,en-US;q=0.6,en;q=0.4");
            httpWebRequest.Method = "POST";
            httpWebRequest.Referer = PostReferer;
            httpWebRequest.AllowAutoRedirect = false;
            httpWebRequest.CookieContainer = new CookieContainer();
            httpWebRequest.CookieContainer = RetrievedCookies;
            Stream requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(PostBytes, 0, PostBytes.Length);
            requestStream.Flush();
            requestStream.Close();
            return (HttpWebResponse)httpWebRequest.GetResponse();
        }

        private static string CheckIfFound(string ResponseData, HttpWebResponse ResponseWeb)
        {
            if (!ResponseWeb.StatusCode.Equals((object)HttpStatusCode.Found) && !ResponseWeb.StatusCode.Equals((object)HttpStatusCode.OK))
                throw new Exception("Token not found");
            Stream responseStream = ResponseWeb.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            ResponseData = streamReader.ReadToEnd();
            streamReader.Close();
            responseStream.Close();
            return ResponseData;
        }

        private void ResponseParamCleanUp(List<AuthResponse> HtmlUMCParamList, ref string HeadingValues, ref byte[] BytesToPost, HttpWebResponse Response)
        {
            HtmlUMCParamList.Clear();
            HeadingValues = string.Empty;
            BytesToPost = new byte[0];
            Response.Close();
        }
    }

    public class AuthResponse
    {
        public string _name { get; set; }

        public string _tagName { get; set; }

        public string _attributeName { get; set; }

        public string _attributeToRetrieve { get; set; }

        public string _value { get; private set; }

        public string SetValueRetrieved(string Value)
        {
            _value = Value;
            return _value;
        }
    }
}





