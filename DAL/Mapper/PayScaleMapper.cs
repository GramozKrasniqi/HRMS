using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class PayScaleMapper
    {
        public void Insert(PayScaleEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertPayScale", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractTemplateId", t.ContractTemplateId);
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

        public void UpdateGrade(PayScaleGradeItemEntity t, int contractTemplateId, string jobCode)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdatePayScaleGradeItem", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractTemplateId", contractTemplateId);
                cmd.Parameters.AddWithValue("@JobCode", jobCode);
                cmd.Parameters.AddWithValue("@GradeId", t.GradeId);
                cmd.Parameters.AddWithValue("@GradeEntry", t.GradeEntry);
                cmd.Parameters.AddWithValue("@GradeKCB", t.GradeKCB);
                
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

        public void UpdateStep(PayScaleStepItemEntity t, int contractTemplateId, string jobCode, string gradeId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdatePayScaleStepItem", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractTemplateId", contractTemplateId);
                cmd.Parameters.AddWithValue("@JobCode", jobCode);
                cmd.Parameters.AddWithValue("@GradeId", gradeId);
                cmd.Parameters.AddWithValue("@StepId", t.StepId);
                cmd.Parameters.AddWithValue("@StepEntry", t.StepEntry);

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

        public List<PayScaleGradeItemEntity> ListGradesFromPayScale(int contractTemplateId, string jobCode)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListGradesByContractTemplateIdAndJobCodeFromPayScale", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractTemplateId", contractTemplateId);
                cmd.Parameters.AddWithValue("@JobCode", jobCode);


                SqlDataReader rdr = cmd.ExecuteReader();
                List<PayScaleGradeItemEntity> list = new List<PayScaleGradeItemEntity>();

                while (rdr.Read())
                {
                    PayScaleGradeItemEntity view = new PayScaleGradeItemEntity();
                    view.GradeId = Convert.ToString(rdr["GradeId"]);
                    view.GradeEntry = Convert.ToDouble(rdr["GradeEntry"]);
                    view.GradeKCB = Convert.ToDouble(rdr["GradeKCB"]);

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

        public List<PayScaleStepItemEntity> ListStepsFromPayScale(int contractTemplateId, string jobCode, string gradeId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListStepsByContractTemplateIdAndJobCodeAndGradeFromPayScale", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContractTemplateId", contractTemplateId);
                cmd.Parameters.AddWithValue("@JobCode", jobCode);
                cmd.Parameters.AddWithValue("@GradeId", gradeId);

                SqlDataReader rdr = cmd.ExecuteReader();
                List<PayScaleStepItemEntity> list = new List<PayScaleStepItemEntity>();

                while (rdr.Read())
                {
                    PayScaleStepItemEntity view = new PayScaleStepItemEntity();
                    view.StepId = Convert.ToString(rdr["StepId"]);
                    view.StepEntry = Convert.ToDouble(rdr["StepEntry"]);

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
    }
}
