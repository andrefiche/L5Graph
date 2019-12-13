using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace graphConnect.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        /// <summary>
        /// Metodo de retorno de Usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            try
            {
                HttpClient client = new HttpClient();
                var url = "https://graph.microsoft.com/v1.0/users";
                var uri = new Uri(url);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Headers["Authorization"]);

                var response = await client.GetAsync(uri);
                Response.StatusCode = (int)response.StatusCode;
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return Json(JsonConvert.DeserializeObject(responseBody));
            }
            catch (HttpRequestException ex)
            {
                return Json(ex.Message);
            }
            
        }

        /// <summary>
        /// Metodo de retorno de usuarios por filtro
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("search/{filter}")]
        public async Task<JsonResult> GetByFilter(string filter)
        {
            try
            {
                HttpClient client = new HttpClient();
                var url = "https://graph.microsoft.com/v1.0/users?$filter=" + filter;
                var uri = new Uri(url);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Headers["Authorization"]);

                var response = await client.GetAsync(uri);
                Response.StatusCode = (int)response.StatusCode;
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return Json(JsonConvert.DeserializeObject(responseBody));
            }
            catch (HttpRequestException ex)
            {
                return Json(ex.Message);
            }

        }

        /// <summary>
        /// Metodo de Criacao de usuario
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Post([FromBody]JToken json)
        {
            try
            {
                HttpClient client = new HttpClient();
                var url = "https://graph.microsoft.com/v1.0/users";
                var uri = new Uri(url);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Headers["Authorization"]);

                var response = await client.PostAsync(uri, content);
                Response.StatusCode = (int)response.StatusCode;
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return Json(JsonConvert.DeserializeObject(responseBody));
            }
            catch (HttpRequestException ex)
            {
                return Json(ex.Message);
            }
        }

        /// <summary>
        /// Metodo de atualizacao de usuario
        /// </summary>
        /// <param name="json"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<JsonResult> Patch([FromBody]JToken json, string id)
        {
            try
            {
                HttpClient client = new HttpClient();
                var url = "https://graph.microsoft.com/v1.0/users/" + id;
                var uri = new Uri(url);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Headers["Authorization"]);

                var response =  await client.PatchAsync(uri, content);
                Response.StatusCode = (int)response.StatusCode;
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return Json(JsonConvert.DeserializeObject(responseBody));
            }
            catch (HttpRequestException ex)
            {
                return Json(ex.Message);
            }

        }

        /// <summary>
        /// Metodo de Delete de usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(string id)
        {
            try
            {
                HttpClient client = new HttpClient();
                var url = "https://graph.microsoft.com/v1.0/users/" + id;
                var uri = new Uri(url);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Headers["Authorization"]);

                var response = await client.DeleteAsync(uri);
                Response.StatusCode = (int)response.StatusCode;
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return Json(JsonConvert.DeserializeObject(responseBody));
            }
            catch (HttpRequestException ex)
            {
                return Json(ex.Message);
            }
        }
    }

}
