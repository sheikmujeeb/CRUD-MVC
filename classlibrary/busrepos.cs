using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace classlibrary
{
    public class busrepos
    {
        SqlConnection obj;
        IConfiguration config;
        public busrepos(IConfiguration configg)
        {
            config = configg;
            var a = config.GetConnectionString("DbConnection");

            obj= new SqlConnection();
        }
        public void SPLogin(BusDetails reg)
        {
            try
            {
                var insertsql = $"exec BusDetails('{reg.BusName}',{reg.DriverMobilenumber},'{reg.StartPoint}','{reg.Destination}',{reg.Fair},{reg.NoofPassenger})";
                obj.Open();
                obj.Execute(insertsql);
                obj.Close();
            }
            catch(SqlException )
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public IEnumerable<BusDetails>SPselectall()
        {
            try
            {
                var show = $"Select * from BusDetails";
                obj.Open();
                var match = obj.Query<BusDetails>(show);
                obj.Close();
                return match;

            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
    }
}
