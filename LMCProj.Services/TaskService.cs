using LMCProj.Models.Domain;
using LMCProj.Models.Request;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMCProj.Services
{
    public class TaskService : BaseService
    {
        public int Insert(TaskAddRequest model)
        {
            int result = 0;
            cmd.CommandText = "Tasks_Insert";

            //out parameter from SQL
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Id";
            param.SqlDbType = System.Data.SqlDbType.Int;
            param.Direction = System.Data.ParameterDirection.Output;

            cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@AccountId", model.AccountId);
            cmd.Parameters.AddWithValue("@Title", model.Title);
            cmd.Parameters.AddWithValue("@Description", model.Description);
            cmd.Parameters.AddWithValue("@Date", model.Date);

            conn.Open();
            cmd.ExecuteNonQuery();
            result = (int)cmd.Parameters["@Id"].Value;
            conn.Close();

            return result;
        }
        
        public List<AccountTask> GetAllById(int accountId)
        {
            List<AccountTask> result = new List<AccountTask>();
            cmd.CommandText = "Tasks_SelectAllByAccountId";
            cmd.Parameters.AddWithValue("@AccountId", accountId);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                int index = 0;
                AccountTask task = new AccountTask();
                task.Id = reader.GetInt32(index++);
                task.AccountId = reader.GetInt32(index++);
                task.Title = reader.GetString(index++);
                task.Description = reader.GetString(index++);
                task.Date = reader.GetDateTime(index++);

                result.Add(task);
            }
            conn.Close();

            return result;
        }

        public void Update(TaskUpdateRequest model)
        {
            cmd.CommandText = "Tasks_Update";

            cmd.Parameters.AddWithValue("@Id", model.Id);
            cmd.Parameters.AddWithValue("@AccountId", model.AccountId);
            cmd.Parameters.AddWithValue("@Title", model.Title);
            cmd.Parameters.AddWithValue("@Description", model.Description);
            cmd.Parameters.AddWithValue("@Date", model.Date);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int id)
        {
            cmd.CommandText = "Tasks_Delete";

            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
