using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class ExperienceMapper : IGeneralMapper<ExperienceEntity, ExperienceEntity>
    {
        public void Insert(ExperienceEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertExperience", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", t.EmployeeId);
                cmd.Parameters.AddWithValue("@DateFrom", t.DateFrom);
                if (t.DateTo != null)
                {
                    cmd.Parameters.AddWithValue("@DateTo", t.DateTo);
                }
                cmd.Parameters.AddWithValue("@PositionHeld", t.PositionHeld);
                cmd.Parameters.AddWithValue("@EmployeeName", t.EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeContact", t.EmployeeContact);
                cmd.Parameters.AddWithValue("@BusinessType", t.BusinessType);


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

        public void Update(ExperienceEntity t)
        {
            throw new NotImplementedException();
        }

        public void Delete(ExperienceEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_DeleteExperienceById", conn);
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

        public ExperienceEntity Get(ExperienceEntity t)
        {
            throw new NotImplementedException();
        }

        public List<ExperienceEntity> List(string search)
        {
            List<ExperienceEntity> list = new List<ExperienceEntity>();


            //ExperienceEntity ent = new ExperienceEntity()
            //{
            //    DateFrom = DateTime.Now,
            //    DateTo = DateTime.Now,
            //    EmployeeName = "Inc. Corporation",
            //    EmployeeContact = "Germany, Stutgart",
            //    PositionHeld = "Network Engineer",
            //    BusinessType = "Networking"
            //};

            //ent = new ExperienceEntity()
            //{
            //    DateFrom = DateTime.Now,
            //    DateTo = DateTime.Now,
            //    EmployeeName = "Kosovo Property Agency",
            //    EmployeeContact = "Kosovo, Pristina",
            //    PositionHeld = "Senior Asistant Programmer",
            //    BusinessType = "Networking"
            //};

            //list.Add(ent);

            //ent = new ExperienceEntity()
            //{
            //    DateFrom = DateTime.Now,
            //    DateTo = DateTime.Now,
            //    EmployeeName = "Asseco SEE",
            //    EmployeeContact = "Kosovo, Pristina",
            //    PositionHeld = "Senior Software Developer",
            //    BusinessType = "Networking"
            //};

            //list.Add(ent);
            return list;
        }

        public List<ExperienceEntity> ListByEmployeeId(int employeeId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListExperiencesByEmployeeId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<ExperienceEntity> list = new List<ExperienceEntity>();

                while (rdr.Read())
                {
                    ExperienceEntity entity = new ExperienceEntity();
                    entity.Id = Convert.ToInt32(rdr["Id"]);
                    entity.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    entity.DateFrom = Convert.ToDateTime(rdr["DateFrom"]);
                    if (rdr["DateTo"] != DBNull.Value)
                    {
                        entity.DateTo = Convert.ToDateTime(rdr["DateTo"]);
                    }
                    entity.PositionHeld = Convert.ToString(rdr["PositionHeld"]);
                    entity.EmployeeName = Convert.ToString(rdr["EmployeeName"]);
                    entity.EmployeeContact = Convert.ToString(rdr["EmployeeContact"]);
                    entity.BusinessType = Convert.ToString(rdr["BusinessType"]);

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
