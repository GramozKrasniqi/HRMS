using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class OrganizationalUnitGroupMapper
    {

        public void Insert(OrganizationalUnitGroupEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertOrganizationalUnitGroup", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

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

        public void Update(OrganizationalUnitGroupEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdateOrganizationalUnitGroup", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);
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

        public void Delete(OrganizationalUnitGroupEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteOrganizationalUnitGroup", conn);
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

        public OrganizationalUnitGroupEntity Get(OrganizationalUnitGroupEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetOrganisationalUnitGroupById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    OrganizationalUnitGroupEntity entity = new OrganizationalUnitGroupEntity();
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    entity.Title = Convert.ToString(rdr["Title"]);
                    entity.Description = Convert.ToString(rdr["Description"]);

                    return entity;
                }

                return null;
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

        public List<OrganizationalUnitGroupEntity> List(string search)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListOrganisationalUnitGroups", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Search", search);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<OrganizationalUnitGroupEntity> list = new List<OrganizationalUnitGroupEntity>();

                while (rdr.Read())
                {
                    OrganizationalUnitGroupEntity entity = new OrganizationalUnitGroupEntity();
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    entity.Title = Convert.ToString(rdr["Title"]);
                    entity.Description = Convert.ToString(rdr["Description"]);

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
