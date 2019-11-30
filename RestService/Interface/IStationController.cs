using Entities;
using System.Net.Http;
using System.ServiceModel;
using System.Web.Http;

namespace RestService.Interface
{
    [ServiceContract]
    public interface IStationController
    {
        [OperationContract]
        IHttpActionResult Station();

        [OperationContract]
        HttpResponseMessage UpdateStatus(Station station);

    }
}
