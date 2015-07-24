using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entities;

namespace DAL.Mapper.Transactions
{
    public class LinkEmployeeToUserBO
    {
        public void Link(UserEntity userEntity, int RoleId, string mail)
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
                    new UserMapper().Insert(userEntity, command);

                    command = connection.CreateCommand();
                    command.Transaction = sqlTran;
                    new RoleMapper().InsertUserForRole(userEntity, new RoleEntity() { Id = RoleId }, command);

                    command = connection.CreateCommand();
                    command.Transaction = sqlTran;
                    new EmployeeMapper().UpdateJobInformation(userEntity.EmployeeId, mail, "", null, command);

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
