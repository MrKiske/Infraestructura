using Entities;
using System.Collections.Generic;
using System.Web.Http;
using System;
using BusinessRules;
using System.Net.Http;
using System.Net;
using RestService.Interface;

namespace RestService.Controllers
{
    public class VehicleController : ApiController, IVehicleController
    {
        [HttpGet]
        public IHttpActionResult Vehicle()
        {
            List<Vehicle> listVehicle= null ;

            try
            {
                listVehicle= VehicleBR.Instance.GetListVehicles();
                return Ok(new {listVehicle });
            }
            catch (Exception ex)
            {
                return Ok(new {results= string.Format("{0} {1} {2}", ex.Message, ex.GetType().ToString(), ex.StackTrace) });
            }
        }

        [HttpGet]
        public IHttpActionResult TotalVehicleByZone()
        {
            try
            {
                int count = VehicleBR.Instance.CountVehicleByZone();
                return Ok(new { count });
            }
            catch (Exception ex)
            {
                return Ok(new { results = string.Format("{0} {1} {2}", ex.Message, ex.GetType().ToString(), ex.StackTrace) });
            }
        }

        [HttpPut]
        public IHttpActionResult GetVehicleAvailable( TypeVehicleViewModel type)
        {
            Vehicle vehicle = null;
            try
            {
                vehicle = VehicleBR.Instance.GetVehicleAvailable(type.IdZone, type.IdTypeVehicle);
                return Ok(new { vehicle });
            }
            catch (Exception ex)
            {
                return Ok(new { results = string.Format("{0} {1} {2}", ex.Message, ex.GetType().ToString(), ex.StackTrace) });
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateStatus(Vehicle vehicle)
        {
            try
            {
                bool flag = VehicleBR.Instance.UpdateStatus(vehicle.IdVehicle, vehicle.Status);
                if (flag)
                {
                    var message = Request.CreateResponse(HttpStatusCode.OK, 200);
                    message.Headers.Location = new Uri(string.Format("{0}{1}", Request.RequestUri, vehicle.IdVehicle.ToString()));
                    return message;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Vehicle Not Found");
                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage FreedVehicle(string idVehicle)
        {
            try
            {
                bool flag = VehicleBR.Instance.UpdateAvailable(idVehicle);
                if (flag)
                {
                    var message = Request.CreateResponse(HttpStatusCode.OK, 200);
                    message.Headers.Location = new Uri(string.Format("{0}{1}", Request.RequestUri, idVehicle.ToString()));
                    return message;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Vehicle Not Found");
                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

       

      
    }
}
