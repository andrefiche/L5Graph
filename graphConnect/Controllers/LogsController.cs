using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using graphConnect.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace graphConnect.Controllers
{
    [Route("api/[controller]")]
    public class LogsController : Controller
    {
        private readonly IAccessLogsRepository _accessLogsRepository;
        public LogsController(IAccessLogsRepository accessLogsRepository)
        {
            _accessLogsRepository = accessLogsRepository;
        }

        /// <summary>
        /// Metodo de retorno de logs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var logs = _accessLogsRepository.GetAll();
                if (logs.Count() == 0)
                    return NoContent();
                return Ok(logs);
            }
            catch (HttpRequestException ex)
            {
                return Json(ex.Message);
            }

        }
    }
}
