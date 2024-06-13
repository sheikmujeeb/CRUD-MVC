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
    public class StartRepos:IStartPoint
    {
        SqlConnection Obj;
        IConfiguration Config;
        public StartRepos(IConfiguration fig)
        {
            Config = fig;
            var a = Config.GetConnectionString("DbConnection");
            Obj = new SqlConnection(a);
        }
        public IEnumerable<StartPoint>Showall()
        {
            try
            {
                var value = $"exec showall";
                Obj.Open();
                var result = Obj.Query<StartPoint>(value);
                Obj.Close();
                return result;

            }
            catch(SqlException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
;