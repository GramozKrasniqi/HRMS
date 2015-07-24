using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class ContractMapper : IGeneralMapper<ContractEntity, ContractEntity>
    {
        public void InsertContent(ContractContentEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertContractContent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

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
        public void Insert(ContractEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertContract", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractNumber", t.ContractNumber);
                cmd.Parameters.AddWithValue("@EmployeeId", t.EmployeeId);

                cmd.Parameters.AddWithValue("@FunctionalLevelId", t.FunctionalLevelId);
                cmd.Parameters.AddWithValue("@FunctionalLevelTitle", t.FunctionalLevelTitle);
                
                cmd.Parameters.AddWithValue("@ContractTemplateTitle", t.ContractTemplateTitle);
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

                cmd.Parameters.AddWithValue("@OfficiallyApprovedDate", t.OfficiallyApprovedDate);
                cmd.Parameters.AddWithValue("@StartDate", t.StartDate);

                if (t.Type != ContractType.Permanent)
                {
                    cmd.Parameters.AddWithValue("@EndDate", t.EndDate);
                }
                cmd.Parameters.AddWithValue("@IsWithoutEndDate", t.Type);

                cmd.Parameters.AddWithValue("@GrossValue", t.GrossValue);
                cmd.Parameters.AddWithValue("@EmployeeNo", t.EmployeeNo);
                cmd.Parameters.AddWithValue("@EmployeeFirstname", t.EmployeeFirstname);
                cmd.Parameters.AddWithValue("@EmployeeLastname", t.EmployeeLastname);
                cmd.Parameters.AddWithValue("@EmployeePersonalNumber", t.EmployeePersonalNumber);
                cmd.Parameters.AddWithValue("@ContractStatus", t.ContractStatus);
                if (t.NextContractNumber != "")
                {
                    cmd.Parameters.AddWithValue("@NextContractNumber", t.NextContractNumber);
                }
                cmd.Parameters.AddWithValue("@Status", t.Status);
                cmd.Parameters.AddWithValue("@ContentStatus", t.Content.ContentStatus);

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

        public void Update(ContractEntity t)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Set contractNumber, NextContractNumber (it can be null), ContractStatus and Status (this defines if the contract is old)
        /// </summary>
        /// <param name="t"></param>
        public void UpdatePreviousContract(ContractEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdatePreviousContract", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractNumber", t.ContractNumber);
                if (t.NextContractNumber != null)
                {
                    cmd.Parameters.AddWithValue("@NextContractNumber", t.NextContractNumber);
                }
                cmd.Parameters.AddWithValue("@ContractStatus", t.ContractStatus);
                cmd.Parameters.AddWithValue("@Status", t.Status);

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

        public void Delete(ContractEntity t)
        {
            throw new NotImplementedException();
        }

        public ContractEntity GetByLanguageId(ContractEntity t, int languageId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetContractByContractNumber", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractNumber", t.ContractNumber);
                cmd.Parameters.AddWithValue("@LanguageId", languageId);

                SqlDataReader rdr = cmd.ExecuteReader();
                ContractEntity entity = new ContractEntity();

                while (rdr.Read())
                {
                    entity.ContractNumber = Convert.ToString(rdr["ContractNumber"]);
                    entity.ContractTemplateTitle = Convert.ToString(rdr["ContractTemplateTitle"]);
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
                    entity.ContractStatus = (ContractStatus)Convert.ToInt32(rdr["ContractStatus"]);
                    if(rdr["NextContractNumber"] != DBNull.Value)
                    {
                        entity.NextContractNumber = Convert.ToString(rdr["NextContractNumber"]);
                    }
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
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

        public ContractEntity Get(ContractEntity t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get last contract from employee
        /// </summary>
        /// <param name="t">Initialize the t.EmployeeId. It is required.</param>
        /// <returns></returns>
        public ContractEntity GetLastContract(ContractEntity t)
        {
            List<ContractEntity> list = ListWithAdvancedFilter(t.EmployeeId, StatusEnum.Active);
            if(list.Count != 0)
            {
                return list[0];
            }
            else
            {
                return new ContractEntity();
            }
        }

        public List<ContractContentEntity> ListLastContractsContents(ContractEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListLastContractsContents", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractNumber", t.ContractNumber);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<ContractContentEntity> list = new List<ContractContentEntity>();

                while (rdr.Read())
                {
                    ContractContentEntity view = new ContractContentEntity();
                    view.Content = Convert.ToString(rdr["Content"]);
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

        public List<ContractEntity> List(string search)
        {
            throw new NotImplementedException();
        }

        public List<ContractEntity> ListWithAdvancedFilter(int employeeId, StatusEnum? status)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListContracts", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status",status);
                }
                
                SqlDataReader rdr = cmd.ExecuteReader();
                List<ContractEntity> list = new List<ContractEntity>();

                while (rdr.Read())
                {
                    ContractEntity view = new ContractEntity();
                    view.ContractNumber = Convert.ToString(rdr["ContractNumber"]);
                    view.ContractTemplateTitle = Convert.ToString(rdr["ContractTemplateTitle"]);
                    view.OrganizationalUnitTitle = Convert.ToString(rdr["OrganizationalUnitTitle"]);
                    view.JobTitle = Convert.ToString(rdr["JobTitle"]);
                    view.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    if(rdr["EndDate"] != DBNull.Value)
                    {
                        view.EndDate = Convert.ToDateTime(rdr["EndDate"]);
                    }
                    view.ContractStatus = (ContractStatus)Convert.ToInt32(rdr["ContractStatus"]);
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
