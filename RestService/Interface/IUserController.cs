using Entities;
using System.Net.Http;
using System.ServiceModel;
using System.Web.Http;

namespace RestService.Interface
{
    [ServiceContract]
    public interface IUserController
    {

        [OperationContract]
        HttpResponseMessage CreateUser(User user);

        [OperationContract]
        IHttpActionResult TotalUserByZone();
    }
}
