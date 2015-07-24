using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class StepMapper : IGeneralMapper<StepEntity, StepEntity>
    {
        public void Insert(StepEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertStep", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StepId", t.Id);
                cmd.Parameters.AddWithValue("@GradeId", t.GradeId);
                cmd.Parameters.AddWithValue("@Description", t.Description);

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

        public void Update(StepEntity t)
        {
            throw new NotImplementedException();
        }

        public void Delete(StepEntity t)
        {
            throw new NotImplementedException();
        }

        public StepEntity Get(StepEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetStepById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);

                SqlDataReader rdr = cmd.ExecuteReader();
                StepEntity step = new StepEntity();

                if (rdr.Read())
                {
                    step.Id = Convert.ToString(rdr["StepId"]);
                    step.GradeId = Convert.ToString(rdr["GradeId"]);
                    step.Description = Convert.ToString(rdr["Description"]);
                    step.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                }

                return step;
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

        public List<StepEntity> List(string search)
        {
            throw new NotImplementedException();
        }

        public List<StepEntity> ListByGradeId(string gradeId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                List<StepEntity> list = new List<StepEntity>();
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListStepsByGradeId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (gradeId != "")
                {
                    cmd.Parameters.AddWithValue("@GradeId", gradeId);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        StepEntity entity = new StepEntity();
                        entity.Id = Convert.ToString(rdr["StepId"]);
                        entity.GradeId = Convert.ToString(rdr["GradeId"]);
                        entity.Description = Convert.ToString(rdr["Description"]);
                        entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);

                        list.Add(entity);
                    }
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
