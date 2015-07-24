using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class BankMapper
    {
        public void Insert(BankEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertBank", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", t.Title);
                cmd.Parameters.AddWithValue("@Description", t.Description);

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

        public void Update(BankEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdateBank", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);
                cmd.Parameters.AddWithValue("@Title", t.Title);
                cmd.Parameters.AddWithValue("@Description", t.Description);
                cmd.Parameters.AddWithValue("@Status", Convert.ToInt32(t.Status));

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

        public void Delete(BankEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteBank", conn);
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

        public BankEntity Get(BankEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetBankById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);

                SqlDataReader rdr = cmd.ExecuteReader();
                BankEntity  entity = new BankEntity();

                while (rdr.Read())
                {
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
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

        public List<BankEntity> List(string search)
        {
            throw new NotImplementedException();
        }

        public List<BankEntity> ListWithAdvancedFilter(string search, StatusEnum? status)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListBanks", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Search", search);
                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<BankEntity> list = new List<BankEntity>();

                while (rdr.Read())
                {
                    BankEntity entity = new BankEntity();
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    entity.Title = Convert.ToString(rdr["Title"]);
                    entity.Description = Convert.ToString(rdr["Description"]);

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
