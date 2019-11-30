using Entities;
using System.Collections.Generic;
using DataAccess.Access;
using BusinessRules.EntitiesToObjects;


namespace BusinessRules
{
    public class VehicleBR
    {
        private static VehicleBR _instance;

        public static VehicleBR Instance
        {
            get
            {
                return _instance ?? new VehicleBR();
            }
        }

        public List<Vehicle> GetListVehicles()
        {
            var queryData= VehicleDA.Instance.GetListVehicle();
            return ConvertToObjects.Instance.VehicleToList(queryData);
        }

        public bool UpdateStatus(string idVehicle, bool status)
        {
            bool flag = VehicleDA.Instance.UpdateStatus(idVehicle, status);
            return flag;
        }

        public Vehicle GetVehicleAvailable(int CodZone, int CodTypeVehicle)
        {
            var queryData = VehicleDA.Instance.GetVehicleAvailable(CodZone, CodTypeVehicle);
            if (queryData != null)
                return ConvertToObjects.Instance.VehicleToObject(queryData);
            else
                return null;
        }

        public bool UpdateAvailable(string idVehicle)
        {
            bool flag = VehicleDA.Instance.UpdateAvailable(idVehicle);
            return flag;
        }

        public int CountVehicleByZone()
        {
            return VehicleDA.Instance.CountVehicleByZone();
        }
    }
}
