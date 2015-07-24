using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entities;

namespace DAL.Mapper
{
    public class LeaveRespondMapper
    {
        public void Respond(LeaveRespond t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_RespondLeaveRequest", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LeaveRequestId", t.LeaveRequestId);
                cmd.Parameters.AddWithValue("@ResponseStatus", t.ResponseStatus);
                cmd.Parameters.AddWithValue("@ResponseDate", t.ResponseDate);
                cmd.Parameters.AddWithValue("@Notes", t.Notes);
                cmd.Parameters.AddWithValue("@ResponderId", t.ResponderId);
                cmd.Parameters.AddWithValue("@RequestProcessedBy", t.RequestProcessedBy);


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

        public LeaveRespond CheckLeaveStatus(int leaveRequestId, RequestsProcessedByEnum en)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_CheckLeaveStatus", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LeaveRequestId", leaveRequestId);
                cmd.Parameters.AddWithValue("@RequestProcessedBy", en);

                SqlDataReader rdr = cmd.ExecuteReader();
                LeaveRespond respond = new LeaveRespond();
                if(rdr.Read())
                {
                    respond.Id = Convert.ToInt32(rdr["Id"]);
                    respond.LeaveRequestId = leaveRequestId;
                }
                    return respond;
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

        public RequestsProcessedByEnum GetLeaveStatus(int leaveRequestId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetLeaveStatus", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LeaveRequestId", leaveRequestId);

                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    return (RequestsProcessedByEnum)Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                {
                    return RequestsProcessedByEnum.NotDefined;
                }
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
