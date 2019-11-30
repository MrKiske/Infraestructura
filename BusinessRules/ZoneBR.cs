using BusinessRules.EntitiesToObjects;
using DataAccess.Access;
using Entities;

namespace BusinessRules
{
    public class ZoneBR
    {
        #region Singleton
        private static ZoneBR _instance;

        public static ZoneBR Instance
        {
            get
            {
                return _instance = _instance ?? new ZoneBR();
            }
        }

        #endregion

        public Zone GetZone(int idZone)
        {
            var queryData = ZoneDA.Instance.GetZone(idZone); 
            return ConvertToObjects.Instance.ZoneToObject(queryData);
        }
    }
}

