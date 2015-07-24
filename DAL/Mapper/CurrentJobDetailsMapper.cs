using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class CurrentJobDetailsMapper : IGeneralMapper<CurrentJobDetailsEntity, CurrentJobDetailsEntity>
    {
        public void Insert(CurrentJobDetailsEntity t)
        {
            throw new NotImplementedException();
        }

        public void Update(CurrentJobDetailsEntity t)
        {
            throw new NotImplementedException();
        }

        public void Delete(CurrentJobDetailsEntity t)
        {
            throw new NotImplementedException();
        }

        public CurrentJobDetailsEntity Get(CurrentJobDetailsEntity t)
        {
            return Get(t, false);
        }

        public CurrentJobDetailsEntity Get(CurrentJobDetailsEntity t, bool useInSearchContractNumber)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetCurrentJobDetailsByEmployeeId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", t.EmployeeId);
                if (useInSearchContractNumber == true)
                {
                    cmd.Parameters.AddWithValue("@ContractNumber", t.ContractNumber);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                CurrentJobDetailsEntity entity = new CurrentJobDetailsEntity();

                while (rdr.Read())
                {
                    entity.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    
                    entity.FunctionalLevelId = Convert.ToInt32(rdr["FunctionalLevelId"]);
                    entity.FunctionalLevelTitle = Convert.ToString(rdr["FunctionalLeveTitle"]);

                    entity.OrganizationalUnitId = Convert.ToInt32(rdr["OrganizationalUnitId"]);
                    entity.OrganizationalUnitTitle = Convert.ToString(rdr["OrganizationalUnitTitle"]);
                    
                    entity.JobCode = Convert.ToString(rdr["JobCode"]);
                    entity.JobTitle = Convert.ToString(rdr["JobTitle"]);
                    
                    entity.GradeId = Convert.ToString(rdr["GradeId"]);
                    //entity.GradeKCB = Convert.ToDouble(rdr["GradeKCB"]);
                    //entity.GradeEntry = Convert.ToDouble(rdr["GradeEntry"]);
                    
                    entity.StepId = Convert.ToString(rdr["StepId"]);
                    //entity.StepEntry = Convert.ToDouble(rdr["StepEntry"]);
                    
                    entity.GrossValue = Convert.ToDouble(rdr["GrossValue"]);
                    entity.ContractNumber = Convert.ToString(rdr["ContractNumber"]);
                    entity.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    if (rdr["EndDate"] != DBNull.Value)
                    {
                        entity.EndDate = Convert.ToDateTime(rdr["EndDate"]);
                    }

                    entity.IsWithoutEndDate = (ContractType)Convert.ToInt32(rdr["IsWithoutEndDate"]);
                    if (rdr["JoiningDate"] != DBNull.Value)
                    {
                        entity.JoiningDate = Convert.ToDateTime(rdr["JoiningDate"]);
                    }
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

        public List<CurrentJobDetailsEntity> List(string search)
        {
            throw new NotImplementedException();
        }
    }
}
