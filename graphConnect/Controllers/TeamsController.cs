using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace graphConnect.Controllers
{
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        /// <summary>
        /// Metodo de retorno de Teams por usuários
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(string id)
        {
            try
            {
                HttpClient client = new HttpClient();
                var url = "https://graph.microsoft.com/v1.0/users/" + id + "/joinedTeams";
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
        /// Metodo de retorno de Teams por grupo
        /// </summary>
        /// <returns></returns>
        [HttpGet("groups")]
        public async Task<JsonResult> GetTeamsGroups()
        {
            try
            {
                HttpClient client = new HttpClient();
                var url = "https://graph.microsoft.com/v1.0/groups";
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
        /// Metodo de retorno de Teams por filtro
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("groups/{filter}")]
        public async Task<JsonResult> GetByFilter(string filter)
        {
            try
            {
                HttpClient client = new HttpClient();
                var url = "https://graph.microsoft.com/v1.0/groups?$filter=" + filter;
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
    }
}

