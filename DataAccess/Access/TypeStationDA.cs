using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Access
{
     public class TypeStationDA
    {
        #region Singleton
        private static TypeStationDA _instance;

        public static TypeStationDA Instance
        {
            get
            {
                return _instance = _instance ?? new TypeStationDA();
            }
        }

        #endregion

        public TYPESTATION GetTypeStation(int codTypeStation)
        {
            using (var Context = new TransporteModalEntities())
            {
                var query = (from s in Context.TYPESTATION.AsNoTracking()
                             where s.IdTypeStation == codTypeStation
                             select s).First();

                return query;
            }
        }
    }
}
