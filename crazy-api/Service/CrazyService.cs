using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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

            var con = Configuration.GetSection("Appsettings:PSKSConn").Value;
            //var con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();
            List<Models.CrazyApi> matchingPerson = new List<Models.CrazyApi>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "Select * from Person where Id > 0";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                //oCmd.Parameters.AddWithValue("@Fname", fName);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        foreach (Models.CrazyApi item in oReader)
                        {
                            Models.CrazyApi newModel = new Models.CrazyApi();
                            newModel.Id = item.Id;
                            newModel.Name = item.Name;
                            newModel.Email = item.Email;
                            newModel.Phone = item.Phone;
                            matchingPerson.Add(newModel);
                        }
                    }
                    myConnection.Close();
                }
                return matchingPerson;
            }
        }
    }
}
