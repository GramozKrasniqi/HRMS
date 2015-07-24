using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class PayScaleItemMapper
    {
        public void Insert(PayScaleItemEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_InsertPayScaleItem", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@JobCode", t.JobCode);
                cmd.Parameters.AddWithValue("@ContractTemplateId", t.ContractTemplateId);
                cmd.Parameters.AddWithValue("@GradeId", t.GradeId);
                cmd.Parameters.AddWithValue("@GradeKCB", t.GradeKCB);
                cmd.Parameters.AddWithValue("@GradeEntry", t.GradeEntry);
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
    }
}
