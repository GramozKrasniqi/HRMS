using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class ApplicationStringMapper
    {
        public void Insert(int AppId, int LanguageId, ApplicationStringEntity entity)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertApplicationString", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AppId", AppId);
                cmd.Parameters.AddWithValue("@LanguageId", LanguageId);
                cmd.Parameters.AddWithValue("@StringName", entity.StringName);
                cmd.Parameters.AddWithValue("@DefaultValue", entity.DefaultValue);
                cmd.Parameters.AddWithValue("@TranslatedValue", entity.TranslatedValue);

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

        public void Update(int AppId, int LanguageId, ApplicationStringEntity entity)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdateApplicationString", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AppId", AppId);
                cmd.Parameters.AddWithValue("@LanguageId", LanguageId);
                cmd.Parameters.AddWithValue("@StringName", entity.StringName);
                cmd.Parameters.AddWithValue("@TranslatedValue", entity.TranslatedValue);

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

        public void Delete(int AppId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteApplicationStringsByAppId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AppId", AppId);

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

        public Dictionary<string, string> ListApplicationStringsByLanguageId(int AppId, int LagnuageId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListAllApplicationStrings", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AppId", AppId);
                cmd.Parameters.AddWithValue("@LagnuageId", LagnuageId);

                SqlDataReader rdr = cmd.ExecuteReader();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();

                while (rdr.Read())
                {
                    if (rdr["TranslatedValue"].ToString() == "")
                    {
                        dictionary.Add(rdr["StringName"].ToString(), rdr["DefaultValue"].ToString());
                    }
                    else
                    {
                        dictionary.Add(rdr["StringName"].ToString(), rdr["TranslatedValue"].ToString());
                    }
                }

                return dictionary;
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

        public Dictionary<string, string> ListAllApplicationStrings(int AppId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListAllApplicationStrings", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AppId", AppId);

                SqlDataReader rdr = cmd.ExecuteReader();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();

                while (rdr.Read())
                {
                    if (rdr["TranslatedValue"].ToString() == "")
                    {
                        dictionary.Add(rdr["StringName"].ToString(), rdr["DefaultValue"].ToString());
                    }
                    else
                    {
                        dictionary.Add(rdr["StringName"].ToString(), rdr["TranslatedValue"].ToString());
                    }
                }

                return dictionary;
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
