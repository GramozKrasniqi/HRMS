using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class FormMapper : IGeneralMapper<FormEntity, FormEntity>
    {
        public void Insert(FormEntity t)
        {
            throw new NotImplementedException();
        }

        public void InsertFormForRole(FormEntity t, RoleEntity r, int ApplicationId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertFormForRole", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ApplicationId", ApplicationId);
                cmd.Parameters.AddWithValue("@RoleId", r.Id);
                cmd.Parameters.AddWithValue("@FormId", t.Id);

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

        public void Update(FormEntity t)
        {
            throw new NotImplementedException();
        }

        public void Delete(FormEntity t)
        {
            throw new NotImplementedException();
        }

        public FormEntity Get(FormEntity t)
        {
            throw new NotImplementedException();
        }

        public FormEntity GetFormByPath(string path)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetFromByPathSearch", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Path", path);

                SqlDataReader rdr = cmd.ExecuteReader();
                FormEntity view = new FormEntity();

                if (rdr.Read())
                {
                    view.Id = Convert.ToInt32(rdr["Id"]);
                    view.ApplicationId = Convert.ToInt32(rdr["ApplicationId"]);
                    view.Title = Convert.ToString(rdr["Title"]);
                    view.Path = Convert.ToString(rdr["Path"]);
                    view.IsNavVisible = Convert.ToBoolean(Convert.ToInt32(rdr["IsNavVisible"]));
                    if (rdr["ParentId"] != DBNull.Value)
                    {
                        view.ParentId = Convert.ToInt32(rdr["ParentId"]);
                    }
                    if (Convert.ToInt32(rdr["IsChecked"]) > 0)
                    {
                        view.IsChecked = true;
                    }
                    else
                    {
                        view.IsChecked = false;
                    }
                    view.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);

                }

                return view;
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

        public List<FormEntity> List(string search)
        {
            throw new NotImplementedException();
        }

        public List<FormEntity> ListWithAdvanced(string search, int? parentId, StatusEnum? status, bool? IsNavVisible, int? RoleId, int? IsWithChecked)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListFormsAdvancedFilter", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Search", search);
                if (parentId != null)
                {
                    cmd.Parameters.AddWithValue("@ParentId", parentId);
                }
                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }
                if (IsNavVisible != null)
                {
                    cmd.Parameters.AddWithValue("@IsNavVisible", IsNavVisible);
                }
                if (RoleId != null)
                {
                    cmd.Parameters.AddWithValue("@RoleId", RoleId);
                }
                if (IsWithChecked != null)
                {
                    cmd.Parameters.AddWithValue("@ReturnWithIsChecked", IsWithChecked);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<FormEntity> list = new List<FormEntity>();

                while (rdr.Read())
                {
                    FormEntity view = new FormEntity();
                    view.Id = Convert.ToInt32(rdr["Id"]);
                    view.ApplicationId = Convert.ToInt32(rdr["ApplicationId"]);
                    view.Title = Convert.ToString(rdr["Title"]);
                    view.Path = Convert.ToString(rdr["Path"]);
                    view.IsNavVisible = Convert.ToBoolean(Convert.ToInt32(rdr["IsNavVisible"]));
                    if (rdr["ParentId"] != DBNull.Value)
                    {
                        view.ParentId = Convert.ToInt32(rdr["ParentId"]);
                    }
                    if (Convert.ToInt32(rdr["IsChecked"]) > 0)
                    {
                        view.IsChecked = true;
                    }
                    else
                    {
                        view.IsChecked = false;
                    }
                    view.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);

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

        public void DeleteFormsFromRole(RoleEntity entity)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteFormsFromRole", conn);
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
