using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using Entities.Views;
using System.Data.SqlClient;

namespace DAL.Mapper
{
    public class EmployeeMapper
    {
        public void Insert(EmployeeEntity t,SqlCommand transactionCMD)
        {
            if (transactionCMD != null)
            {
                transactionCMD.CommandText = "usp_InsertEmployee";
                transactionCMD.CommandType = System.Data.CommandType.StoredProcedure;

                transactionCMD.Parameters.AddWithValue("@EmployeeNo", t.EmployeeNo);
                transactionCMD.Parameters.AddWithValue("@Firstname", t.Firstname);
                transactionCMD.Parameters.AddWithValue("@Middlename", t.Middlename);
                transactionCMD.Parameters.AddWithValue("@Lastname", t.Lastname);
                transactionCMD.Parameters.AddWithValue("@DateOfBirth", t.DateOfBirth);
                transactionCMD.Parameters.AddWithValue("@NationalityId", t.NationalityId);
                transactionCMD.Parameters.AddWithValue("@Gender", t.Gender);
                transactionCMD.Parameters.AddWithValue("@PersonalNumber", t.PersonalNumber);
                transactionCMD.Parameters.AddWithValue("@Address", t.Address);
                transactionCMD.Parameters.AddWithValue("@CountryId", t.CountryId);
                transactionCMD.Parameters.AddWithValue("@City", t.City);
                transactionCMD.Parameters.AddWithValue("@MobilePhone", t.MobilePhone);
                transactionCMD.Parameters.AddWithValue("@WorkEmail", t.WorkEmail);
                transactionCMD.Parameters.AddWithValue("@OtherEmail", t.OtherEmail);
                transactionCMD.Parameters.AddWithValue("@BankId", t.BankId);
                transactionCMD.Parameters.AddWithValue("@AccountNumber", t.AccountNumber);
                transactionCMD.Parameters.AddWithValue("@MaritalStatus", t.MaritalStatus);
                transactionCMD.Parameters.AddWithValue("@Image", t.Image);

                t.Id = (int)transactionCMD.ExecuteScalar();
            }
            else
            {

                SqlConnection conn = null;
                SqlCommand cmd = null;

                try
                {
                    conn = DALHelper.CreateSqlDbConnection();
                    cmd = new SqlCommand("usp_InsertEmployee", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeNo", t.EmployeeNo);
                    cmd.Parameters.AddWithValue("@Firstname", t.Firstname);
                    cmd.Parameters.AddWithValue("@Middlename", t.Middlename);
                    cmd.Parameters.AddWithValue("@Lastname", t.Lastname);
                    cmd.Parameters.AddWithValue("@DateOfBirth", t.DateOfBirth);
                    cmd.Parameters.AddWithValue("@NationalityId", t.NationalityId);
                    cmd.Parameters.AddWithValue("@Gender", t.Gender);
                    cmd.Parameters.AddWithValue("@PersonalNumber", t.PersonalNumber);
                    cmd.Parameters.AddWithValue("@Address", t.Address);
                    cmd.Parameters.AddWithValue("@CountryId", t.CountryId);
                    cmd.Parameters.AddWithValue("@City", t.City);
                    cmd.Parameters.AddWithValue("@MobilePhone", t.MobilePhone);
                    cmd.Parameters.AddWithValue("@WorkEmail", t.WorkEmail);
                    cmd.Parameters.AddWithValue("@OtherEmail", t.OtherEmail);
                    cmd.Parameters.AddWithValue("@BankId", t.BankId);
                    cmd.Parameters.AddWithValue("@AccountNumber", t.AccountNumber);
                    cmd.Parameters.AddWithValue("@MaritalStatus", t.MaritalStatus);
                    if(t.Image != null)
                    {
                        cmd.Parameters.AddWithValue("@Image", t.Image);
                    }

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
        }

        public void Update(EmployeeEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_UpdateEmployee", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);
                cmd.Parameters.AddWithValue("@EmployeeNo", t.EmployeeNo);
                cmd.Parameters.AddWithValue("@Firstname", t.Firstname);
                cmd.Parameters.AddWithValue("@Middlename", t.Middlename);
                cmd.Parameters.AddWithValue("@Lastname", t.Lastname);
                cmd.Parameters.AddWithValue("@DateOfBirth", t.DateOfBirth);
                cmd.Parameters.AddWithValue("@NationalityId", t.NationalityId);
                cmd.Parameters.AddWithValue("@Gender", t.Gender);
                cmd.Parameters.AddWithValue("@PersonalNumber", t.PersonalNumber);
                cmd.Parameters.AddWithValue("@Address", t.Address);
                cmd.Parameters.AddWithValue("@CountryId", t.CountryId);
                cmd.Parameters.AddWithValue("@City", t.City);
                cmd.Parameters.AddWithValue("@MobilePhone", t.MobilePhone);
                cmd.Parameters.AddWithValue("@WorkEmail", t.WorkEmail);
                cmd.Parameters.AddWithValue("@OtherEmail", t.OtherEmail);
                cmd.Parameters.AddWithValue("@BankId", t.BankId);
                cmd.Parameters.AddWithValue("@AccountNumber", t.AccountNumber);
                cmd.Parameters.AddWithValue("@MaritalStatus", t.MaritalStatus);
                if (t.Image != null)
                {
                    cmd.Parameters.AddWithValue("@Image", t.Image);
                }

                cmd.ExecuteScalar();
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

        public void UpdateJobInformation(int empId, string workMail, string jobCode, int? orgaunitId, SqlCommand transactionCMD)
        {
            if (transactionCMD != null)
            {
                transactionCMD.CommandText = "usp_UpdateEmployeeJobInfo";
                transactionCMD.CommandType = System.Data.CommandType.StoredProcedure;

                transactionCMD.Parameters.AddWithValue("@EmployeeId", empId);
                if (workMail != "")
                {
                    transactionCMD.Parameters.AddWithValue("@WorkEmail", workMail);
                }
                if (jobCode != "")
                {
                    transactionCMD.Parameters.AddWithValue("@JobCode", jobCode);
                }
                if (orgaunitId != null)
                {
                    transactionCMD.Parameters.AddWithValue("@OrganizationalUnitId", orgaunitId);
                }

                transactionCMD.ExecuteNonQuery();
            }
            else
            {
                SqlConnection conn = null;
                SqlCommand cmd = null;

                try
                {
                    conn = DALHelper.CreateSqlDbConnection();
                    cmd = new SqlCommand("usp_UpdateEmployeeJobInfo", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", empId);
                    if (workMail != "")
                    {
                        cmd.Parameters.AddWithValue("@WorkEmail", workMail);
                    }
                    if (jobCode != "")
                    {
                        cmd.Parameters.AddWithValue("@JobCode", jobCode);
                    }
                    if (orgaunitId != null)
                    {
                        cmd.Parameters.AddWithValue("@OrganizationalUnitId", orgaunitId);
                    }

                    cmd.ExecuteScalar();
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

        public void Delete(EmployeeEntity t)
        {
            throw new NotImplementedException();
        }

        public EmployeeView Get(EmployeeEntity t)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetEmployeeById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", t.Id);

                SqlDataReader rdr = cmd.ExecuteReader();
                EmployeeView content = new EmployeeView();

                if (rdr.Read())
                {
                    content.Id = Convert.ToInt32(rdr["Id"]);
                    content.EmployeeNo = Convert.ToString(rdr["EmployeeNo"]);
                    content.Firstname = Convert.ToString(rdr["Firstname"]);
                    content.Middlename = Convert.ToString(rdr["Middlename"]);
                    content.Lastname = Convert.ToString(rdr["Lastname"]);
                    content.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                    content.Nationality = Convert.ToString(rdr["Nationality"]);
                    content.Gender = (GenderEnum)Convert.ToInt32(rdr["Gender"]);
                    content.PersonalNumber = Convert.ToString(rdr["PersonalNumber"]);
                    content.Address = Convert.ToString(rdr["Address"]);
                    content.Country = Convert.ToString(rdr["Country"]);
                    content.City = Convert.ToString(rdr["City"]);
                    content.MobilePhone = Convert.ToString(rdr["MobilePhone"]);
                    content.WorkEmail = Convert.ToString(rdr["WorkEmail"]);
                    content.OtherEmail = Convert.ToString(rdr["OtherEmail"]);
                    content.Bank = Convert.ToString(rdr["Bank"]);
                    content.AccountNumber = Convert.ToString(rdr["AccountNumber"]);
                    content.Job = Convert.ToString(rdr["Job"]);
                    content.OrganizationalUnit = Convert.ToString(rdr["OrganizationalUnit"]);
                    content.MaritalStatus = (MaritalStatusEnum)Convert.ToInt32(rdr["MaritalStatus"]);
                    if (rdr["Image"] != DBNull.Value)
                    {
                        content.Image = (byte[])rdr["Image"];
                    }

                    content.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                }

                return content;
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

        public EmployeeView Get(string employeeNo)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GetEmployeeByEmployeeNo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeNo", employeeNo);

                SqlDataReader rdr = cmd.ExecuteReader();
                EmployeeView content = new EmployeeView();

                if (rdr.Read())
                {
                    content.Id = Convert.ToInt32(rdr["Id"]);
                    content.EmployeeNo = Convert.ToString(rdr["EmployeeNo"]);
                    content.Firstname = Convert.ToString(rdr["Firstname"]);
                    content.Middlename = Convert.ToString(rdr["Middlename"]);
                    content.Lastname = Convert.ToString(rdr["Lastname"]);
                    content.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                    content.Nationality = Convert.ToString(rdr["Nationality"]);
                    content.Gender = (GenderEnum)Convert.ToInt32(rdr["Gender"]);
                    content.PersonalNumber = Convert.ToString(rdr["PersonalNumber"]);
                    content.Address = Convert.ToString(rdr["Address"]);
                    content.Country = Convert.ToString(rdr["Country"]);
                    content.City = Convert.ToString(rdr["City"]);
                    content.MobilePhone = Convert.ToString(rdr["MobilePhone"]);
                    content.WorkEmail = Convert.ToString(rdr["WorkEmail"]);
                    content.OtherEmail = Convert.ToString(rdr["OtherEmail"]);
                    content.Bank = Convert.ToString(rdr["Bank"]);
                    content.AccountNumber = Convert.ToString(rdr["AccountNumber"]);
                    content.Job = Convert.ToString(rdr["Job"]);
                    content.OrganizationalUnit = Convert.ToString(rdr["OrganizationalUnit"]);
                    content.MaritalStatus = (MaritalStatusEnum)Convert.ToInt32(rdr["MaritalStatus"]);
                    if (rdr["Image"] != DBNull.Value)
                    {
                        content.Image = (byte[])rdr["Image"];
                    }

                    content.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                }

                return content;
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

        public List<EmployeeView> List(string search)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeView> ListWithAdvancedFilter(string employeeNo, string searchName, string personalNumber, int? organizationalUnitId, string jobCode, StatusEnum? status)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListEmployees", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (employeeNo != "")
                {
                    cmd.Parameters.AddWithValue("@EmployeeNo", employeeNo);
                }
                cmd.Parameters.AddWithValue("@SearchName", searchName);
                if (personalNumber != "")
                {
                    cmd.Parameters.AddWithValue("@PersonalNumber", personalNumber);
                }
                if (jobCode != "")
                {
                    cmd.Parameters.AddWithValue("@JobCode", jobCode);
                }
                if (organizationalUnitId != null)
                {
                    cmd.Parameters.AddWithValue("@OrganizationalUnitId", organizationalUnitId);
                }
                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<EmployeeView> list = new List<EmployeeView>();

                while (rdr.Read())
                {
                    EmployeeView view = new EmployeeView();
                    view.Id = Convert.ToInt32(rdr["Id"]);
                    view.EmployeeNo = Convert.ToString(rdr["EmployeeNo"]);
                    view.Firstname = Convert.ToString(rdr["Firstname"]);
                    view.Middlename = Convert.ToString(rdr["Middlename"]);
                    view.Lastname = Convert.ToString(rdr["Lastname"]);
                    view.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                    view.Nationality = Convert.ToString(rdr["Nationality"]);
                    view.Gender = (GenderEnum)Convert.ToInt32(rdr["Gender"]);
                    view.PersonalNumber = Convert.ToString(rdr["PersonalNumber"]);
                    view.Address = Convert.ToString(rdr["Address"]);
                    view.Country = Convert.ToString(rdr["Country"]);
                    view.City = Convert.ToString(rdr["City"]);
                    view.MobilePhone = Convert.ToString(rdr["MobilePhone"]);
                    view.WorkEmail = Convert.ToString(rdr["WorkEmail"]);
                    view.OtherEmail = Convert.ToString(rdr["OtherEmail"]);
                    view.Bank = Convert.ToString(rdr["Bank"]);
                    view.AccountNumber = Convert.ToString(rdr["AccountNumber"]);
                    view.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    view.MaritalStatus = (MaritalStatusEnum)Convert.ToInt32(rdr["MaritalStatus"]);

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

        public List<EmployeeView> ListWithAdvancedFilterWithoutContract(string employeeNo, string searchName, string personalNumber, int? organizationalUnitId, string jobCode, StatusEnum? status)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListEmployeesWithoutContract", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (employeeNo != "")
                {
                    cmd.Parameters.AddWithValue("@EmployeeNo", employeeNo);
                }
                cmd.Parameters.AddWithValue("@SearchName", searchName);
                if (personalNumber != "")
                {
                    cmd.Parameters.AddWithValue("@PersonalNumber", personalNumber);
                }
                if (jobCode != "")
                {
                    cmd.Parameters.AddWithValue("@JobCode", jobCode);
                }
                if (organizationalUnitId != null)
                {
                    cmd.Parameters.AddWithValue("@OrganizationalUnitId", organizationalUnitId);
                }
                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<EmployeeView> list = new List<EmployeeView>();

                while (rdr.Read())
                {
                    EmployeeView view = new EmployeeView();
                    view.Id = Convert.ToInt32(rdr["Id"]);
                    view.EmployeeNo = Convert.ToString(rdr["EmployeeNo"]);
                    view.Firstname = Convert.ToString(rdr["Firstname"]);
                    view.Middlename = Convert.ToString(rdr["Middlename"]);
                    view.Lastname = Convert.ToString(rdr["Lastname"]);
                    view.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                    view.Nationality = Convert.ToString(rdr["Nationality"]);
                    view.Gender = (GenderEnum)Convert.ToInt32(rdr["Gender"]);
                    view.PersonalNumber = Convert.ToString(rdr["PersonalNumber"]);
                    view.Address = Convert.ToString(rdr["Address"]);
                    view.Country = Convert.ToString(rdr["Country"]);
                    view.City = Convert.ToString(rdr["City"]);
                    view.MobilePhone = Convert.ToString(rdr["MobilePhone"]);
                    view.WorkEmail = Convert.ToString(rdr["WorkEmail"]);
                    view.OtherEmail = Convert.ToString(rdr["OtherEmail"]);
                    view.Bank = Convert.ToString(rdr["Bank"]);
                    view.AccountNumber = Convert.ToString(rdr["AccountNumber"]);
                    view.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    view.MaritalStatus = (MaritalStatusEnum)Convert.ToInt32(rdr["MaritalStatus"]);

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

        public List<EmployeeView> ListEmployeesWithoutUsername(StatusEnum? status)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListEmployeeWithoutUsername", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<EmployeeView> list = new List<EmployeeView>();

                while (rdr.Read())
                {
                    EmployeeView view = new EmployeeView();
                    view.Id = Convert.ToInt32(rdr["Id"]);
                    view.EmployeeNo = Convert.ToString(rdr["EmployeeNo"]);
                    view.Firstname = Convert.ToString(rdr["Firstname"]);
                    view.Middlename = Convert.ToString(rdr["Middlename"]);
                    view.Lastname = Convert.ToString(rdr["Lastname"]);
                    view.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                    view.Nationality = Convert.ToString(rdr["Nationality"]);
                    view.Gender = (GenderEnum)Convert.ToInt32(rdr["Gender"]);
                    view.PersonalNumber = Convert.ToString(rdr["PersonalNumber"]);
                    view.Address = Convert.ToString(rdr["Address"]);
                    view.Country = Convert.ToString(rdr["Country"]);
                    view.City = Convert.ToString(rdr["City"]);
                    view.MobilePhone = Convert.ToString(rdr["MobilePhone"]);
                    view.WorkEmail = Convert.ToString(rdr["WorkEmail"]);
                    view.OtherEmail = Convert.ToString(rdr["OtherEmail"]);
                    view.Bank = Convert.ToString(rdr["Bank"]);
                    view.AccountNumber = Convert.ToString(rdr["AccountNumber"]);
                    view.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    view.MaritalStatus = (MaritalStatusEnum)Convert.ToInt32(rdr["MaritalStatus"]);

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

        public List<EmployeeView> ListWithAdvancedFilterByContractPreffix(string employeeNo, string searchName, string personalNumber, int? organizationalUnitId, string jobCode, StatusEnum? status, int? contractTemplateId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_ListEmployeesByContractPreffix", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (employeeNo != "")
                {
                    cmd.Parameters.AddWithValue("@EmployeeNo", employeeNo);
                }
                cmd.Parameters.AddWithValue("@SearchName", searchName);
                if (personalNumber != "")
                {
                    cmd.Parameters.AddWithValue("@PersonalNumber", personalNumber);
                }
                if (jobCode != "")
                {
                    cmd.Parameters.AddWithValue("@JobCode", jobCode);
                }
                if (contractTemplateId != null)
                {
                    cmd.Parameters.AddWithValue("@ContractTemplateId", contractTemplateId);
                }
                if (organizationalUnitId != null)
                {
                    cmd.Parameters.AddWithValue("@OrganizationalUnitId", organizationalUnitId);
                }
                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                SqlDataReader rdr = cmd.ExecuteReader();
                List<EmployeeView> list = new List<EmployeeView>();

                while (rdr.Read())
                {
                    EmployeeView view = new EmployeeView();
                    view.Id = Convert.ToInt32(rdr["Id"]);
                    view.EmployeeNo = Convert.ToString(rdr["EmployeeNo"]);
                    view.Firstname = Convert.ToString(rdr["Firstname"]);
                    view.Middlename = Convert.ToString(rdr["Middlename"]);
                    view.Lastname = Convert.ToString(rdr["Lastname"]);
                    view.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                    view.Nationality = Convert.ToString(rdr["Nationality"]);
                    view.Gender = (GenderEnum)Convert.ToInt32(rdr["Gender"]);
                    view.PersonalNumber = Convert.ToString(rdr["PersonalNumber"]);
                    view.Address = Convert.ToString(rdr["Address"]);
                    view.Country = Convert.ToString(rdr["Country"]);
                    view.City = Convert.ToString(rdr["City"]);
                    view.MobilePhone = Convert.ToString(rdr["MobilePhone"]);
                    view.WorkEmail = Convert.ToString(rdr["WorkEmail"]);
                    view.OtherEmail = Convert.ToString(rdr["OtherEmail"]);
                    view.Bank = Convert.ToString(rdr["Bank"]);
                    view.AccountNumber = Convert.ToString(rdr["AccountNumber"]);
                    view.Status = (StatusEnum)Convert.ToInt32(rdr["Status"]);
                    view.MaritalStatus = (MaritalStatusEnum)Convert.ToInt32(rdr["MaritalStatus"]);

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



        public string GenerateEmployeeNo(string oldPreffix, string newPreffix)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = DALHelper.CreateSqlDbConnection();
                cmd = new SqlCommand("usp_GenerateNewEmployeeNo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                string number = Convert.ToString(cmd.ExecuteScalar());
                if (number != "")
                {
                    number = number.Replace(oldPreffix, "");
                    Int64 realNum = Convert.ToInt64(number);
                    realNum++;
                    number = newPreffix + realNum.ToString();
                }
                else
                {
                    number = newPreffix + 1;
                }
                
                return number;
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
