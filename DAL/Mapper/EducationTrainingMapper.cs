using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class EducationTrainingMapper : IGeneralMapper<EducationTrainingEntity, EducationTrainingEntity>
    {
        public void Insert(EducationTrainingEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertEducationAndTraining", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", t.EmployeeId);
                cmd.Parameters.AddWithValue("@DateFrom", t.DateFrom);
                if (t.DateTo != null)
                {
                    cmd.Parameters.AddWithValue("@DateTo", t.DateTo);
                }
                cmd.Parameters.AddWithValue("@OrganizationName", t.OrganizationName);
                cmd.Parameters.AddWithValue("@OrganizationContact", t.OrganizationContact);
                cmd.Parameters.AddWithValue("@QualificationAwarded", t.QualificationAwarded);
                cmd.Parameters.AddWithValue("@Level", t.Level);

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

        public void Update(EducationTrainingEntity t)
        {
            throw new NotImplementedException();
        }

        public void Delete(EducationTrainingEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteEducationTrainingById", conn);
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

        public EducationTrainingEntity Get(EducationTrainingEntity t)
        {
            throw new NotImplementedException();
        }

        public List<EducationTrainingEntity> List(string search)
        {
            throw new NotImplementedException();
        }

        public List<EducationTrainingEntity> ListByEmployeeId(int employeeId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListEducationsAndTrainingsByEmployeeId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<EducationTrainingEntity> list = new List<EducationTrainingEntity>();

                while (rdr.Read())
                {
                    EducationTrainingEntity entity = new EducationTrainingEntity();
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    entity.DateFrom = Convert.ToDateTime(rdr["DateFrom"]);
                    if (rdr["DateTo"] != DBNull.Value)
                    {
                        entity.DateTo = Convert.ToDateTime(rdr["DateTo"]);
                    }
                    entity.OrganizationContact = Convert.ToString(rdr["OrganizationContact"]);
                    entity.OrganizationName = Convert.ToString(rdr["OrganizationName"]);
                    entity.QualificationAwarded = Convert.ToString(rdr["QualificationAwarded"]);
                    entity.Level = (EducationTrainingLevelEnum)Convert.ToInt32(rdr["Level"]);
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
