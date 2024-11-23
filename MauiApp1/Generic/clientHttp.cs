using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Generic
{
    public class ClientHttp
    {
        public static async Task<List<T>> GetAll<T>(string urlbase, string rutaapi, string token = "")
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(urlbase);
                if (token != "") cliente.DefaultRequestHeaders.Add("token", token);
                string cadena = await cliente.GetStringAsync(rutaapi);
                List<T> lista = System.Text.Json.JsonSerializer.Deserialize<List<T>>(cadena);
                return lista;
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }
        public static async Task<T> Get<T>(string urlbase, string rutaapi, string token = "")
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(urlbase);
                if (token != "") cliente.DefaultRequestHeaders.Add("token", token);
                string cadena = await cliente.GetStringAsync(rutaapi);
                T lista = JsonSerializer.Deserialize<T>(cadena);
                return lista;
            }
            catch (Exception ex)
            {
                return (T)Activator.CreateInstance(typeof(T));
            }

        }
        public static async Task<int> GetInt(string urlbase, string rutaapi, string token = "")
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(urlbase);
                if (token != "") cliente.DefaultRequestHeaders.Add("token", token);
                string cadena = await cliente.GetStringAsync(rutaapi);
                return int.Parse(cadena);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static async Task<int> Delete(string urlbase, string rutaapi, string token = "")
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(urlbase);
                if (token != "") cliente.DefaultRequestHeaders.Add("token", token);
                var response = await cliente.DeleteAsync(rutaapi);
                if (response.IsSuccessStatusCode)
                {
                    string cadena = await response.Content.ReadAsStringAsync();
                    return int.Parse(cadena);
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static async Task<int> Post<T>(string urlbase, string rutaapi, T obj, string token = "")
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(urlbase);
                if (token != "") cliente.DefaultRequestHeaders.Add("token", token);
                var response = await cliente.PostAsJsonAsync<T>(rutaapi, obj);
                if (response.IsSuccessStatusCode)
                {
                    string cadena = await response.Content.ReadAsStringAsync();
                    return int.Parse(cadena);
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static async Task<List<T>> PostList<T>(string urlbase, string rutaapi, T obj, string token = "")
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(urlbase);
                if (token != "") cliente.DefaultRequestHeaders.Add("token", token);
                var response = await cliente.PostAsJsonAsync<T>(rutaapi, obj);
                if (response.IsSuccessStatusCode)
                {
                    string cadena = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<T>>(cadena);
                }
                else
                {
                    return new List<T>();
                }

            }
            catch (Exception ex)
            {
                return new List<T>();
            }

        }
    }
}
