using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Configuration;
namespace Servicios
{
    public class SUsuarios
    {
        string url = ConfigurationManager.AppSettings["ApiUrl"] + ConfigurationManager.AppSettings["refUsuarioApi"];
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> listUsuarios = new List<Usuario>();

            using (HttpClient cliente = new HttpClient())
            {
                Task<HttpResponseMessage> leerHttpResponse = cliente.GetAsync(url);
                leerHttpResponse.Wait();
                HttpResponseMessage respuesta = leerHttpResponse.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    Task<string> leerString = respuesta.Content.ReadAsStringAsync();
                    leerString.Wait();
                    string jsonRespuesta = leerString.Result;

                    listUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(jsonRespuesta);
                }

            }

            return listUsuarios;
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            Usuario usuario = null;
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
                        string jsonRespuestaHttp = leerString.Result;
                        usuario = JsonConvert.DeserializeObject<Usuario>(jsonRespuestaHttp);
                    }
                    else
                        throw new Exception($"Error api {leerRespuestaHttp.StatusCode}");
                }
            }
            catch (Exception excepcion)
            {
                throw new Exception($"Error Api {excepcion}");
            }
            
            return usuario;
        }

        public bool EliminarUsuario(int id)
        {
            bool esValido = false;

            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    Task<HttpResponseMessage> leerHttpResponse = cliente.DeleteAsync(url +"/"+ id);
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
                throw new Exception($"Error Api {excepcion}");
            }

            return esValido;
        }

        public bool CrearUsuario(Usuario usuario)
        {
            bool esValido = false;
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    HttpContent jsonContent = new StringContent(JsonConvert.SerializeObject(usuario),Encoding.UTF8);
                    jsonContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    Task<HttpResponseMessage> leerhttpResponse = cliente.PostAsync(url,jsonContent);
                    leerhttpResponse.Wait();
                    HttpResponseMessage leerResultadoHttp = leerhttpResponse.Result;
                    if (leerResultadoHttp.IsSuccessStatusCode)
                    {
                        esValido = true;
                    }
                    else
                        throw new Exception($"Error Api {leerResultadoHttp.StatusCode}");
                }
            }catch(Exception excepcion)
            {
                throw new Exception($"Error Api {excepcion}");
            }
            return esValido;
        }

        public bool EditarUsuario(int id, Usuario usuario)
        {
            bool esValido = false;

            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    HttpContent jsonContenido = new StringContent(JsonConvert.SerializeObject(usuario));
                    jsonContenido.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    Task<HttpResponseMessage> leerHttpResponse = cliente.PutAsync(url + "/" + id, jsonContenido);

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

        public Usuario Entrar(string correo, string contrasena)
        {
        
            List<Usuario> listaUsuarios = ObtenerUsuarios();
            Usuario usuario = listaUsuarios.Where(usua => usua.correo == correo && usua.contrasena == contrasena).FirstOrDefault();
            return usuario;
        }

    }
}
