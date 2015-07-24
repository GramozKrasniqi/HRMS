using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class AmandamentTemplateMapper
    {
        public void Insert(AmandamentTemplateEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertAmandamentTemplate", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", t.Title);
                cmd.Parameters.AddWithValue("@Status", t.Status);
                cmd.Parameters.AddWithValue("@LanguageId", t.LanguageId);
                cmd.Parameters.AddWithValue("@Content", t.Content);

                t.AmandamentTemplateId = Convert.ToInt32(cmd.ExecuteScalar());
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

        public void Update(AmandamentTemplateEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdateAmandamentTemplate", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AmandamentId", t.AmandamentTemplateId);
                cmd.Parameters.AddWithValue("@Title", t.Title);
                cmd.Parameters.AddWithValue("@Status", t.Status);
                cmd.Parameters.AddWithValue("@LanguageId", t.LanguageId);
                cmd.Parameters.AddWithValue("@Content", t.Content);

                t.AmandamentTemplateId = Convert.ToInt32(cmd.ExecuteScalar());
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

        public void Delete(AmandamentTemplateEntity t)
        {
            throw new NotImplementedException();
        }

        public AmandamentTemplateEntity Get(int AmandamentTemplateId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetAmandamentTemplateById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AmandmentTemplateId", AmandamentTemplateId);

                SqlDataReader rdr = cmd.ExecuteReader();
                AmandamentTemplateEntity content = new AmandamentTemplateEntity();

                if (rdr.Read())
                {
                    content.AmandamentTemplateId = Convert.ToInt32(rdr["AmandamentTemplateId"]);
                    content.Title = Convert.ToString(rdr["Title"]);
                }

                return content;
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

        public AmandamentTemplateEntity GetContentById(int AmandmentTemplateId, int? LanguageId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetAmandamentTemplateContentById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AmandamentTemplateId", AmandmentTemplateId);
                
                if (LanguageId != null)
                {
                    cmd.Parameters.AddWithValue("@LanguageId", LanguageId);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                AmandamentTemplateEntity content = new AmandamentTemplateEntity();

                if (rdr.Read())
                {
                    content.AmandamentTemplateId = Convert.ToInt32(rdr["AmandamentTemplateId"]);
                    content.Title = Convert.ToString(rdr["Title"]);
                    content.LanguageId = Convert.ToInt32(rdr["LanguageId"]);
                    content.Content = Convert.ToString(rdr["Content"]);
                }

                return content;
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


        public List<AmandamentTemplateEntity> List(string search)
        {
            throw new NotImplementedException();
        }

        public List<AmandamentTemplateEntity> ListWithAdvancedFilter(string search, StatusEnum? status)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListAmandamentsTemplates", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Search", search);

                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<AmandamentTemplateEntity> list = new List<AmandamentTemplateEntity>();

                while (rdr.Read())
                {
                    AmandamentTemplateEntity entity = new AmandamentTemplateEntity();
                    entity.AmandamentTemplateId = Convert.ToInt32(rdr["AmandamentTemplateId"]);
                    entity.Title = Convert.ToString(rdr["Title"]);
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


        public Dictionary<int, string> ListTemplateContractsFromCurrentJobDetails()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListTemplateContractsFromCurrentJobDetails", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                SqlDataReader rdr = cmd.ExecuteReader();
                Dictionary<int, string> list = new Dictionary<int, string>();

                while (rdr.Read())
                {
                    list.Add(Convert.ToInt32(rdr["Id"]), Convert.ToString(rdr["ContractTemplateTitle"]));
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
