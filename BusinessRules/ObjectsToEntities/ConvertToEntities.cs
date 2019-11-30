using DataAccess.Model;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.ObjectsToEntities
{
    public class ConvertToEntities
    {
        #region Singleton 
        private static ConvertToEntities _instance;

        public static ConvertToEntities Instance
        {
            get
            {
                return _instance ?? new ConvertToEntities();
            }
        }
        #endregion

        #region Objects
        public USER UserToEntity(User item)
        {
            USER newUser = new USER()
            {
                 MailUser= item.MailUser,
                 FirstName= item.FirstName,
                 LastName= item.LastName,
                 Password= item.Password,
                 Phone= item.Phone,
                 UserStatus= item.UserStatus
            };

            return newUser;
        }

        public ACCESS AccessToEntity(Access item)
        {
            
            ACCESS newAccess = new ACCESS()
            {
                 IdAccess= item.IdAccess,
                 //STATION= StationToEntity(item.CodStation),
                 //USER = UserToEntity(item.CodUser),
                 DateEntry = item.DateEntry,
                 DateExit = item.DateExit
            };

            return newAccess;
        }

        public STATION StationToEntity(Station item)
        {
            STATION newStation = new STATION()
            {
                 IdStation = item.IdStation,
                 NameStation= item.NameStation,
                 AbbreviationStation= null,
                 Status= item.status,
                 TYPESTATION = TypeStation(item.CodTypeStation),
                 ZONE = ZoneToEntity(item.CodZone)
            };

            return newStation;

        }

        public TYPESTATION TypeStation(TypeStation item)
        {
            TYPESTATION newTypeStation = new TYPESTATION()
            {
                IdTypeStation= item.IdTypeStation,
                NameTypeStation= item.NameTypeStation
            };

            return newTypeStation;
        }

        public ZONE ZoneToEntity(Zone item)
        {
            ZONE newZone = new ZONE()
            {
                IdZone= item.IdZone,
                NameZone= item.NameZone,
                DescriptionZone= item.DescriptionZone,
                ColorZone= item.ColorZone
            };

            return newZone;
        }
        #endregion
    }
}
