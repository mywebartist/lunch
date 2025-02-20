﻿using LunchScheduler.Helpers;
using LunchScheduler.Model;
using LunchScheduler.Service.ResponseModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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
                    Debug.WriteLine("response: " + responseStr);

                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<LoginResponseModel>(responseStr);
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

        public async Task<ServiceResponseModel> addUserItemsSelectionApi(int organization_id, int[] items, string scheduled_at )
        {

            try
            {
                Uri uri = new Uri(ConfigService.addUserItemsSelectionUrl);

                var data = string.Join(",", items);

                JArray jArr = new JArray();
                jArr.Add( items);

                JObject jObj = new JObject();
                jObj.Add("organization_id", organization_id);
                jObj.Add("items_ids", "[" + data + "]");
                jObj.Add("scheduled_at", scheduled_at);

                var payload = new StringContent(jObj.ToString(), Encoding.UTF8, "application/json");
                var result = await _client.PostAsync(uri, payload);


                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);

                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<ServiceResponseModel>(responseStr);
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

        public async Task<ItemsResponseModel> getUserSelectedItemsApi(int organization_id)
        {
            try
            {
                Uri uri = new Uri(ConfigService.userItemsSelectionUrl + "?organization_id=" + organization_id);

                var result = await _client.GetAsync(uri);

                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);
                    
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
        public async Task<ChefOrderResponseModel> getOrdersApi(int organization_id)
        {

            try
            {
                Uri uri = new Uri(ConfigService.getOrdersUrl + "?organization_id=" + organization_id);

                var result = await _client.GetAsync(uri);

                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);

                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<ChefOrderResponseModel>(responseStr);
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

        public async Task<OrganizationsListResponseModel> getOrganizationsListApi()
        {

            try
            {
                Uri uri = new Uri(ConfigService.orgsUrl);

                var result = await _client.GetAsync(uri);

                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);
 
                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<OrganizationsListResponseModel>(responseStr);
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

        public async Task<UsersListResponseModel> getUsersListApi()
        {

            try
            {
                Uri uri = new Uri(ConfigService.orgUsersUrl + "?organization_id=" + Settings.ActiveOrganizationId);

                var result = await _client.GetAsync(uri);

                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);

                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<UsersListResponseModel>(responseStr);
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

        public async Task<OrganizationItemsListResponseModel> getOrganizationsItemsListApi()
        {
            try
            {
                Uri uri = new Uri(ConfigService.itemsUrl + "?organization_id=" + Settings.ActiveOrganizationId);

                var result = await _client.GetAsync(uri);

                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);
  
                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<OrganizationItemsListResponseModel>(responseStr);
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



        public async Task<ServiceResponseModel> UserJoinOrgApi(string organization_id)
        {

            try
            {
                Uri uri = new Uri(ConfigService.userJoinOrgUrl);

                JObject jObj = new JObject();
                jObj.Add("organization_id", organization_id);

                var payload = new StringContent(jObj.ToString(), Encoding.UTF8, "application/json");
                var result = await _client.PostAsync(uri, payload);

                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);

                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<ServiceResponseModel>(responseStr);
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


        public async Task<UserModel> getUserProfileApi()
        {

            try
            {
                Uri uri = new Uri(ConfigService.userProfileUrl);

                var result = await _client.GetAsync(uri);

                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);

                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<UserModel>(responseStr);
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


        public async Task<UserModel> updateUserNameProfileApi(string name)
        {

            try
            {
                Uri uri = new Uri(ConfigService.userProfileUrl);


                JObject jObj = new JObject();
                jObj.Add("name", name);

                StringContent content = new StringContent(jObj.ToString(), Encoding.UTF8, "application/json");

                var result = await _client.PutAsync(uri, content);

                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);

                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<UserModel>(responseStr);
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

        public async Task<UserModel> updateMenuItemApi(int id, string name, string description)
        {

            try
            {
                Uri uri = new Uri(ConfigService.itemsUrl + "/" + id);


                JObject jObj = new JObject();
                jObj.Add("name", name);
                jObj.Add("description", description);

                StringContent content = new StringContent(jObj.ToString(), Encoding.UTF8, "application/json");

                var result = await _client.PutAsync(uri, content);

                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);

                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<UserModel>(responseStr);
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

        public async Task<UserModel> updateUserProfileApi(int default_org)
        {

            try
            {
                Uri uri = new Uri(ConfigService.userProfileUrl);


                JObject jObj = new JObject();
                jObj.Add("default_org", default_org);

                StringContent content = new StringContent(jObj.ToString(), Encoding.UTF8, "application/json");

                var result = await _client.PutAsync(uri, content);

                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);

                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<UserModel>(responseStr);
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

        public async Task<ItemModel> AddItemApi(string organization_id, string itemName, string itemDescription)
        {

            try
            {
                Uri uri = new Uri(ConfigService.itemsUrl);

                JObject jObj = new JObject();
                jObj.Add("name", itemName);
                jObj.Add("description", itemDescription);
                jObj.Add("organization_id", organization_id);

                var payload = new StringContent(jObj.ToString(), Encoding.UTF8, "application/json");
                var result = await _client.PostAsync(uri, payload);


                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);

                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<ItemModel>(responseStr);
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

        public async Task<OrganizationModel> AddNewOrgApi(string orgName, string orgDescription)
        {

            try
            {
                Uri uri = new Uri(ConfigService.orgsUrl);

                JObject jObj = new JObject();
                jObj.Add("name", orgName);
                jObj.Add("description", orgDescription);

                var payload = new StringContent(jObj.ToString(), Encoding.UTF8, "application/json");
                var result = await _client.PostAsync(uri, payload);


                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);

                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<OrganizationModel>(responseStr);
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

        public async Task<OrganizationModel> getUserOrgsApi()
        {

            try
            {
                Uri uri = new Uri(ConfigService.userProfileUrl);

                var result = await _client.GetAsync(uri);

                if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseStr = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine("response: " + responseStr);

                    var responseObj = await Task.Run(() =>
                    {
                        return JsonConvert.DeserializeObject<OrganizationModel>(responseStr);
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
