using LunchScheduler.Service.ResponseModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LunchScheduler.Service
{
    public class AccountService : BaseService
    {

        public async Task<LoginResponseModel> LoginApi(string email)
        {

            try
            {
                Uri uri = new Uri(ConfigService.loginUrl);

                JObject jObj = new JObject();
                jObj.Add("email", email);

                var payload = new StringContent(jObj.ToString(), Encoding.UTF8, "application/json");
                var result = await _client.PostAsync(uri, payload);

              
                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine( "response: " +responseStr);
       
                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<LoginResponseModel>(responseStr);
                    });
                    return responseObj;

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("response_error: "+  e.Message);
   
            }

            return null;

        }



        public async Task<ItemsResponseModel> getItemsApi(int organization_id)
        {

            try
            {
                Uri uri = new Uri(ConfigService.itemsUrl + "?organization_id=" + organization_id);
  
                var result = await _client.GetAsync(uri);

                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);
                    //Console.WriteLine(responseStr);
                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<ItemsResponseModel>(responseStr);
                    });
                    return responseObj;

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("response_error: " + e.Message);
                
            }

            return null;

        }

        public async Task<PinResponseModel> getAccessToken(string pinCode)
        {

            try
            {
                Uri uri = new Uri(ConfigService.accessCodeUrl);

                JObject jObj = new JObject();
                jObj.Add("pin", pinCode);

                var payload = new StringContent(jObj.ToString(), Encoding.UTF8, "application/json");
                var result = await _client.PostAsync(uri, payload);

                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);
                    //Console.WriteLine(responseStr);
                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<PinResponseModel>(responseStr);
                    });
                    return responseObj;

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("response_error: " + e.Message);

            }

            return null;

        }






    }
}
