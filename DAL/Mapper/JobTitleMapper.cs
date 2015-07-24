using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using Entities.Views;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class JobTitleMapper : IGeneralMapper<JobTitleEntity, JobTitleView>
    {
        public void Insert(JobTitleEntity t)
        {
            throw new NotImplementedException();
        }

        public void InsertWithParent(JobTitleEntity t, string ReportsTo)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertJobTitle", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobCode", t.JobCode);
                cmd.Parameters.AddWithValue("@Title", t.Title);
                cmd.Parameters.AddWithValue("@Description", t.Description);
                if (ReportsTo != null)
                {
                    cmd.Parameters.AddWithValue("@ReportsTo", ReportsTo);
                }
                cmd.Parameters.AddWithValue("@OrganizationalUnitId", t.OrganizationalUnitId);
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

        public void Update(JobTitleEntity t, string ReportsTo)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdateJobTitle", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobCode", t.JobCode);
                cmd.Parameters.AddWithValue("@Title", t.Title);
                cmd.Parameters.AddWithValue("@Description", t.Description);
                if (ReportsTo != "")
                {
                    cmd.Parameters.AddWithValue("@ReportsTo", ReportsTo);
                }

                cmd.Parameters.AddWithValue("@OrganizationalUnitId", t.OrganizationalUnitId);
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

        public void Update(JobTitleEntity t)
        {
            throw new NotImplementedException();
        }

        public void Delete(JobTitleEntity t)
        {
            throw new NotImplementedException();
        }

        public JobTitleView Get(JobTitleEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetJobTitle", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobCode", t.JobCode);

                SqlDataReader rdr = cmd.ExecuteReader();
                JobTitleView job = new JobTitleView();

                if (rdr.Read())
                {
                    job.Code = Convert.ToString(rdr["JobCode"]);
                    job.Description = Convert.ToString(rdr["Description"]);
                    job.OrganisationalUnit = Convert.ToString(rdr["OrganisationalUnit"]);
                    job.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    job.Title = Convert.ToString(rdr["Title"]);
                }

                return job;
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

        public JobTitleView GetParent(string jobCode)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetJobTitleParent", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobCode", jobCode);

                SqlDataReader rdr = cmd.ExecuteReader();
                JobTitleView job = new JobTitleView();

                if (rdr.Read())
                {
                    job.Code = Convert.ToString(rdr["JobCode"]);
                    job.Description = Convert.ToString(rdr["Description"]);
                    job.OrganisationalUnit = Convert.ToString(rdr["OrganisationalUnit"]);
                    job.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    job.Title = Convert.ToString(rdr["Title"]);
                }

                return job;
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

        public List<JobTitleView> List(string search)
        {
            throw new NotImplementedException();
        }

        public List<JobTitleView> ListByOrganisationalUnitId(int? organisationalUnitId, string search, StatusEnum status)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListJobTitlesByOrganisationalUnitId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (organisationalUnitId != null)
                {
                    cmd.Parameters.AddWithValue("@OrganisationalUnitId", organisationalUnitId);
                }
                if (search == null)
                {
                    cmd.Parameters.AddWithValue("@Search", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Search", search);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<JobTitleView> list = new List<JobTitleView>();

                while (rdr.Read())
                {
                    JobTitleView entity = new JobTitleView();
                    entity.Code = Convert.ToString(rdr["JobCode"]);
                    entity.Description = Convert.ToString(rdr["Description"]);
                    entity.OrganisationalUnit = Convert.ToString(rdr["OrganisationalUnit"]);
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
