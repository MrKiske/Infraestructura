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
    public class TypeStationBR
    {
        #region Singleton
        private static TypeStationBR _instance;

        public static TypeStationBR Instance
        {
            get
            {
                return _instance = _instance ?? new TypeStationBR();
            }
        }

        #endregion

        public TypeStation GetTypeStation(int idTypeStation)
        {
            var queryData = TypeStationDA.Instance.GetTypeStation(idTypeStation);
            return ConvertToObjects.Instance.TypeStationToObject(queryData);
        }
    }
}
