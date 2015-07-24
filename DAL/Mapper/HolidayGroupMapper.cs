using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Mapper
{
    public class HolidayGroupMapper
    {
        public void Insert(HolidayGroupEntity entity)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertHolidayGroup", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", entity.Title);
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

        public void InsertForContractTemplate(HolidayGroupEntity entity, int ContractTemplateId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertHolidayGroupForContractTemplate", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@HolidayGroupId", entity.Id);
                cmd.Parameters.AddWithValue("@ContractTemplateId", ContractTemplateId);
                cmd.Parameters.AddWithValue("@Status", StatusEnum.Active);

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

        public void DeleteForContractTemplate(int ContractTemplateId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteHolidayGroupForContractTemplate", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractTemplateId", ContractTemplateId);

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

        public void Update(HolidayGroupEntity entity)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdateHolidayGroup", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@Status", Convert.ToInt32(entity.Status));
                cmd.Parameters.AddWithValue("@Title", entity.Title);
                cmd.Parameters.AddWithValue("@Description", entity.Description);

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
        public void Delete(HolidayGroupEntity entity)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteHolidayGroup", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", entity.Id);

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

        public List<HolidayGroupEntity> List(string search)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListHolidayGroup", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search", search);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<HolidayGroupEntity> list = new List<HolidayGroupEntity>();

                while (rdr.Read())
                {
                    HolidayGroupEntity entity = new HolidayGroupEntity();

                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Title = Convert.ToString(rdr["Title"]);
                    entity.Description = Convert.ToString(rdr["Description"]);
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);

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

        public HolidayGroupEntity Get(HolidayGroupEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetHolidayGroupById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);

                SqlDataReader rdr = cmd.ExecuteReader();
                HolidayGroupEntity entity = new HolidayGroupEntity();

                if (rdr.Read())
                {
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Status = (StatusEnum)rdr["Status"];
                    entity.Title = Convert.ToString(rdr["Title"]);
                    entity.Description = Convert.ToString(rdr["Description"]);
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

        public List<HolidayGroupEntity> ListByContractTemplateId(int ContractTemplateId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListHolidayGroupByContractTemplateId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContractTemplateId", ContractTemplateId);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<HolidayGroupEntity> list = new List<HolidayGroupEntity>();

                while (rdr.Read())
                {
                    HolidayGroupEntity entity = new HolidayGroupEntity();

                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Title = Convert.ToString(rdr["Title"]);
                    entity.Description = Convert.ToString(rdr["Description"]);
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);

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
