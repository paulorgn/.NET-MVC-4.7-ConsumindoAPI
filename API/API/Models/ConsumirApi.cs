using API.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace API.Models
{
    public class ConsumirApi
    {
        public HttpClient IniciarCliente()
        {
            try
            {
                HttpClient cliente = new HttpClient();

                cliente.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HttpResponseMessage ClienteChamarAAPI(DtoExemplo meuDto)
        {
            try
            {
                HttpClient cliente = IniciarCliente();

                var content = Newtonsoft.Json.JsonConvert.SerializeObject(meuDto);
                StringContent httpContent = new System.Net.Http.StringContent(content, Encoding.UTF8, "application/json");

                var resposta = cliente.PostAsync("posts", httpContent).Result;

                return resposta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ObterRetornoDaAPI(DtoExemplo meuDto)
        {
            try
            {
                HttpResponseMessage resposta = ClienteChamarAAPI(meuDto);

                if (resposta.IsSuccessStatusCode)
                {
                    string stringRetornoDaApi = resposta.Content.ReadAsStringAsync().Result.ToString();

                    return stringRetornoDaApi;
                }
                else
                {
                    return "A chamada para a API não obteve sucesso";
                }
            }
            catch (Exception ex)
            {
                return "Ocorreu um erro interno: " + ex.Message;
            }
        }
    }
}