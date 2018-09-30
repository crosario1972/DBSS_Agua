

namespace DBSS_Agua.Servives
{
    using DBSS_Agua.Common.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class ApiService
    {
        readonly int Contador;

        //public async Task<Response> CheckConnection()
        //{

        //    if (!CrossConnectivity.Current.IsConnected)
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            Message = "Please turn on your internet settings.",
        //        };
        //    }

        //    var isReachable = await CrossConnectivity.Current.IsRemoteReachable("crosario.ddns.net");
        //    if (!isReachable)
        //    {
        //        return new Response
        //        {
        //            //IsSuccess = false,
        //            //Message = "Check 'crosario.ddns.net' settings.",
        //            IsSuccess = true,
        //            Message = "Ok",
        //        };
        //    }

        //    return new Response
        //    {
        //        IsSuccess = true,
        //        Message = "Ok",
        //    };
        //}

        //public async Task<Response> Login(string usuario, string password)
        //{
        //    try
        //    {

        //        var client = new HttpClient();
        //        string url = string.Format("/api/Usuarios/{0}/{1}", usuario, password);
        //        var response = await client.GetAsync(App.BaseAdd + url);
        //        var result = response.Content.ReadAsStringAsync().Result;

        //        if (string.IsNullOrEmpty(result) || result == "null")
        //        {
        //            return new Response
        //            {
        //                IsSuccess = false,
        //                Message = "Usuario o contraseña incorrectos",
        //            };
        //        }


        //        var deviceUser = JsonConvert.DeserializeObject<Usuarios>(result);

        //        return new Response
        //        {
        //            IsSuccess = true,
        //            Message = "Login ok",
        //            Result = deviceUser,
        //        };
        //    }
        //    catch (Exception)
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            Message = "El servidor de data no esta disponible",
        //        };

        //    }

        //}

        //public async Task<Response> GetCustom<T>(string controller, string customNum, string id)
        //{
        //    var client = new HttpClient
        //    {
        //        BaseAddress = new Uri(App.BaseAdd)
        //    };
        //    var url = string.Format("/api/{0}/{1}/{2}", controller, customNum, id);
        //    var response = await client.GetAsync(url);
        //    //var result = await response.Content.ReadAsStringAsync();
        //    var result = response.Content.ReadAsStringAsync().Result;



        //    var deviceUser = JsonConvert.DeserializeObject<T>(result);

        //    return new Response
        //    {
        //        IsSuccess = true,
        //        Message = "Ok",
        //        Result = deviceUser,
        //    };

        //}


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

        //public async Task<Response> GetList<T>(string controller, string customNum)
        //{
        //    try
        //    {
        //        var client = new HttpClient
        //        {
        //            BaseAddress = new Uri(App.BaseAdd)
        //        };
        //        var url = string.Format("/api/{0}/{1}", controller, customNum);
        //        var response = await client.GetAsync(url);
        //        var result = await response.Content.ReadAsStringAsync();

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            return new Response
        //            {
        //                IsSuccess = false,
        //                Message = result,
        //            };
        //        }

        //        var list = JsonConvert.DeserializeObject<List<T>>(result);

        //        return new Response
        //        {
        //            IsSuccess = true,
        //            Message = "Ok",
        //            Result = list,
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            Message = ex.Message,
        //        };
        //    }
        //}

        //public async Task<Response> GetList<T>(string controller)
        //{
        //    try
        //    {
        //        var client = new HttpClient
        //        {
        //            BaseAddress = new Uri(App.BaseAdd)
        //        };
        //        var url = string.Format("/api/{0}", controller);
        //        var response = await client.GetAsync(url);
        //        var result = await response.Content.ReadAsStringAsync();



        //        if (!response.IsSuccessStatusCode)
        //        {
        //            return new Response
        //            {
        //                IsSuccess = false,
        //                Message = result,
        //            };
        //        }

        //        var list = JsonConvert.DeserializeObject<List<T>>(result);
        //        return new Response
        //        {
        //            IsSuccess = true,
        //            Message = "Ok",
        //            Result = list,
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            Message = ex.Message,
        //        };
        //    }
        //}

        //public async Task<Response> GetList<T>(string controller, int id)
        //{
        //    try
        //    {
        //        var client = new HttpClient
        //        {
        //            BaseAddress = new Uri(App.BaseAdd)
        //        };
        //        var url = string.Format("/api/{0}/{1}", controller, id);
        //        var response = await client.GetAsync(url);
        //        var result = await response.Content.ReadAsStringAsync();

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            return new Response
        //            {
        //                IsSuccess = false,
        //                Message = result,
        //            };
        //        }

        //        var list = JsonConvert.DeserializeObject<List<T>>(result);
        //        return new Response
        //        {
        //            IsSuccess = true,
        //            Message = "Ok",
        //            Result = list,
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            Message = ex.Message,
        //        };
        //    }
        //}

        //public async Task<List<T>> GetScanBarCode<T>(string controller, string customNum, string id)
        //{
        //    try
        //    {
        //        contador += 1;

        //        var client = new HttpClient();
        //        string url = string.Format("/api/{0}/{1}/{2}", controller, customNum, id);
        //        var response = await client.GetAsync(App.BaseAdd + url);
        //        var result = response.Content.ReadAsStringAsync().Result;

        //        if (string.IsNullOrEmpty(result) || result == "null")
        //        {
        //            return null;
        //        }

        //        var list = JsonConvert.DeserializeObject<List<T>>(result);
        //        int Totalcontador = contador;
        //        return list;
        //    }
        //    catch
        //    {
        //        return null;
        //    }


        //}


        //public async Task<List<T>> Get<T>(string controller)
        //{
        //    try
        //    {
        //        contador += 1;

        //        var client = new HttpClient();
        //        string url = string.Format("/api/{0}", controller);
        //        var response = await client.GetAsync(App.BaseAdd + url);
        //        var result = response.Content.ReadAsStringAsync().Result;

        //        if (string.IsNullOrEmpty(result) || result == "null")
        //        {
        //            return null;
        //        }

        //        var list = JsonConvert.DeserializeObject<List<T>>(result);
        //        int Totalcontador = contador;
        //        return list;
        //    }
        //    catch
        //    {
        //        return null;
        //    }


        //}

        //public async Task<List<T>> Get<T>(string controller, int id)
        //{
        //    try
        //    {
        //        contador += 1;

        //        var client = new HttpClient();
        //        string url = string.Format("/api/{0}/{1}", controller, id);
        //        var response = await client.GetAsync(App.BaseAdd + url);
        //        var result = response.Content.ReadAsStringAsync().Result;

        //        if (string.IsNullOrEmpty(result) || result == "null")
        //        {
        //            return null;
        //        }

        //        var list = JsonConvert.DeserializeObject<List<T>>(result);
        //        int Totalcontador = contador;
        //        return list;
        //    }
        //    catch
        //    {
        //        return null;
        //    }


        //}


        //public async Task<Response> Update<T>(T model, string controller)
        //{
        //    try
        //    {
        //        var request = JsonConvert.SerializeObject(model);
        //        var content = new StringContent(request, Encoding.UTF8, "application/json");
        //        var client = new HttpClient
        //        {
        //            BaseAddress = new Uri(App.BaseAdd)
        //        };
        //        var url = string.Format("/api/{0}/{1}", controller, model.GetHashCode());
        //        var response = await client.PutAsync(url, content);
        //        var result = await response.Content.ReadAsStringAsync();

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            var error = JsonConvert.DeserializeObject<Response>(result);
        //            error.IsSuccess = false;
        //            return error;
        //        }

        //        var newRecord = JsonConvert.DeserializeObject<T>(result);

        //        return new Response
        //        {
        //            IsSuccess = true,
        //            Message = "Registro actualizado satisfactoriamente.",
        //            Result = newRecord,
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            Message = ex.Message,
        //        };
        //    }
        //}

        //public async Task<Response> NewRecord<T>(T model, string controller)
        //{
        //    try
        //    {

        //        var jsonRequest = JsonConvert.SerializeObject(model);
        //        var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
        //        var client = new HttpClient();
        //        string url = string.Format("/api/{0}", controller);

        //        var response = await client.PostAsync(App.BaseAdd + url, content);


        //        if (!response.IsSuccessStatusCode)
        //        {
        //            return new Response
        //            {
        //                IsSuccess = false,
        //                Message = response.StatusCode.ToString(),
        //            };
        //        }

        //        var result = response.Content.ReadAsStringAsync().Result;

        //        var newRecord = JsonConvert.DeserializeObject<T>(result);

        //        return new Response
        //        {
        //            IsSuccess = true,
        //            Message = "Nuevo registro creado satisfactoriamente.",
        //            Result = newRecord,
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            Message = ex.Message,
        //        };

        //    }
        //}


        //public async Task<List<T>> GetByName<T>(string controller, string custom, string filter)
        //{
        //    try
        //    {
        //        if (filter != string.Empty)
        //        {
        //            var client = new HttpClient();
        //            string url = string.Format("/api/{0}/{1}/{2}", controller, custom, filter);
        //            var responseBusqueda = await client.GetAsync(App.BaseAdd + url);
        //            var result = responseBusqueda.Content.ReadAsStringAsync().Result;

        //            if (string.IsNullOrEmpty(result) || result == "null")
        //            {
        //                return null;
        //            }

        //            var list = JsonConvert.DeserializeObject<List<T>>(result);
        //            return list;
        //        }
        //        else
        //        {
        //            var client = new HttpClient();
        //            string url = string.Format("/api/{0}", controller);
        //            var response = await client.GetAsync(App.BaseAdd + url);
        //            var result = response.Content.ReadAsStringAsync().Result;

        //            if (string.IsNullOrEmpty(result) || result == "null")
        //            {
        //                return null;
        //            }

        //            var list = JsonConvert.DeserializeObject<List<T>>(result);
        //            return list;

        //        }

        //    }
        //    catch
        //    {
        //        return null;
        //    }


        //}

        //public async Task<Response> Delete<T>(T model, string controller)
        //{
        //    try
        //    {

        //        var jsonRequest = JsonConvert.SerializeObject(model);
        //        var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
        //        var client = new HttpClient();
        //        string url = string.Format("/api/{0}/{1}", controller, model.GetHashCode());
        //        var response = await client.DeleteAsync(App.BaseAdd + url);


        //        if (!response.IsSuccessStatusCode)
        //        {
        //            return new Response
        //            {
        //                IsSuccess = false,
        //                Message = "Registro no puede ser borrado.",
        //            };
        //        }

        //        var result = response.Content.ReadAsStringAsync().Result;

        //        var newRecord = JsonConvert.DeserializeObject<T>(result);

        //        return new Response
        //        {
        //            IsSuccess = true,
        //            Message = "Registro borrado satisfactoriamente.",
        //            Result = newRecord,
        //        };
        //    }
        //    catch (Exception)
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            Message = "Registro no puede ser borrado.",
        //        };

        //    }
        //}

    }
}
