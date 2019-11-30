using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccess.Model;

namespace BusinessRules.EntitiesToObjects
{
    public class ConvertToObjects
    {
        #region Singleton 
        private static ConvertToObjects _instance;

        public static ConvertToObjects Instance
        {
            get
            {
                return _instance ?? new ConvertToObjects();
            }
        }
        #endregion

        #region Lists

        public List<Vehicle> VehicleToList(List<VEHICLE> vehicleList)
        {
            List<Vehicle> listVehicle = new List<Vehicle>();
            foreach (var item in vehicleList)
            {
                Vehicle newVehicle = new Vehicle()
                {
                    IdVehicle = item.IdVehicle,
                    type = TypeVehicleToObject(item.TYPEVEHICLE), 
                    capable= item.Capacity,
                    zone = ZoneToObject(item.ZONE),
                    Status= item.Status,
                    Mileage= item.Mileage,
                    Available= item.Available
                };

                listVehicle.Add(newVehicle);
            }

            return listVehicle;
        }

        public List<Station> StationToList(List<STATION> stationList)
        {
            List<Station> listStation = new List<Station>();
            foreach (var item in stationList)
            {
                Station newStation = new Station()
                {
                     IdStation= item.IdStation,
                     NameStation= item.NameStation,
                     CodTypeStation= TypeStationToObject(item.TYPESTATION),
                     CodZone= ZoneToObject(item.ZONE)
                };

                listStation.Add(newStation);
            }
            return listStation;
        }

        public List<TypeVehicle> TypeVehicleToList(List<TYPEVEHICLE> typeVehicleList)
        {
            List<TypeVehicle> listTypeVehicle = new List<TypeVehicle>();
            foreach (var item in typeVehicleList)
            {
                TypeVehicle newTypeVehicle = new TypeVehicle()
                {
                     IdTypVehicle= item.IdTypeVehicle,
                     NameTypeVehicle= item.NameTypeVehicle
                };

                listTypeVehicle.Add(newTypeVehicle);
            }

            return listTypeVehicle;
        }

        public List<Zone> ZoneToList(List<ZONE> zoneList)
        {
            List<Zone> listZone = new List<Zone>();
            foreach (var item in zoneList)
            {
                Zone newZone = new Zone()
                {
                    IdZone = item.IdZone,
                    NameZone = item.NameZone,
                    DescriptionZone = item.DescriptionZone,
                    ColorZone = item.ColorZone
                };

                listZone.Add(newZone);
            }

            return listZone;
        }
        #endregion

        #region Objects
        public Zone ZoneToObject(ZONE item)
        {
            Zone newTypeVehicle = new Zone()
            {
                IdZone = item.IdZone,
                NameZone = item.NameZone,
                DescriptionZone = item.DescriptionZone,
                ColorZone = item.ColorZone
            };

            return newTypeVehicle;
        }
        public TypeVehicle TypeVehicleToObject(TYPEVEHICLE item)
        {
            TypeVehicle newTypeVehicle = new TypeVehicle()
            {
                IdTypVehicle = item.IdTypeVehicle,
                NameTypeVehicle = item.NameTypeVehicle
            };

            return newTypeVehicle;
        }

        public TypeStation TypeStationToObject(TYPESTATION item)
        {
            TypeStation newTypeStation = new TypeStation()
            {
                IdTypeStation = item.IdTypeStation,
                NameTypeStation = item.NameTypeStation
            };

            return newTypeStation;
        }

        public Vehicle VehicleToObject(VEHICLE item)
        {
            Vehicle newVehicle = new Vehicle()
            {
                IdVehicle = item.IdVehicle,
                type = TypeVehicleToObject(item.TYPEVEHICLE),
                capable = item.Capacity,
                zone = ZoneToObject(item.ZONE),
                Status = item.Status,
                Mileage = item.Mileage,
                Available = item.Available
            };

            return newVehicle;
        }

        public Station StationToObject(STATION item)
        {
            Station newStation = new Station()
            {
                IdStation = item.IdStation,
                NameStation = item.NameStation,
                CodTypeStation = TypeStationToObject(item.TYPESTATION),
                CodZone = ZoneToObject(item.ZONE)
            };

            return newStation;
        }
        #endregion
    }
}
