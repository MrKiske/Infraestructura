using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Model;

namespace DataAccess.Access
{
    public class VehicleDA
    {

        private static VehicleDA _instance;

        public static VehicleDA Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new VehicleDA();

                return _instance;
            }
        }

        public List<VEHICLE> GetListVehicle()
        {
            using (var Context = new TransporteModalEntities())
            {
                var query = (from v in Context.VEHICLE.Include("TYPEVEHICLE").Include("ZONE").AsNoTracking()
                             where v.Status == true
                             select v).ToList();

                return query;
            }
        }


        public VEHICLE GetVehicleAvailable( int codZone , int codTypeVehicle )
        {
            using (var Context = new TransporteModalEntities())
            {
                
                bool exist = (from v in Context.VEHICLE.Include("TYPEVEHICLE").Include("ZONE").AsNoTracking()
                             where v.Status == true && v.Available == true 
                                                    && v.ZONE.IdZone == codZone  && v.TYPEVEHICLE.IdTypeVehicle == codTypeVehicle
                             select v).Any();

                if (exist)
                {
                    var query = (from v in Context.VEHICLE.Include("TYPEVEHICLE").Include("ZONE").AsNoTracking()
                                 where v.Status == true && v.Available == true
                                                        && v.ZONE.IdZone == codZone && v.TYPEVEHICLE.IdTypeVehicle == codTypeVehicle
                                 select v).First();


                    query.Available = false;
                    Context.Entry(query).State = EntityState.Modified;
                    Context.SaveChanges();

                    return query;
                }
                else
                {
                    return null;
                }

            }
        }

        public bool UpdateStatus(string idVehicle, bool status)
        {
            using (var Context = new TransporteModalEntities())
            {
                bool exist = (from v in Context.VEHICLE.AsNoTracking()
                              where v.IdVehicle.ToUpper() == idVehicle.ToUpper()
                              select v).Any();

                if (exist)
                {
                    var entity = (from v in Context.VEHICLE.AsNoTracking()
                                  where v.IdVehicle.ToUpper() == idVehicle.ToUpper()
                                  select v).FirstOrDefault();

                    entity.Status = status;
                    Context.Entry(entity).State = EntityState.Modified;
                    Context.SaveChanges();
                    exist = true;
                    return exist;
                }

                return exist;
            }
        }

        public bool UpdateAvailable(string idVehicle)
        {
            using (var Context = new TransporteModalEntities())
            {
                bool exist = (from v in Context.VEHICLE.AsNoTracking()
                              where v.IdVehicle.ToUpper() == idVehicle.ToUpper()
                              select v).Any();

                if (exist)
                {
                    var entity = (from v in Context.VEHICLE.AsNoTracking()
                                  where v.IdVehicle.ToUpper() == idVehicle.ToUpper()
                                  select v).FirstOrDefault();

                    entity.Available = true;
                    Context.Entry(entity).State = EntityState.Modified;
                    Context.SaveChanges();
                    exist = true;
                    return exist;
                }

                return exist;
            }        

        }

        public int CountVehicleByZone()
        {
            using (var Context = new TransporteModalEntities())
            {
                bool exist = (from v in Context.VEHICLE.Include("TYPEVEHICLE").Include("ZONE").AsNoTracking()
                              where v.Status == true && 
                                    v.Available == true 
                              select v).Any();

                if (exist)
                {
                    int count = (from v in Context.VEHICLE.Include("TYPEVEHICLE").Include("ZONE").AsNoTracking()
                                 where v.Status == true &&
                                       v.Available == true
                                 select v).Count();
                    return count;
                }
                else
                {
                    return 0;
                }


            }
        }
    }
}
