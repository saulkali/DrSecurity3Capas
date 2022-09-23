using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidades;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Servicios
{    
    public class STarjeta
    {
        string url = ConfigurationManager.AppSettings["ApiUrl"] + ConfigurationManager.AppSettings["refTarjetaApi"];
        
        public Tarjeta ObtenerTarjetaPorId(int id)
        {
            Tarjeta tarjeta = null;
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    Task<HttpResponseMessage> leerHttpResponse = cliente.GetAsync(url + "/" + id);
                    leerHttpResponse.Wait();
                    HttpResponseMessage leerRespuestaHttp = leerHttpResponse.Result;
                    if (leerRespuestaHttp.IsSuccessStatusCode)
                    {
                        Task<string> leerString = leerRespuestaHttp.Content.ReadAsStringAsync();
                        leerString.Wait();
                        string jsonRespusta = leerString.Result;
                        tarjeta = JsonConvert.DeserializeObject<Tarjeta>(jsonRespusta);
                    }
                    else
                        throw new Exception($"Error Api {leerRespuestaHttp.StatusCode}");
                }
            }
            catch (Exception excepcion)
            {
                throw new Exception($"Error api: {excepcion}");
            }

            return tarjeta;
        }
        public List<Tarjeta> ObtenerTarjetas()
        {
            List<Tarjeta> listaTarjetas = new List<Tarjeta>();
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    Task<HttpResponseMessage> leerHttpResponse = cliente.GetAsync(url);
                    leerHttpResponse.Wait();

                    HttpResponseMessage leerResultadoHttp = leerHttpResponse.Result;
                    if (leerResultadoHttp.IsSuccessStatusCode)
                    {
                        Task<string> leerStringResponse = leerResultadoHttp.Content.ReadAsStringAsync();
                        leerStringResponse.Wait();

                        string jsonRespuesta = leerStringResponse.Result;
                        listaTarjetas = JsonConvert.DeserializeObject<List<Tarjeta>>(jsonRespuesta);
                    }
                    else
                        throw new Exception($"Error Api {leerResultadoHttp.StatusCode}");
                }
            }
            catch(Exception excepcion)
            {
                throw new Exception($"Error Api {excepcion}");
            }
            
            return listaTarjetas;
        }


        public bool CrearTarjeta(Tarjeta tarjeta)
        {

            bool esValido = false;
            try {

                using (HttpClient cliente = new HttpClient())
                {
                    HttpContent jsonContenido = new StringContent(JsonConvert.SerializeObject(tarjeta));
                    jsonContenido.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    Task<HttpResponseMessage> leerHttpResponse = cliente.PostAsync(url, jsonContenido);
                    leerHttpResponse.Wait();
                    HttpResponseMessage leerResultadoHttp = leerHttpResponse.Result;
                    if (leerResultadoHttp.IsSuccessStatusCode)
                    {
                        esValido = true;
                    }
                    else
                        throw new Exception($"Error Api {leerResultadoHttp.StatusCode}");
                }
            }
            catch (Exception excepcion)
            {
                throw new Exception($"Error api {excepcion}");
            }

            return esValido;
        }


        public bool EliminarTarjeta(int id)
        {
            bool esValido = false;
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    Task<HttpResponseMessage> leerHttpResponse = cliente.DeleteAsync(url + "/" + id);
                    leerHttpResponse.Wait();
                    HttpResponseMessage leerResultadoHttp = leerHttpResponse.Result;
                    if (leerResultadoHttp.IsSuccessStatusCode)
                    {
                        esValido = true;
                    }
                    else

                        throw new Exception($"Error Api {leerResultadoHttp.StatusCode}");
                }
            }
            catch (Exception excepcion)
            {
                throw new Exception($"Error APi {excepcion}");
            }
            return esValido;
        }

        public bool Editartarjeta (int id, Tarjeta tarjeta)
        {
            bool esValido = false;
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    HttpContent jsonContenido = new StringContent(JsonConvert.SerializeObject(tarjeta));
                    jsonContenido.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    Task<HttpResponseMessage> leerHttpResponse = cliente.PutAsync(url + "/" + id,jsonContenido);

                    HttpResponseMessage leerResultadoHttp = leerHttpResponse.Result;
                    if (leerResultadoHttp.IsSuccessStatusCode)
                    {
                        esValido = true;
                    }
                    else
                        throw new Exception($"Error api {leerResultadoHttp.StatusCode}");
                }
            }
            catch (Exception excepcion)
            {
                throw new Exception($"Error Api {excepcion}");
            }
            return esValido;
        }


    }
}
