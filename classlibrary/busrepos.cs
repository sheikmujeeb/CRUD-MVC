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
        SqlConnection Obj;
        IConfiguration Config;
        public busrepos(IConfiguration fig)
        {
            Config = fig;
            var a = Config.GetConnectionString("DbConnection");
            Obj= new SqlConnection(a);
        }
        public void SPlogin(Busdetails reg)
        {
            try
            {
                var insertsql = $" Insert into Busdetails values('{reg.BusName}',{reg.DriverMobilenumber},'{reg.StartPoint}','{reg.Destination}',{reg.Fair},{reg.NoofPassenger})";
                Obj.Open();
                Obj.Execute(insertsql);
                Obj.Close();
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
        public IEnumerable<Busdetails> Showall()
        {
            try
            {
                var show = $" select * from Busdetails ";
                Obj.Open();
                var match = Obj.Query<Busdetails>(show);
                Obj.Close();
                return (match);

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
        public void SPupdate(int BusID,string StartPoint ,string Destination,long Fair,long NoofPassenger)
        {
            try
            {
                var up = $"exec SPupdate {BusID}'{StartPoint}''{Destination}'{Fair}{NoofPassenger};";
                Obj.Open();
                Obj.Execute(up);
                Obj.Close();
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
        public void SPremove(string name)
        {
            try
            {
                var remove = ($"exec SPremove {name}");
                Obj.Open();
                Obj.Execute(remove);
                Obj.Close();
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
        public IEnumerable<Busdetails>Search(string name)
        {
            try
            {
                var search = ($"exec Search {name}");
                Obj.Open();
                var match = Obj.Query<Busdetails>(search);
                Obj.Close();
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
