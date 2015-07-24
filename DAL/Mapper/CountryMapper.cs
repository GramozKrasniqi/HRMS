using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class CountryMapper : IGeneralMapper<CountryEntity, CountryEntity>
    {
        public void Insert(CountryEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertCountry", conn);
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

        public void Update(CountryEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdateCountry", conn);
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

        public void Delete(CountryEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteCountry", conn);
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

        public CountryEntity Get(CountryEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetCountryById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);

                SqlDataReader rdr = cmd.ExecuteReader();
                CountryEntity entity = new CountryEntity();

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

        public List<CountryEntity> List(string search)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListCountries", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Search", search);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<CountryEntity> list = new List<CountryEntity>();

                while (rdr.Read())
                {
                    CountryEntity entity = new CountryEntity();
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    entity.Title = Convert.ToString(rdr["Title"]);

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
