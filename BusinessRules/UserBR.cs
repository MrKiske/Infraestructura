using BusinessRules.EntitiesToObjects;
using BusinessRules.ObjectsToEntities;
using DataAccess.Access;
using DataAccess.Model;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
    public class UserBR
    {
        private static UserBR _instance;

        public static UserBR Instance
        {
            get
            {
                return _instance ?? new UserBR();
            }
        }

       
        public int CountUserByZone()
        {
            int countUser = UserDA.Instance.CountUserByZone();
            return countUser;
        }

        public bool CreateOrUpdateUser(User user)
        {
            int codStation = StationBR.Instance.SelectStation();
            var queryData = StationDA.Instance.GetStation(codStation);
            Station station = ConvertToObjects.Instance.StationToObject(queryData);

            Access access= newAccess(user, station);
            bool flag = UserDA.Instance.CreateOrUdpateUser(access);

            return flag;
        }

        private Access newAccess(User user, Station station)
        {
            Access access = new Access()
            {
                CodStation = station,
                CodUser = user,
                DateEntry = DateTime.Now.Date,
                DateExit = null
            };

            return access;
        }
    }
}
