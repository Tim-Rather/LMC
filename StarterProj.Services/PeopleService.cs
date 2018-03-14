using StarterProj.Models.Domain;
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
                    //explicitly casting int with (int) in front of cmd bc know an int is being returned from SQL
                    result = (int)cmd.Parameters["@Id"].Value;
                    conn.Close();
                }
            }
            return result;
        }

        public List<People> GetAll()
        {
            List<People> result = new List<People>();
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string cmdText = "People_SelectAll";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = cmdText;

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    conn.Open();
                    while (reader.Read())
                    {
                        People person = new People();
                        int index = 0;
                        person.Id = reader.GetInt32(index++);
                        person.FirstName = reader.GetString(index++);
                        if (!reader.IsDBNull(index))
                            person.MiddleInitial = reader.GetString(index++)[0];
                        else
                            index++;
                        person.LastName = reader.GetString(index++);
                        person.DOB = reader.GetDateTime(index++);
                        person.CreatedDate = reader.GetDateTime(index++);
                        person.ModifiedDate = reader.GetDateTime(index++);
                        person.ModifiedBy = reader.GetString(index++);

                        result.Add(person);
                    }
                    conn.Close();
                }
            }
            return result;
        }
    }
}
