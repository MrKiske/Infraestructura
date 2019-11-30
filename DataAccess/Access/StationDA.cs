using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DataAccess.Access
{
    public class StationDA
    {
        private static StationDA _instance;

        public static StationDA Instance
        {
            get
            {
                return _instance ?? new StationDA();
            }
        }

        public List<STATION> GetListStation()
        {
            using (var Context = new TransporteModalEntities())
            {
                var query = (from s in Context.STATION.Include("TYPESTATION").Include("ZONE").AsNoTracking()
                             where s.Status == true
                             orderby s.NameStation
                             select s).ToList();

                return query;
            }
        }

        public bool UpdateStatus(int idStation, bool status)
        {
            using (var Context = new TransporteModalEntities())
            {
                bool exist = (from s in Context.STATION.AsNoTracking()
                              where s.IdStation == idStation select s).Any();
                if (exist)
                {
                    var entity = (from s in Context.STATION.AsNoTracking()
                                      where s.IdStation == idStation
                                      select s).FirstOrDefault();

                    entity.Status = status;
                    Context.Entry(entity).State = EntityState.Modified;
                    Context.SaveChanges();
                    exist = true;
                    return exist;
                }

                return exist;
            }
        }

        public STATION GetStation(int codStation)
        {
            using (var Context = new TransporteModalEntities())
            {
                var query = (from s in Context.STATION.Include("TYPESTATION").Include("ZONE").AsNoTracking()
                             where s.Status == true &&
                                   s.IdStation == codStation  
                             orderby s.NameStation
                             select s).First();

                return query;
            }
        }
    }
}
