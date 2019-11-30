using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DataAccess.Access
{
    public class BaseDA: MarshalByRefObject
    {
        private static BaseDA _instance;


        public static BaseDA Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BaseDA();
                }
                return _instance;
            }
        }

        public void RunStoreProcedure(string nameProcedure, SqlParameter[] parameters= null)
        {
            try
            {
                
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionDB"].ToString()))
                {
                    SqlCommand cmd = new SqlCommand(nameProcedure, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        foreach (SqlParameter item in parameters)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }

                    if (cnn.State == ConnectionState.Open)
                    {
                        cnn.Close();
                    }

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(" Error al ejecutar procedimiento almacenado ", ex);
            }
        }


    }
}
