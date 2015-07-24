using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class AmandamentMapper
    {
        public void InsertContent(AmandamentContentEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertContractContent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AmandamentId", t.AmandamentId);
                cmd.Parameters.AddWithValue("@ContractNumber", t.ContractNumber);
                cmd.Parameters.AddWithValue("@LanguageId", t.LanguageId);
                cmd.Parameters.AddWithValue("@Content", t.Content);

                cmd.ExecuteScalar();
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

        public void Insert(AmandamentEntity t)
        {
            throw new NotImplementedException();
        }

        public void Insert(AmandamentEntity t, int employeeId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertAmandamentWithContent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //@Status int,
                //@LanguageId int = 1,

                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                cmd.Parameters.AddWithValue("@ContractNumber", t.ContractNumber);

                cmd.Parameters.AddWithValue("@FunctionalLevelId", t.FunctionalLevelId);
                cmd.Parameters.AddWithValue("@FunctionalLevelTitle", t.FunctionalLevelTitle);

                cmd.Parameters.AddWithValue("@OrganizationalUnitId", t.OrganizationalUnitId);
                cmd.Parameters.AddWithValue("@OrganizationalUnitTitle", t.OrganizationalUnitTitle);
                cmd.Parameters.AddWithValue("@JobCode", t.JobCode);
                cmd.Parameters.AddWithValue("@JobTitle", t.JobTitle);

                if (t.GradeId != "")
                {
                    cmd.Parameters.AddWithValue("@GradeId", t.GradeId);
                }
                if (t.GradeKCB != 0)
                {
                    cmd.Parameters.AddWithValue("@GradeKCB", t.GradeKCB);
                }
                if (t.GradeEntry != 0)
                {
                    cmd.Parameters.AddWithValue("@GradeEntry", t.GradeEntry);
                }
                if (t.StepId != "")
                {
                    cmd.Parameters.AddWithValue("@StepId", t.StepId);
                }
                if (t.StepEntry != 0)
                {
                    cmd.Parameters.AddWithValue("@StepEntry", t.StepEntry);
                }

                cmd.Parameters.AddWithValue("@OfficiallyApprovedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@StartDate", t.StartDate);

                if (t.Type != ContractType.Permanent)
                {
                    cmd.Parameters.AddWithValue("@EndDate", t.EndDate);
                }
                cmd.Parameters.AddWithValue("@IsWithoutEndDate", t.Type);

                cmd.Parameters.AddWithValue("@GrossValue", t.GrossValue);
                cmd.Parameters.AddWithValue("@Status", t.Status);
                //cmd.Parameters.AddWithValue("@LanguageId", t.Content.LanguageId);
                cmd.Parameters.AddWithValue("@Content", t.Content.Content);

                cmd.ExecuteScalar();
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

        public void Update(AmandamentEntity t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int AmandmentId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteAmandmentTemplate", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AmandamentTemplateId", AmandmentId);

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

        public AmandamentEntity GetByLanguageId(AmandamentEntity t, int languageId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetAmandamentById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AmandamentId", t.AmandamentId);
                cmd.Parameters.AddWithValue("@LanguageId", languageId);

                SqlDataReader rdr = cmd.ExecuteReader();
                AmandamentEntity entity = new AmandamentEntity();

                while (rdr.Read())
                {
                    entity.AmandamentId = Convert.ToInt32(rdr["AmandamentId"]);
                    entity.ContractNumber = Convert.ToString(rdr["ContractNumber"]);
                    entity.OrganizationalUnitTitle = Convert.ToString(rdr["OrganizationalUnitTitle"]);
                    entity.JobCode = Convert.ToString(rdr["JobCode"]);
                    entity.JobTitle = Convert.ToString(rdr["JobTitle"]);
                    entity.GradeId = Convert.ToString(rdr["GradeId"]);
                    entity.GradeKCB = Convert.ToDouble(rdr["GradeKCB"]);
                    entity.GradeEntry = Convert.ToDouble(rdr["GradeEntry"]);
                    entity.StepId = Convert.ToString(rdr["StepId"]);
                    entity.StepEntry = Convert.ToDouble(rdr["StepEntry"]);
                    entity.OfficiallyApprovedDate = Convert.ToDateTime(rdr["OfficiallyApprovedDate"]);
                    entity.GrossValue = Convert.ToDouble(rdr["GrossValue"]);
                    entity.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    if (rdr["EndDate"] != DBNull.Value)
                    {
                        entity.EndDate = Convert.ToDateTime(rdr["EndDate"]);
                    }
                    entity.Content.Content = Convert.ToString(rdr["Content"]);
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

        public AmandamentEntity Get(AmandamentEntity t)
        {
            throw new NotImplementedException();
        }

        public AmandamentEntity GetLastAmandament(AmandamentEntity t)
        {
            return GetByLanguageId(ListWithAdvancedFilter(t, StatusEnum.Active)[0], 1);
        }

        public List<AmandamentEntity> List(string search)
        {
            throw new NotImplementedException();
        }

        public List<AmandamentEntity> ListWithAdvancedFilter(AmandamentEntity entity, StatusEnum? status)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("[usp_ListAmandaments]", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractNumber", entity.ContractNumber);
                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<AmandamentEntity> list = new List<AmandamentEntity>();

                while (rdr.Read())
                {
                    AmandamentEntity view = new AmandamentEntity();
                    view.AmandamentId = Convert.ToInt32(rdr["AmandamentId"]);
                    view.ContractNumber = Convert.ToString(rdr["ContractNumber"]);
                    view.OrganizationalUnitTitle = Convert.ToString(rdr["OrganizationalUnitTitle"]);
                    view.JobTitle = Convert.ToString(rdr["JobTitle"]);
                    view.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    if (rdr["EndDate"] != DBNull.Value)
                    {
                        view.EndDate = Convert.ToDateTime(rdr["EndDate"]);
                    }
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
