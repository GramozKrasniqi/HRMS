using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class GradeMapper : IGeneralMapper<GradeEntity, GradeEntity>
    {
        public void Insert(GradeEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertGrade", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@GradeId", t.Id);
                cmd.Parameters.AddWithValue("@JobCode", t.JobCode);

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

        public void Update(GradeEntity t)
        {
            throw new NotImplementedException();
        }

        public void Delete(GradeEntity t)
        {
            throw new NotImplementedException();
        }

        public GradeEntity Get(GradeEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetGradeById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);

                SqlDataReader rdr = cmd.ExecuteReader();
                GradeEntity grade = new GradeEntity();

                if (rdr.Read())
                {
                    grade.Id = Convert.ToString(rdr["GradeId"]);
                    grade.JobCode = Convert.ToString(rdr["JobCode"]);
                    grade.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                }

                return grade;
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

        public List<GradeEntity> List(string search)
        {
            throw new NotImplementedException();
        }

        public List<GradeEntity> ListByJobeCode(string jobCode)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListGradesByJobCode", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (jobCode == null)
                {
                    cmd.Parameters.AddWithValue("@JobCode", "");
                }
                else
                {
                cmd.Parameters.AddWithValue("@JobCode", jobCode);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<GradeEntity> list = new List<GradeEntity>();

                while (rdr.Read())
                {
                    GradeEntity entity = new GradeEntity();
                    entity.Id = Convert.ToString(rdr["GradeId"]);
                    entity.JobCode = Convert.ToString(rdr["JobCode"]);
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
    }
}
