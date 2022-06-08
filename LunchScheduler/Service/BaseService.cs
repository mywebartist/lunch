using LunchScheduler.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace LunchScheduler.Service
{
    public class BaseService
    {

        HttpClient client;
        public HttpClient _client
        {
            get
            {
                if (client == null)
                {
                    this.client = new HttpClient();
                    this.client.Timeout = TimeSpan.FromSeconds(8);
                    this.client.DefaultRequestHeaders.Clear();
                    this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    this.client.DefaultRequestHeaders.Add("x-apikey", Settings.APIKey);
                }
                return client;
            }
            set
            {
                client = value;
            }
        }

       


    }

  


}
