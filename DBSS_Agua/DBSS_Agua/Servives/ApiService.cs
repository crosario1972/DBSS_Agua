

namespace DBSS_Agua.Servives
{
    using DBSS_Agua.Common.Models;
    using DBSS_Agua.Helpers;
    using Newtonsoft.Json;
    using Plugin.Connectivity;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class ApiService
    {

        public async Task<Response> CheckConnection()
        {

            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Languages.TurnOnInternet,
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("http://crosario.ddns.net:8005", 5000, 5000);
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Result = "No se pudo conectar el servidor",
                    Message = Languages.NoServer,
                };
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
            };

        }


        public async Task<Response> GetList<T>(string urlBase, string prefix, string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    //BaseAddress = new Uri(App.BaseAdd)
                    BaseAddress = new Uri(urlBase)
                };
                var url = $"{prefix}{controller}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(answer);

                return new Response
                {
                    IsSuccess = true,
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> GetList<T>(string urlBase, string prefix, string controller, string id)
        {
            try
            {
                var client = new HttpClient
                {
                    //BaseAddress = new Uri(App.BaseAdd)
                    BaseAddress = new Uri(urlBase)
                };
                var url = $"{prefix}{controller}{id}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(answer);

                return new Response
                {
                    IsSuccess = true,
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
