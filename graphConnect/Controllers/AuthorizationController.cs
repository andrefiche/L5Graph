using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using graphConnect.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace graphConnect.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {
        /// <summary>
        /// Metodo de controle de acesso
        /// </summary>
        /// <param name="GraphAuth"></param>
        /// <returns></returns>
        // POST api/Authorization
        [HttpPost]
        public JsonResult Post([FromBody]GraphAuth GraphAuth)
        {
            try
            {
                string host = "https://login.microsoftonline.com/";
                string sufix = "/oauth2/v2.0/token";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(host + GraphAuth.TenatID + sufix);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.Method = "POST";
                var dataBody = "&grant_type=" + GraphAuth.GrantType;
                dataBody += "&client_id=" + GraphAuth.ClientID;
                dataBody += "&client_secret=" + GraphAuth.ClientSecret;
                dataBody += "&scope=" + GraphAuth.Scope;

              
                var dados = Encoding.UTF8.GetBytes(dataBody);
                using (var stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(dados, 0, dados.Length);
                    stream.Close();
                }
                using (var response = httpWebRequest.GetResponse())
                {
                    var streamDados = response.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    streamDados.Close();
                    response.Close();
                    return Json(JsonConvert.DeserializeObject(objResponse.ToString()));
                }
            }
            catch (HttpListenerException ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost("user")]
        public JsonResult PostUser([FromBody]GraphAuthUser GraphAuth)
        {
            try
            {
                string host = "https://login.microsoftonline.com/";
                string sufix = "/oauth2/v2.0/token";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(host + "common" + sufix);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.Method = "POST";
                var dataBody = "&grant_type=" + GraphAuth.GrantType;
                dataBody += "&client_id=" + GraphAuth.ClientID;
                dataBody += "&client_secret=" + GraphAuth.ClientSecret;
                dataBody += "&scope=" + GraphAuth.Scope;
                dataBody += "&code=" + GraphAuth.Code;
                dataBody += "&redirect_uri=" + GraphAuth.RedirectUri;


                var dados = Encoding.UTF8.GetBytes(dataBody);
                using (var stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(dados, 0, dados.Length);
                    stream.Close();
                }
                using (var response = httpWebRequest.GetResponse())
                {
                    var streamDados = response.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    streamDados.Close();
                    response.Close();
                    return Json(JsonConvert.DeserializeObject(objResponse.ToString()));
                }
            }
            catch (HttpListenerException ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
