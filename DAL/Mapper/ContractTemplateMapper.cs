using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class ContractTemplateMapper
    {
        
        public void InsertContentForLanguage(ContractTemplateEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertContractTemplateContentForLanguage", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractTemplateId", t.Id);
                cmd.Parameters.AddWithValue("@LanguageId", t.LanguageId);
                cmd.Parameters.AddWithValue("@Content", t.Content);

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

        public void Insert(ContractTemplateEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertContractTemplate", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", t.Title);
                cmd.Parameters.AddWithValue("@Preffix", t.Preffix);
                cmd.Parameters.AddWithValue("@Status", t.Status);
                cmd.Parameters.AddWithValue("@LanguageId", t.LanguageId);
                cmd.Parameters.AddWithValue("@Content", t.Content);
                cmd.Parameters.AddWithValue("@LeaveDaysPerMonth", t.LeaveDaysPerMonth);
                cmd.Parameters.AddWithValue("@LeaveDaysPerYearExperience", t.LeaveDaysPerYearExperience);
                cmd.Parameters.AddWithValue("@DaysCarriedForwardPerYear", t.DaysCarriedForwardPerYear);


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

        public void Update(ContractTemplateEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdateContractTemplate", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);
                cmd.Parameters.AddWithValue("@Title", t.Title);
                cmd.Parameters.AddWithValue("@Preffix", t.Preffix);
                cmd.Parameters.AddWithValue("@Status", t.Status);
                cmd.Parameters.AddWithValue("@LanguageId", t.LanguageId);
                cmd.Parameters.AddWithValue("@Content", t.Content);
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

        /// <summary>
        /// Deletes all realtions with this contract template and then deletes the contract template
        /// </summary>
        /// <param name="ContractTemplateId"></param>
        public void Delete(int ContractTemplateId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteCompleteContractTemplate", conn);
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

        public ContractTemplateEntity Get(int Id)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetContractTemplateById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractTemplateId", Id);

                SqlDataReader rdr = cmd.ExecuteReader();
                ContractTemplateEntity content = new ContractTemplateEntity();

                while (rdr.Read())
                {
                    content.Id = Convert.ToInt32(rdr["Id"]);
                    content.Title = Convert.ToString(rdr["Title"]);
                    content.Preffix = Convert.ToString(rdr["Preffix"]);
                    content.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    content.LeaveDaysPerMonth = Convert.ToDouble(rdr["LeaveDaysPerMonth"]);
                    content.LeaveDaysPerYearExperience = Convert.ToDouble(rdr["LeaveDaysPerYearExperience"]);
                    content.DaysCarriedForwardPerYear = Convert.ToDouble(rdr["DaysCarriedForwardPerYear"]);
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

        public ContractTemplateEntity GetContentById(int ContractTemplateId, int LanguageId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetContractTemplateContentById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractTemplateId", ContractTemplateId);
                cmd.Parameters.AddWithValue("@LanguageId", LanguageId);

                SqlDataReader rdr = cmd.ExecuteReader();
                ContractTemplateEntity content = new ContractTemplateEntity();

                while (rdr.Read())
                {
                    content.Id = Convert.ToInt32(rdr["ContractTemplateId"]);
                    content.Title = Convert.ToString(rdr["Title"]);
                    content.Preffix = Convert.ToString(rdr["Preffix"]);
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

        public ContractTemplateEntity GetContentByPreffix(ContractTemplateEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetContractTemplateContentByPreffix", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Preffix", t.Preffix);

                SqlDataReader rdr = cmd.ExecuteReader();
                ContractTemplateEntity content = new ContractTemplateEntity();

                while (rdr.Read())
                {
                    content.Id = Convert.ToInt32(rdr["ContractTemplateId"]);
                    content.Title = Convert.ToString(rdr["Title"]);
                    content.Preffix = Convert.ToString(rdr["Preffix"]);
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

        public List<ContractTemplateEntity> List(string search)
        {
            throw new NotImplementedException();
        }

        public List<ContractTemplateEntity> ListWithAdvancedFilter(string search, StatusEnum? status)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListContractsTemplates", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Search", search);

                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<ContractTemplateEntity> list = new List<ContractTemplateEntity>();

                while (rdr.Read())
                {
                    ContractTemplateEntity entity = new ContractTemplateEntity();
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Title = Convert.ToString(rdr["Title"]);
                    entity.Preffix = Convert.ToString(rdr["Preffix"]);
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
