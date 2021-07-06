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

            //string oString = "Select * from Person where Id > 0";
            //string connetionString;
            //SqlConnection cnn;
            //connetionString = @"Data Source=WIN-50GP30FGO75;Initial Catalog=Demodb;User ID=sa;Password=demol23";
            //cnn = new SqlConnection(con);
            //cnn.Open();

            //using (SqlConnection myConnection = new SqlConnection(con))
            //{
            //    string oString = "Select * from Person where Id > 0";
            //    SqlCommand oCmd = new SqlCommand(oString, myConnection);
            //    //oCmd.Parameters.AddWithValue("@Fname", fName);
            //    myConnection.Open();
            //    using (SqlDataReader oReader = oCmd.ExecuteReader())
            //    {
            //        while (oReader.Read())
            //        {
            //            foreach (Models.CrazyApi item in oReader)
            //            {
            //                Models.CrazyApi newModel = new Models.CrazyApi();
            //                newModel.Id = item.Id;
            //                newModel.Name = item.Name;
            //                newModel.Email = item.Email;
            //                newModel.Phone = item.Phone;
            //                matchingPerson.Add(newModel);
            //            }
            //        }
            //        myConnection.Close();
            //    }

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    string sql = "Select * from Person where Id > 0";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataReader dr = command.ExecuteReader();
                        //using (SqlDataReader reader = command.ExecuteReader())
                        //{
                            while (dr.Read())
                            {
                                Console.WriteLine("{0} {1}", dr.GetString(0), dr.GetString(1));
                            }
                        //}
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();


            return matchingPerson;
            }
        }
    }
