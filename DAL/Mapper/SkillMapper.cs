using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class SkillMapper
    {
        public void Insert(SkillEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertSkill", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", t.EmployeeId);
                cmd.Parameters.AddWithValue("@SkillName", t.SkillName);

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

        public void Delete(SkillEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteSkill", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", t.EmployeeId);
                cmd.Parameters.AddWithValue("@SkillName", t.SkillName);

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

        public List<SkillEntity> List(int EmployeeId, string search)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListSkillsByEmployeeId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                cmd.Parameters.AddWithValue("@SkillName", search);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<SkillEntity> list = new List<SkillEntity>();

                while (rdr.Read())
                {
                    SkillEntity entity = new SkillEntity();
                    entity.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    entity.SkillName = Convert.ToString(rdr["SkillName"]);

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
