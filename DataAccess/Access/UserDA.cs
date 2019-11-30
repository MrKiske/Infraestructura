using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using System.Data.SqlClient;

namespace DataAccess.Access
{
    public class UserDA
    {
        private static UserDA _instance;

        public static UserDA Instance
        {
            get
            {
                return _instance ?? new UserDA();
            }
        }

        public int CountUserByZone()
        {
            using (var Context = new TransporteModalEntities())
            {
      
                var exist = (from a in Context.ACCESS.Include("STATION").Include("USER").AsNoTracking()
                             join s in Context.STATION.Include("ZONE").AsNoTracking()
                             on a.STATION.IdStation equals s.IdStation
                             into leftAcess
                             from la in leftAcess.DefaultIfEmpty()
                             select a).Any();

                if (exist)
                {
                    var query= (from a in Context.ACCESS.Include("STATION").Include("USER").AsNoTracking()
                             join s in Context.STATION.Include("ZONE").AsNoTracking()
                             on a.STATION.IdStation equals s.IdStation
                             into leftAcess
                             from la in leftAcess.DefaultIfEmpty()
                             select a).Count();

                    return query;
                }
                else
                {
                    return 0;
                }
            }

        }
        public bool CreateOrUdpateUser(Entities.Access access)
        {
            bool flag = false;
            try
            {
                SqlParameter [] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter("@CODSTATION", access.CodStation.IdStation);
                parameters[1] = new SqlParameter("@CODUSER", access.CodUser.IdUser);
                parameters[2] = new SqlParameter("@DATEENTRY", access.DateEntry);

                BaseDA.Instance.RunStoreProcedure("INSERTACCESS", parameters);

                if (!string.IsNullOrEmpty(access.CodUser.MailUser))
                {
                    parameters = new SqlParameter[6];
                    parameters[0] = new SqlParameter("@MAILUSER", access.CodUser.MailUser);
                    parameters[1] = new SqlParameter("@FIRSTNAME", access.CodUser.FirstName);
                    parameters[2] = new SqlParameter("@LASTNAME", access.CodUser.LastName);
                    parameters[3] = new SqlParameter("@CLAVE", access.CodUser.Password);
                    parameters[4] = new SqlParameter("@PHONE", access.CodUser.Phone);
                    parameters[5] = new SqlParameter("@USERSTATUS", access.CodUser.UserStatus);

                    BaseDA.Instance.RunStoreProcedure("INSERTUSERS", parameters);

                }

                flag = true;
                return flag; 
            }
            catch (Exception ex)
            {

                flag = false;
                return flag;
            }

        }

      
    }
}
