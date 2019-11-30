using Entities;
using System.Net.Http;
using System.ServiceModel;
using System.Web.Http;

namespace RestService.Interface
{
    [ServiceContract]
    public interface IVehicleController
    {
        [OperationContract]
        IHttpActionResult Vehicle();

        [OperationContract]
        IHttpActionResult GetVehicleAvailable(TypeVehicleViewModel type);

        [OperationContract]
        HttpResponseMessage UpdateStatus(Vehicle vehicle);

        [OperationContract]
        HttpResponseMessage FreedVehicle(string idVehicle);

        [OperationContract]
        IHttpActionResult TotalVehicleByZone();
    }
}
