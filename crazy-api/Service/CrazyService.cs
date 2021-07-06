using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace crazy_api.Service
{
    public class CrazyService
    {
        public List<Models.CrazyApi> course_lst;

        public CrazyService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public List<Models.CrazyApi> GetPerson()
        {
            var con = Configuration.GetSection("ConnectionStrings:PSKSConn").Value;
            //var con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();
            List<Models.CrazyApi> matchingPerson = new List<Models.CrazyApi>();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                string sql = "Select * from Person where Id > 0";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    //SqlDataReader dr = command.ExecuteReader();
                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            Models.CrazyApi newModel = new Models.CrazyApi();
                            newModel.Id = Convert.ToInt32(oReader[0]);
                            newModel.Name = oReader[1].ToString();
                            newModel.Email = oReader[2].ToString();
                            newModel.Phone = oReader[3].ToString();
                            matchingPerson.Add(newModel);
                        }
                        connection.Close();
                    }
                }
            }
            return matchingPerson;
        }
    }
}
