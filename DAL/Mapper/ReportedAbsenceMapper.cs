using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;
using Entities.Views;

namespace DAL.Mapper
{
    public class ReportedAbsenceMapper
    {
        public void ReportAbsence(ReportedAbsenceEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ReportAbsence", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Date", t.Date);
                cmd.Parameters.AddWithValue("@AbsenceEmployeeId", t.AbsenceEmployeeId);
                cmd.Parameters.AddWithValue("@ManagerEmployeeId", t.ManagerEmployeeId);
                cmd.Parameters.AddWithValue("@Notes", t.Notes);

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

        public void LinkAbsenceWithLeaveRequest(List<ReportedAbsenceEntity> t, LeaveRequestEntity request)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();

                foreach (ReportedAbsenceEntity ae in t)
                {
                    cmd = new SqlCommand("usp_LinkAbsenceWithLeaveRequest", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ReportedAbsenceId", ae.Id);
                    cmd.Parameters.AddWithValue("@LeaveRequestId", request.Id);

                    conn.Close();
                    cmd.Dispose();

                    cmd.ExecuteNonQuery();
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

        public List<ReportedAbsenceView> ListWithAdvancedFilter(DateTime? dateFrom, DateTime? dateTo)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListReportedAbsenceWithAdvancedFilter", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (dateFrom != null)
                {
                    cmd.Parameters.AddWithValue("@DateFrom", dateFrom);
                }
                if (dateTo != null)
                {
                    cmd.Parameters.AddWithValue("@DateTo", dateTo);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<ReportedAbsenceView> list = new List<ReportedAbsenceView>();

                while (rdr.Read())
                {
                    ReportedAbsenceView entity = new ReportedAbsenceView();
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Date = Convert.ToDateTime(rdr["Date"]);
                    entity.AbsenceEmployee = Convert.ToString(rdr["AbsenceEmployee"]);
                    entity.Manager = Convert.ToString(rdr["Manager"]);
                    entity.Notes = Convert.ToString(rdr["Notes"]);
                    entity.Status = (RequestsEnum)Convert.ToInt32(rdr["Status"]);

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

        public void LinkAbsenceesWithLeaveRequest(List<ReportedAbsenceEntity> t, LeaveRequestEntity request)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();

                foreach (ReportedAbsenceEntity ae in t)
                {
                    cmd = new SqlCommand("usp_LinkAbsenceWithLeaveRequest", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ReportedAbsenceId", ae.Id);
                    cmd.Parameters.AddWithValue("@LeaveRequestId", request.Id);

                    conn.Close();
                    cmd.Dispose();

                    cmd.ExecuteNonQuery();
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
