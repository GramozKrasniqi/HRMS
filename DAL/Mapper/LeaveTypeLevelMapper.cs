using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entities;

namespace DAL.Mapper
{
    public class LeaveTypeLevelMapper
    {
        public void Insert(LeaveTypeLevelEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertLeaveTypeLevel", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LeaveTypeId", t.LeaveTypeId);
                cmd.Parameters.AddWithValue("@NoOfDays", t.NoOfDays);
                cmd.Parameters.AddWithValue("@PaymentPercentage", t.PaymentPercentage);
                cmd.Parameters.AddWithValue("@LeaveNameType", t.LeaveNameType);

                cmd.ExecuteNonQuery();
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

        public void Delete(LeaveTypeLevelEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteLeaveTypeLevel", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);

                cmd.ExecuteNonQuery();
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

        public List<LeaveTypeLevelEntity> List(int LeaveTypeId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListLeaveTypeLevelByLeaveTypeId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LeaveTypeId", LeaveTypeId);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<LeaveTypeLevelEntity> list = new List<LeaveTypeLevelEntity>();

                while (rdr.Read())
                {
                    LeaveTypeLevelEntity entity = new LeaveTypeLevelEntity();
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.LeaveTypeId = Convert.ToInt32(rdr["LeaveTypeId"]);
                    entity.NoOfDays = Convert.ToInt32(rdr["NoOfDays"]);
                    entity.PaymentPercentage = Convert.ToDouble(rdr["PaymentPercentage"]);
                    entity.LeaveNameType = (LeaveNameType)Convert.ToInt32(rdr["LeaveNameType"]);

                    list.Add(entity);
                }

                return list;
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
