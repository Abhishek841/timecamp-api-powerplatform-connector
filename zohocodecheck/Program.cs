using System;
using System.Collections.Generic;
using System.Configuration;
using Com.Zoho.API.Authenticator;
using Com.Zoho.API.Authenticator.Store;
using Com.Zoho.Crm.API;
using Com.Zoho.Crm.API.Dc;
using Com.Zoho.Crm.API.Logger;
using System.Net.Http;
using System.Net.Http.Headers;
using Com.Zoho.Crm.API.Record;
using Com.Zoho.Crm.API.Util;
using static Com.Zoho.API.Authenticator.OAuthToken;
using static Com.Zoho.Crm.API.Record.RecordOperations;
using Environment = Com.Zoho.Crm.API.Dc.DataCenter.Environment;
using SDKInitializer = Com.Zoho.Crm.API.Initializer;
using System.Collections.Generic;

namespace zohocodecheck

{
   

    class Program

    {
        private const string GETURL = "https://projectsapi.zoho.com/portal/restapi/portal/745485830/projects/[PROJECTID]/tasks/";
        private const string URL = "https://projectsapi.zoho.com/restapi/portal/745485830/projects/1776534000000141005/tasks/1776534000000141023/logs/";

        static void Main(string[] args)

        {
            //try
            //{
            //    string logpath = ConfigurationManager.AppSettings["Log"];

            //    string emailid = "user1@demo5.mhcg.co.uk";
            //    string clientSecret = ConfigurationManager.AppSettings["client_secret"];

            //    string refreshtoken = ConfigurationManager.AppSettings["refreshtoken"];

            //    string refreshurl = ConfigurationManager.AppSettings["redirect_uri"];

            //    string filepath = ConfigurationManager.AppSettings["oauth_tokens_file_path"];

            //    Logger logger = Logger.GetInstance(Logger.Levels.ALL, logpath);

            //    UserSignature user = new UserSignature(emailid);

            //    string clientid = ConfigurationManager.AppSettings["client_id"];
            //    string resourcePath = "C:\\Task\\csharpsdk-application";

            //    Environment environment = Com.Zoho.Crm.API.Dc.USDataCenter.PRODUCTION;
            //    Token token = new OAuthToken(clientid, clientSecret, refreshtoken, TokenType.GRANT, refreshurl);

            //    TokenStore tokenstore = new FileStore(filepath);

            //    SDKConfig sdkConfig = new SDKConfig.Builder().SetAutoRefreshFields(false).SetPickListValidation(true).Build();

            //    SDKInitializer.Initialize(user, environment, token, tokenstore, sdkConfig, resourcePath, logger);



            //    Console.WriteLine("Fetching records for user - " + SDKInitializer.GetInitializer().User.Email);

            //    RecordOperations recordOperation = new RecordOperations();

            //    APIResponse<ResponseHandler> response = recordOperation.GetRecords("Leads", null, null);

            //    if (response != null)
            //    {
            //        //Get the status code from response
            //        Console.WriteLine("Status Code: " + response.StatusCode);
            //    }


            //}
            //catch (Exception ex)
            //{ }


            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "1000.a61f200551623b73822698185b055161.ceee2cd03fa922382d0735a23c6282f8");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string METHOD = "POST";
                HttpResponseMessage response = null;
                if ("GET".Equals(METHOD))
                {
                    response = client.GetAsync(GETURL).GetAwaiter().GetResult();
                    /*Add params if need in any API
                    private string urlParameters = "?param1=yourparamvalue¶m2=yourparamvalue";
                    response = client.GetAsync(urlParameters).Result;
                    */
                }
                else if ("POST".Equals(METHOD))
                {
                    client.BaseAddress = new Uri(URL);
                    Dictionary<string, string> requestParameters = new Dictionary<string,string>();
                    requestParameters.Add("date", "04-07-2021");
                    requestParameters.Add("owner", "745489501");
                    requestParameters.Add("bill_status", "Billable");
                    requestParameters.Add("hours", "10:20");
                    var reqParams = new FormUrlEncodedContent(requestParameters);
                    response = client.PostAsync(URL, reqParams).GetAwaiter().GetResult();
                }
                // Response HTTP Status Code
                Console.WriteLine("Response HTTP Status Code : " + response.StatusCode);
                // Response Body
                Console.WriteLine("Response Body : " + response.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                client.Dispose();

            }

            catch (Exception ex)
            {
            }
        }
    }

}




