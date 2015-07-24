using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using Entities.Views;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class LeaveRequestMapper 
    {

        public void RequestLeave(LeaveRequestEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_RequestLeave", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LeaveTypeId", t.LeaveTypeId);
                cmd.Parameters.AddWithValue("@LeaveLevelTypeId", t.PaymentTypeId);
                cmd.Parameters.AddWithValue("@RequestDate", t.RequestDate);
                cmd.Parameters.AddWithValue("@StartDate", t.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", t.EndDate);
                cmd.Parameters.AddWithValue("@IsHalfDay", t.IsHalfDay);
                cmd.Parameters.AddWithValue("@Notes", t.Notes);
                cmd.Parameters.AddWithValue("@EmployeeId", t.EmployeeId);
                cmd.Parameters.AddWithValue("@AlternatePersonId", t.AlternatePersonId);
                cmd.Parameters.AddWithValue("@ManagerEmployeeId", t.ManagerEmployeeId);
                cmd.Parameters.AddWithValue("@Status", t.LeaveStatus);

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

        public LeaveRequestView Get(int Id)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetLeaveRequestById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);

                SqlDataReader rdr = cmd.ExecuteReader();
                LeaveRequestView view = new LeaveRequestView();

                if (rdr.Read())
                {
                    view.Id = Convert.ToInt32(rdr["Id"]);
                    view.LeaveType = Convert.ToString(rdr["LeaveType"]);
                    view.LeaveNameType = (LeaveNameType)Convert.ToInt32(rdr["LeaveNameType"]);
                    view.RequestDate = Convert.ToDateTime(rdr["RequestDate"]);
                    view.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    if (rdr["EndDate"] != DBNull.Value)
                    {
                        view.EndDate = Convert.ToDateTime(rdr["EndDate"]);
                    }
                    if (rdr["HalfDay"] != DBNull.Value)
                    {
                        view.IsHalfDay = Convert.ToBoolean(rdr["HalfDay"]);
                    }
                    view.Notes = Convert.ToString(rdr["Notes"]);
                    view.Employee = Convert.ToString(rdr["Employee"]);
                    view.AlternateEmployee = Convert.ToString(rdr["AlternateEmployee"]);
                    if (rdr["ManagerEmployee"] != DBNull.Value)
                    {
                        view.ManagerEmployee = Convert.ToString(rdr["ManagerEmployee"]);
                    }
                    view.LeaveStatus = (RequestsEnum)Convert.ToInt32(rdr["Status"]);
                }

                return view;
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

        public List<LeaveRequestView> ListWithAdvancedFilter(int employeeId, StatusEnum? status)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListLeaveRequests", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<LeaveRequestView> list = new List<LeaveRequestView>();

                while (rdr.Read())
                {
                    LeaveRequestView view = new LeaveRequestView();
                    view.Id = Convert.ToInt32(rdr["Id"]);
                    view.LeaveType = Convert.ToString(rdr["LeaveType"]);
                    view.LeaveNameType = (LeaveNameType)Convert.ToInt32(rdr["LeaveNameType"]);
                    view.RequestDate = Convert.ToDateTime(rdr["RequestDate"]);
                    view.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    if (rdr["EndDate"] != DBNull.Value)
                    {
                        view.EndDate = Convert.ToDateTime(rdr["EndDate"]);
                    }
                    if (rdr["HalfDay"] != DBNull.Value)
                    {
                        view.IsHalfDay = Convert.ToBoolean(rdr["HalfDay"]);
                    }
                    view.Notes = Convert.ToString(rdr["Notes"]);
                    view.Employee = Convert.ToString(rdr["Employee"]);
                    view.AlternateEmployee = Convert.ToString(rdr["AlternateEmployee"]);
                    if (rdr["ManagerEmployee"] != DBNull.Value)
                    {
                        view.ManagerEmployee = Convert.ToString(rdr["ManagerEmployee"]);
                    }
                    view.LeaveStatus = (RequestsEnum)Convert.ToInt32(rdr["Status"]);
                    list.Add(view);
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

        public List<LeaveRequestView> ListLeaveRequestsApprovedByEmployee(int employeeId, StatusEnum? status)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListLeaveRequestsApprovedByEmployee", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<LeaveRequestView> list = new List<LeaveRequestView>();

                while (rdr.Read())
                {
                    LeaveRequestView view = new LeaveRequestView();
                    view.Id = Convert.ToInt32(rdr["Id"]);
                    view.LeaveType = Convert.ToString(rdr["LeaveType"]);
                    view.LeaveNameType = (LeaveNameType)Convert.ToInt32(rdr["LeaveNameType"]);
                    view.RequestDate = Convert.ToDateTime(rdr["RequestDate"]);
                    view.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    if (rdr["EndDate"] != DBNull.Value)
                    {
                        view.EndDate = Convert.ToDateTime(rdr["EndDate"]);
                    }
                    if (rdr["HalfDay"] != DBNull.Value)
                    {
                        view.IsHalfDay = Convert.ToBoolean(rdr["HalfDay"]);
                    }
                    view.Notes = Convert.ToString(rdr["Notes"]);
                    view.Employee = Convert.ToString(rdr["Employee"]);
                    view.AlternateEmployee = Convert.ToString(rdr["AlternateEmployee"]);
                    if (rdr["ManagerEmployee"] != DBNull.Value)
                    {
                        view.ManagerEmployee = Convert.ToString(rdr["ManagerEmployee"]);
                    }
                    view.LeaveStatus = (RequestsEnum)Convert.ToInt32(rdr["Status"]);
                    list.Add(view);
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
