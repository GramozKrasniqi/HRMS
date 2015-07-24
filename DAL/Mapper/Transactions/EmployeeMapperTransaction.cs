using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL.Mapper.Transactions
{
    public class EmployeeMapperTransaction
    {
        public void InsertWithReminder(EmployeeEntity employeeEntity, ReminderEntity reminderEntity)
        {
            using (SqlConnection connection = DALHelper.CreateSqlDbConnection())
            {
                // Start a local transaction.
                SqlTransaction sqlTran = connection.BeginTransaction();

                // Enlist a command in the current transaction.

                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.Transaction = sqlTran;
                    new EmployeeMapper().Insert(employeeEntity, command);

                    command = connection.CreateCommand();
                    command.Transaction = sqlTran;

                    reminderEntity.EntityPK = employeeEntity.Id.ToString();

                    new ReminderMapper().Insert(reminderEntity, command);

                    // Commit the transaction.
                    sqlTran.Commit();
                }
                catch (Exception)
                {
                    // Handle the exception if the transaction fails to commit.

                    try
                    {
                        // Attempt to roll back the transaction.
                        sqlTran.Rollback();
                    }
                    catch (Exception)
                    {
                        // Throws an InvalidOperationException if the connection
                        // is closed or the transaction has already been rolled
                        // back on the server.
                    }
                }
            }
        }
    }
}
