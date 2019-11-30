using BusinessRules;
using Entities;
using RestService.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestService.Controllers
{
    public class StationController : ApiController, IStationController
    {

        [HttpGet]
        public IHttpActionResult Station()
        {
            List<Station> listStation= null;
            try
            {
                listStation = StationBR.Instance.GetListStation();
                return Ok( new {listStation});
            }
            catch (Exception ex)
            {
                return Ok(new { results = string.Format("{0} {1} {2}", ex.Message, ex.GetType().ToString(), ex.StackTrace) });
            }
        }

        
        [HttpPost]
        public HttpResponseMessage UpdateStatus( Station station)
        {
            try
            {
                bool flag= StationBR.Instance.UpdateStatus(station.IdStation, station.status);
                if (flag)
                {
                    var message = Request.CreateResponse(HttpStatusCode.OK, 200);
                    message.Headers.Location = new Uri(string.Format("{0}{1}", Request.RequestUri, station.IdStation.ToString()));
                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Station Not Found");
                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}
