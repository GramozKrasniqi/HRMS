using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;
using Entities.Views;

namespace DAL.Mapper
{
    public class OrganizationalUnitMapper
    {

        public void Insert(OrganizationalUnitEntity t)
        {
            throw new NotImplementedException();
        }

        public void InsertWithParent(OrganizationalUnitEntity t, int? ParentId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertOrganizationalUnit", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", t.Title);
                cmd.Parameters.AddWithValue("@Description", t.Description);
                if (ParentId != null)
                {
                    cmd.Parameters.AddWithValue("@ParentId", ParentId);
                }
                cmd.Parameters.AddWithValue("@OrganizationalUnitGroupId", t.OrganizationaUnitGroupId);
                cmd.Parameters.AddWithValue("@Status", t.Status);

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

        public void Update(OrganizationalUnitEntity t, int? ParentId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdateOrganizationalUnit", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);
                cmd.Parameters.AddWithValue("@Title", t.Title);
                cmd.Parameters.AddWithValue("@Description", t.Description);
                if (ParentId != null)
                {
                    cmd.Parameters.AddWithValue("@ParentId", ParentId);
                }
                cmd.Parameters.AddWithValue("@OrganizationalUnitGroupId", t.OrganizationaUnitGroupId);
                cmd.Parameters.AddWithValue("@Status", t.Status);

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

        public void Delete(OrganizationalUnitEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteOrganizationalUnit", conn);
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

        public OrganizationalUnitView Get(OrganizationalUnitEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetOrganisationalUnitById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);

                SqlDataReader rdr = cmd.ExecuteReader();
                OrganizationalUnitView organisationalUnitView = new OrganizationalUnitView();

                if (rdr.Read())
                {
                    organisationalUnitView.Id = Convert.ToInt32(rdr["Id"]);
                    organisationalUnitView.Title = Convert.ToString(rdr["Title"]);
                    organisationalUnitView.Description = Convert.ToString(rdr["Description"]);
                    organisationalUnitView.OrganizationaUnitGroup = Convert.ToString(rdr["OrganizationaUnitGroup"]);
                    organisationalUnitView.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                }

                return organisationalUnitView;
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

        public OrganizationalUnitView GetParent(OrganizationalUnitEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetOrganisationalUnitParent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);

                SqlDataReader rdr = cmd.ExecuteReader();
                OrganizationalUnitView organisationalUnitView = new OrganizationalUnitView();

                if (rdr.Read())
                {
                    organisationalUnitView.Id = Convert.ToInt32(rdr["Id"]);
                    organisationalUnitView.Title = Convert.ToString(rdr["Title"]);
                    organisationalUnitView.Description = Convert.ToString(rdr["Description"]);
                    organisationalUnitView.OrganizationaUnitGroup = Convert.ToString(rdr["OrganizationaUnitGroup"]);
                    organisationalUnitView.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                }

                return organisationalUnitView;
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


        public OrganizationalUnitView Get(string name)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetOrganisationalUnitByName", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", name);

                SqlDataReader rdr = cmd.ExecuteReader();
                OrganizationalUnitView organisationalUnitView = new OrganizationalUnitView();

                if (rdr.Read())
                {
                    organisationalUnitView.Id = Convert.ToInt32(rdr["Id"]);
                    organisationalUnitView.Title = Convert.ToString(rdr["Title"]);
                    organisationalUnitView.Description = Convert.ToString(rdr["Description"]);
                    organisationalUnitView.OrganizationaUnitGroup = Convert.ToString(rdr["OrganizationaUnitGroup"]);
                    organisationalUnitView.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                }

                return organisationalUnitView;
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

        public List<OrganizationalUnitView> List(string search)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListOrganisationalUnits", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Search", search);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<OrganizationalUnitView> list = new List<OrganizationalUnitView>();

                while (rdr.Read())
                {
                    OrganizationalUnitView entity = new OrganizationalUnitView();
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    entity.Title = Convert.ToString(rdr["Title"]);
                    entity.Description = Convert.ToString(rdr["Description"]);
                    entity.OrganizationaUnitGroup = Convert.ToString(rdr["OrganizationaUnitGroup"]);

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

        public List<OrganizationalUnitView> ListByParentId(int ParentId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListOrganisationalUnitsByParentId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ParentId", ParentId);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<OrganizationalUnitView> list = new List<OrganizationalUnitView>();

                while (rdr.Read())
                {
                    OrganizationalUnitView entity = new OrganizationalUnitView();
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    entity.Title = Convert.ToString(rdr["Title"]);
                    entity.Description = Convert.ToString(rdr["Description"]);
                    entity.OrganizationaUnitGroup = Convert.ToString(rdr["OrganizationaUnitGroup"]);

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

        public List<OrganizationalUnitView> ListWithAdvancedFilter(string title, int? parentOrgId, int? orgUnitGroup)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListOrganisationalUnitsWithAdvancedFilter", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", title);
                if (parentOrgId != null)
                {
                    cmd.Parameters.AddWithValue("@ParentOrganizationUnitId", parentOrgId);
                }
                if (orgUnitGroup != null)
                {
                    cmd.Parameters.AddWithValue("@OrganizationUnitGroupId", orgUnitGroup);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<OrganizationalUnitView> list = new List<OrganizationalUnitView>();

                while (rdr.Read())
                {
                    OrganizationalUnitView entity = new OrganizationalUnitView();
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.Description = Convert.ToString(rdr["Description"]);
                    entity.OrganizationaUnitGroup = Convert.ToString(rdr["OrganizationaUnitGroup"]);
                    entity.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    entity.Title = Convert.ToString(rdr["Title"]);

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
