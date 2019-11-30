using BusinessRules;
using Entities;
using RestService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestService.Controllers
{
    public class UserController : ApiController, IUserController
    {
        [HttpPost]
        public HttpResponseMessage CreateUser(User user)
        {
            
            try
            {
                bool flag = UserBR.Instance.CreateOrUpdateUser(user);
                if (flag)
                {
                    var message = Request.CreateResponse(HttpStatusCode.OK, 200);
                    message.Headers.Location = new Uri(string.Format("{0}{1}", Request.RequestUri, user.IdUser.ToString()));
                    return message;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User not yet created");
                }


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult TotalUserByZone()
        {
            try
            {
                int count = UserBR.Instance.CountUserByZone();
                return Ok(new { count });
            }
            catch (Exception ex)
            {
                return Ok(new { results = string.Format("{0} {1} {2}", ex.Message, ex.GetType().ToString(), ex.StackTrace) });
            }
        }
    }
}
