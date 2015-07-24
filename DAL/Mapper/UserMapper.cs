using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using Entities.Views;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class UserMapper : IGeneralMapper<UserEntity, UserView>
    {
        public void Insert(UserEntity t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// if cmd is set this tells us that we are using this query with trasanction
        /// </summary>
        /// <param name="t"></param>
        /// <param name="cmd"></param>
        public void Insert(UserEntity t, SqlCommand transactionCMD)
        {
            if (transactionCMD != null)
            {
                transactionCMD.CommandText = "usp_InsertUser";
                transactionCMD.CommandType = System.Data.CommandType.StoredProcedure;
                transactionCMD.Parameters.AddWithValue("@EmployeeId", t.EmployeeId);
                transactionCMD.Parameters.AddWithValue("@ApplicationId", t.ApplicationId);
                transactionCMD.Parameters.AddWithValue("@Username", t.Username);
                transactionCMD.Parameters.AddWithValue("@Password", t.Password);

                transactionCMD.ExecuteNonQuery();
            }
            else
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;

                try
                {
                    conn = DALHelper.CreateSqlDbConnection();
                    cmd = new SqlCommand("usp_InsertUser", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", t.EmployeeId);
                    cmd.Parameters.AddWithValue("@ApplicationId", t.ApplicationId);
                    cmd.Parameters.AddWithValue("@Username", t.Username);
                    cmd.Parameters.AddWithValue("@Password", t.Password);

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

        public void Update(UserEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdateUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", t.EmployeeId);
                cmd.Parameters.AddWithValue("@ApplicationId", t.ApplicationId);
                cmd.Parameters.AddWithValue("@Username", t.Username);
                cmd.Parameters.AddWithValue("@Password", t.Password);
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

        public void Delete(UserEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", t.EmployeeId);
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

        public UserView Get(UserEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetUserByEmployeeId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", t.EmployeeId);
                cmd.Parameters.AddWithValue("@ApplicationId", t.ApplicationId);

                SqlDataReader rdr = cmd.ExecuteReader();
                UserView entity = new UserView();

                if (rdr.Read())
                {
                    entity.EmployeeId = Convert.ToInt32(rdr["EmloyeeId"]);
                    entity.ApplicationId = Convert.ToInt32(rdr["ApplicationId"]);
                    entity.Username = Convert.ToString(rdr["Username"]);
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    entity.EmployeeFullName = Convert.ToString(rdr["FullName"]);

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

        public UserView GetUserByUserName(string username)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetUserByUsername", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", username);

                SqlDataReader rdr = cmd.ExecuteReader();
                UserView entity = new UserView();

                if (rdr.Read())
                {
                    entity.EmployeeId = Convert.ToInt32(rdr["EmloyeeId"]);
                    entity.ApplicationId = Convert.ToInt32(rdr["ApplicationId"]);
                    entity.Username = Convert.ToString(rdr["Username"]);
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    entity.EmployeeFullName = Convert.ToString(rdr["FullName"]);

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

        public List<UserView> List(string search)
        {
            throw new NotImplementedException();
        }

        public List<UserView> ListByRoleId(string search, int? roleId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListUsersAdvancedFilter", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (roleId != null)
                {
                    cmd.Parameters.AddWithValue("@RoleId", roleId);
                }
                cmd.Parameters.AddWithValue("@Username", search);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<UserView> list = new List<UserView>();

                while (rdr.Read())
                {
                    UserView view = new UserView();
                    view.EmployeeId = Convert.ToInt32(rdr["EmloyeeId"]);
                    view.ApplicationId = Convert.ToInt32(rdr["ApplicationId"]);
                    view.Username = Convert.ToString(rdr["Username"]);
                    view.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    view.EmployeeFullName = Convert.ToString(rdr["FullName"]);

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

        public void DeleteUsersFromRole(RoleEntity entity)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteUsersFromRole", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ApplicationId", entity.ApplicationId);
                cmd.Parameters.AddWithValue("@RoleId", entity.Id);

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
}
