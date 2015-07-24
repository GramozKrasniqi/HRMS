using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class RoleMapper : IGeneralMapper<RoleEntity, RoleEntity>
    {
        public void Insert(RoleEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertRole", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ApplicationId", t.ApplicationId);
                cmd.Parameters.AddWithValue("@Title", t.Title);
                cmd.Parameters.AddWithValue("@Description", t.Description);

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

        public void InsertUserForRole(UserEntity u, RoleEntity r, SqlCommand transactionCMD)
        {
            if (transactionCMD != null)
            {
                transactionCMD.CommandText = "usp_InsertUserForRole";
                transactionCMD.CommandType = System.Data.CommandType.StoredProcedure;
                transactionCMD.Parameters.AddWithValue("@RoleId", r.Id);
                transactionCMD.Parameters.AddWithValue("@EmployeeId", u.EmployeeId);
                transactionCMD.Parameters.AddWithValue("@ApplicationId", u.ApplicationId);
                transactionCMD.Parameters.AddWithValue("@Status", StatusEnum.Active);

                transactionCMD.ExecuteNonQuery();
            }
            else
            {

                SqlConnection conn = null;
                SqlCommand cmd = null;

                try
                {
                    conn = DALHelper.CreateSqlDbConnection();
                    cmd = new SqlCommand("usp_InsertUserForRole", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RoleId", r.Id);
                    cmd.Parameters.AddWithValue("@EmployeeId", u.EmployeeId);
                    cmd.Parameters.AddWithValue("@ApplicationId", u.ApplicationId);
                    cmd.Parameters.AddWithValue("@Status", StatusEnum.Active);

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
        }

        public void Update(RoleEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdateRole", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", t.Id);
                cmd.Parameters.AddWithValue("@ApplicationId", t.ApplicationId);
                cmd.Parameters.AddWithValue("@Title", t.Title);
                cmd.Parameters.AddWithValue("@Description", t.Description);
                cmd.Parameters.AddWithValue("@Status", t.Status);


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

        public void Delete(RoleEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteRole", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", t.Id);
                cmd.Parameters.AddWithValue("@ApplicationId", t.ApplicationId);

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

        public RoleEntity Get(RoleEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetRolebyId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", t.Id);
                cmd.Parameters.AddWithValue("@ApplicationId", t.ApplicationId);

                SqlDataReader rdr = cmd.ExecuteReader();
                RoleEntity entity = new RoleEntity();

                if (rdr.Read())
                {
                    entity.Id = t.Id;
                    entity.ApplicationId = Convert.ToInt32(rdr["ApplicationId"]);
                    entity.Title = Convert.ToString(rdr["Title"]);
                    entity.Description = Convert.ToString(rdr["Description"]);
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
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

        public List<RoleEntity> List(string search)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListRole", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search", search);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<RoleEntity> list = new List<RoleEntity>();

                while (rdr.Read())
                {
                    RoleEntity entity = new RoleEntity();

                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.ApplicationId = Convert.ToInt32(rdr["ApplicationId"]);
                    entity.Title = Convert.ToString(rdr["Title"]);
                    entity.Description = Convert.ToString(rdr["Description"]);
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

        public List<RoleEntity> GetRoleForUser(string username)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetRolesForUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<RoleEntity> list = new List<RoleEntity>();

                if (rdr.Read())
                {
                    RoleEntity entity = new RoleEntity();

                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.ApplicationId = Convert.ToInt32(rdr["ApplicationId"]);
                    entity.Title = Convert.ToString(rdr["Title"]);
                    entity.Description = Convert.ToString(rdr["Description"]);
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

        public bool RoleCanViewForm(int roleId, string formPath)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_RoleCanViewForm", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleId", roleId);
                cmd.Parameters.AddWithValue("@FormPath", formPath);

                return Convert.ToBoolean((int)cmd.ExecuteScalar());
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
