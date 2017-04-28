using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Services;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values
        [HttpGet]
        public IHttpActionResult Get(String value)
		{
            Respuesta resp = new Respuesta();

			resp.code = "00";
			resp.description = "OK";
			resp.data = "UTC ISO DATE";

			return Ok(resp);
		}
		
        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post(Recibe aData)
        {
            Respuesta resp = new Respuesta();

            Regex r = new Regex("^[A-Za-z ]+$");
            if (r.IsMatch(aData.word) == true)
            {
                resp.code = "00";
                resp.description = "OK";
                resp.data = aData.word.ToUpper();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            else
            {
                resp.code = "01";
                resp.description = "NO_OK";
                resp.data = String.Empty;
                return Request.CreateResponse(HttpStatusCode.BadRequest, resp);
            }
        }
    }

    public class Recibe
    {
        public String word { get; set; }
    }
}
