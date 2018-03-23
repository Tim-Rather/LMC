using LMCProj.Models.Domain;
using LMCProj.Models.Request;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMCProj.Services
{
    public class PeopleService : BaseService
    {
        public int Insert(PeopleAddRequest model)
        {
            int result = 0;
            cmd.CommandText = "People_Insert";

            //out parameter from SQL
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
            cmd.Parameters.AddWithValue("@Description", model.Description);
            cmd.Parameters.AddWithValue("@Image", model.Image);

            conn.Open();
            cmd.ExecuteNonQuery();
            //explicitly casting int with (int) in front of cmd bc know an int is being returned from SQL
            result = (int)cmd.Parameters["@Id"].Value;
            conn.Close();
            return result;
        }

        public List<People> GetAll()
        {
            List<People> result = new List<People>();
            cmd.CommandText = "People_SelectAll";

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                People person = new People();
                int index = 0;
                person.Id = reader.GetInt32(index++);
                person.FirstName = reader.GetString(index++);
                if (reader.IsDBNull(index))
                {
                    person.MiddleInitial = null;
                    index++;
                }
                else
                   person.MiddleInitial = reader.GetString(index++)[0];
                person.LastName = reader.GetString(index++);
                person.DOB = reader.GetDateTime(index++);
                person.CreatedDate = reader.GetDateTime(index++);
                person.ModifiedDate = reader.GetDateTime(index++);
                person.ModifiedBy = reader.GetString(index++);
                person.Description = reader.GetString(index++);
                person.Image = reader.GetString(index++);

                result.Add(person);
            }
            conn.Close();
            return result;
        }

        public People GetById(int id)
        {
            People person = new People();
            cmd.CommandText = "People_SelectById";
            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while(reader.Read())
            {
                int index = 0;
                person.Id = reader.GetInt32(index++);
                person.FirstName = reader.GetString(index++);
                if (reader.IsDBNull(index))
                {
                    person.MiddleInitial = null;
                    index++;
                }
                else
                    person.MiddleInitial = reader.GetString(index++)[0];
                person.LastName = reader.GetString(index++);
                person.DOB = reader.GetDateTime(index++);
                person.CreatedDate = reader.GetDateTime(index++);
                person.ModifiedDate = reader.GetDateTime(index++);
                person.ModifiedBy = reader.GetString(index++);
                person.Description = reader.GetString(index++);
                person.Image = reader.GetString(index++);
            }
            conn.Close();
            return person;
        }

        public void Update(PeopleUpdateRequest model)
        {
            cmd.CommandText = "People_Update";

            cmd.Parameters.AddWithValue("@Id", model.Id);
            cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
            cmd.Parameters.AddWithValue("@MiddleInitial", model.MiddleInitial);
            cmd.Parameters.AddWithValue("@LastName", model.LastName);
            cmd.Parameters.AddWithValue("@DOB", model.DOB);
            cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);
            cmd.Parameters.AddWithValue("@Description", model.Description);
            cmd.Parameters.AddWithValue("@Image", model.Image);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int id)
        {
            cmd.CommandText = "People_Delete";

            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
