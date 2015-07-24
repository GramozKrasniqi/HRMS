using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entities;
using Entities.Views;

namespace DAL.Mapper
{
    public class ReminderMapper
    {
        public void Insert(ReminderEntity t, SqlCommand transactionCMD)
        {
            if (transactionCMD != null)
            {
                transactionCMD.CommandText = "usp_InsertReminder";

                transactionCMD.CommandType = System.Data.CommandType.StoredProcedure;
                transactionCMD.Parameters.AddWithValue("@Url", t.Url);
                transactionCMD.Parameters.AddWithValue("@EntityPK", t.EntityPK);
                transactionCMD.Parameters.AddWithValue("@EntityPKType", t.EntityPKType);
                transactionCMD.Parameters.AddWithValue("@Type", t.ReminderType);

                transactionCMD.ExecuteNonQuery();
            }
            else
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;

                try
                {
                    conn = DALHelper.CreateSqlDbConnection();
                    cmd = new SqlCommand("usp_InsertReminder", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Url", t.Url);
                    cmd.Parameters.AddWithValue("@EntityPK", t.EntityPK);
                    cmd.Parameters.AddWithValue("@EntityPKType", t.EntityPKType);
                    cmd.Parameters.AddWithValue("@Type", t.ReminderType);

                    t.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                    cmd.Dispose();
                    conn.Dispose();
                }
            }
        }

        public ReminderView GetReminderByType(ReminderEnum type, int? EmployeeId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetCountOfRemindersByType", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Type", Convert.ToInt32(type));
                if (EmployeeId != null)
                {
                    cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                ReminderView entity = new ReminderView();

                if (rdr.Read())
                {
                    entity.Count = Convert.ToInt32(rdr["Count"]);
                    entity.Url = Convert.ToString(rdr["Url"]);
                }

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }
    }
}
