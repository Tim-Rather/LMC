using StarterProj.Models.Request;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterProj.Services
{
    public class PeopleService
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public int Insert(PeopleAddRequest model)
        {
            int result = 0;
            
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string cmdText = "People_Insert";
                using(SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = cmdText;

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Id";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;

                    cmd.Parameters.Add(param);
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleInitial", model.MiddleInitial);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@DOB", model.DOB);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    //explicitly casting int with (int) in front of cmd bc we know an int is being returned from SQL
                    result = (int)cmd.Parameters["@Id"].Value;
                    conn.Close();
                }
            }
            return result;
        }
    }
}
