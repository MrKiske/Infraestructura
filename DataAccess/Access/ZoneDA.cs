using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Access
{
    public class ZoneDA
    {
        #region Singleton
        private static ZoneDA _instance;

        public static ZoneDA Instance
        {
            get
            {
                return _instance = _instance ?? new ZoneDA();
            }
        }

        #endregion

        public ZONE GetZone (int codZone)
        {
            using (var Context = new TransporteModalEntities())
            {
                var query = (from z in Context.ZONE.AsNoTracking()
                             where z.IdZone == codZone
                             select z).First();

                return query;
            }
        }
    }
}
