using BusinessRules.EntitiesToObjects;
using DataAccess.Access;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
    public class StationBR
    {
        private static StationBR _instance;

        public static StationBR Instance
        {
            get
            {
                return _instance ?? new StationBR();
            }
        }
        
      
        public List<Station> GetListStation()
        {
            var queryData = StationDA.Instance.GetListStation();
            return ConvertToObjects.Instance.StationToList(queryData);
        }

        public bool UpdateStatus(int idStation, bool status)
        {
            bool flag = StationDA.Instance.UpdateStatus(idStation, status);
            return flag;
        }

        public Station GetStation(int idStation)
        {
            var queryData = StationDA.Instance.GetStation(idStation);
            return ConvertToObjects.Instance.StationToObject(queryData);
        }

        public int SelectStation()
        {
            Random codStation = new Random();
            return codStation.Next(1,31);
        }
    }
}
