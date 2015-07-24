using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Mapper
{
    public class HolidayMapper
    {
        public void Insert(HolidayEntity entity)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertHoliday", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", entity.Title);
                cmd.Parameters.AddWithValue("@HolidayGroupId", entity.HolidayGroupId);
                cmd.Parameters.AddWithValue("@StartDate", entity.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", entity.EndDate);
                cmd.Parameters.AddWithValue("@Description", entity.Description);

                entity.Id = Convert.ToInt32(cmd.ExecuteScalar());
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

        public void Update(HolidayEntity entity)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdateHolidayGroup", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", entity.Title);
                cmd.Parameters.AddWithValue("@HolidayGroupId", entity.HolidayGroupId);
                cmd.Parameters.AddWithValue("@StartDate", entity.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", entity.EndDate);
                cmd.Parameters.AddWithValue("@Description", entity.Description);
                cmd.Parameters.AddWithValue("@Status", entity.Status);

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
        public void Delete(int Id)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteHoliday", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);

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

        public List<HolidayEntity> List(int HolidayGroupId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListHolidays", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@HolidayGroupId", HolidayGroupId);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<HolidayEntity> list = new List<HolidayEntity>();

                while (rdr.Read())
                {
                    HolidayEntity entity = new HolidayEntity();
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Title = Convert.ToString(rdr["Title"]);
                    entity.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    entity.EndDate = Convert.ToDateTime(rdr["EndDate"]);

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
