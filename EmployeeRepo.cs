using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollADO.NET
{
    public class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PayrollService;Integrated Security=True";
        SqlConnection sqlconnection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.sqlconnection)
                {
                    string query = @"select * from employee_payroll";
                    SqlCommand command = new SqlCommand(query, this.sqlconnection);
                    this.sqlconnection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            employeeModel.id = dataReader.GetInt32(0);
                            employeeModel.Name = dataReader.GetString(1);
                            employeeModel.salary = dataReader.GetDecimal(2);
                            employeeModel.Start_Date = dataReader.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dataReader.GetString(4));
                            employeeModel.Employee_Address = dataReader.GetString(5);
                            employeeModel.Department = dataReader.GetString(6);
                            employeeModel.Phone_Number = dataReader.GetString(7);
                            employeeModel.Basic_Pay = dataReader.GetDecimal(8);
                            employeeModel.Deductions = dataReader.GetDecimal(9);
                            employeeModel.Taxable_Pay = dataReader.GetDecimal(10);
                            employeeModel.Income_Tax = dataReader.GetDecimal(11);
                            employeeModel.NetPay = dataReader.GetDecimal(12);
                            Console.WriteLine("\n");
                            Console.WriteLine(employeeModel.id + " " + employeeModel.Name + " " + employeeModel.salary + " " + employeeModel.Start_Date + " " +
                                employeeModel.Gender + " " + employeeModel.Employee_Address + " " + employeeModel.Department + " " + employeeModel.Phone_Number
                                + " " + employeeModel.Basic_Pay + " " + employeeModel.Deductions + " " + employeeModel.Taxable_Pay + " " + employeeModel.Income_Tax
                                + " " + employeeModel.NetPay);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dataReader.Close();
                    this.sqlconnection.Close();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (this.sqlconnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddEmployee", this.sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", employeeModel.id);
                    sqlCommand.Parameters.AddWithValue("@Name", employeeModel.Name);
                    sqlCommand.Parameters.AddWithValue("@salary", employeeModel.salary);
                    sqlCommand.Parameters.AddWithValue("@Start_Date", employeeModel.Start_Date);
                    sqlCommand.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    sqlCommand.Parameters.AddWithValue("@Employee_Address", employeeModel.Employee_Address);
                    sqlCommand.Parameters.AddWithValue("@Department", employeeModel.Department);
                    sqlCommand.Parameters.AddWithValue("@Phone_Number", employeeModel.Phone_Number);
                    sqlCommand.Parameters.AddWithValue("@Basic_Pay", employeeModel.Basic_Pay);
                    sqlCommand.Parameters.AddWithValue("@Deductions", employeeModel.Deductions);
                    sqlCommand.Parameters.AddWithValue("@Taxable_Pay", employeeModel.Taxable_Pay);
                    sqlCommand.Parameters.AddWithValue("@Income_Tax", employeeModel.Income_Tax);
                    sqlCommand.Parameters.AddWithValue("@NetPay", employeeModel.NetPay);
                    this.sqlconnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    this.sqlconnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
            return false;
        }
        public bool UpdateTables(string updateQuery)
        {
            using (this.sqlconnection)
            {
                try
                {
                    this.sqlconnection.Open();
                    SqlCommand command = this.sqlconnection.CreateCommand();
                    command.CommandText = updateQuery;
                    int updatedRows = command.ExecuteNonQuery();
                    if (updatedRows != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    this.sqlconnection.Close();
                }
            }
        }
        public List<string> GetEmployeeNameInParticularRange(string dateRangeQuery)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            List<string> data = new List<string>();
            try
            {
                using (this.sqlconnection)
                {
                    string query = dateRangeQuery;
                    SqlCommand command = new SqlCommand(query, sqlconnection);
                    this.sqlconnection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            employeeModel.id = dataReader.GetInt32(0);
                            employeeModel.Name = dataReader.GetString(1);
                            employeeModel.salary = dataReader.GetDecimal(2);
                            employeeModel.Start_Date = dataReader.GetDateTime(3);
                            employeeModel.Gender = Convert.ToChar(dataReader.GetString(4));
                            employeeModel.Employee_Address = dataReader.GetString(5);
                            employeeModel.Department = dataReader.GetString(6);
                            employeeModel.Phone_Number = dataReader.GetString(7);
                            employeeModel.Basic_Pay = dataReader.GetDecimal(8);
                            employeeModel.Deductions = dataReader.GetDecimal(9);
                            employeeModel.Taxable_Pay = dataReader.GetDecimal(10);
                            employeeModel.Income_Tax = dataReader.GetDecimal(11);
                            employeeModel.NetPay = dataReader.GetDecimal(12);
                            Console.WriteLine("\n");
                            data.Add(employeeModel.Name);
                            Console.WriteLine(employeeModel.Name);
                        }
                        dataReader.Close();
                        return data;
                    }
                    else
                    {
                        throw new Exception("No data found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
        public void SumOfSalaryGenderWise()
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (this.sqlconnection)
                {
                    string query = @"SELECT gender,sum(basic_pay) as CombineSalary from Employee_Payroll group by gender";
                    SqlCommand command = new SqlCommand(query, sqlconnection);
                    sqlconnection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine("SumOfSalaryGenderWise");
                            Console.Write(dataReader.GetString(0) + "\t"+ dataReader.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                        sqlconnection.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
        public void AverageOfSalaryGenderWise()
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (this.sqlconnection)
                {
                    string query = @"select gender, AVG(basic_pay) from Employee_Payroll group by gender";
                    SqlCommand command = new SqlCommand(query, sqlconnection);
                    sqlconnection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine("AverageOfSalaryGenderWise");
                            Console.Write(dataReader.GetString(0) + "\t"+ dataReader.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                        sqlconnection.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
        public void MinimumSalaryGenderWise()
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (this.sqlconnection)
                {
                    string query = @"select gender, MIN(basic_pay) from Employee_Payroll group by gender";
                    SqlCommand command = new SqlCommand(query, sqlconnection);
                    sqlconnection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine("Minimum salary gender wise");
                            Console.Write(dataReader.GetString(0) + "\t"+ dataReader.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                        sqlconnection.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
        public void MaximumSalaryGenderWise()
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (this.sqlconnection)
                {
                    string query = @"select gender, MAX(basic_pay) from Employee_Payroll group by gender";
                    SqlCommand command = new SqlCommand(query, sqlconnection);
                    sqlconnection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine("MaximumSalaryGenderWise");
                            Console.Write(dataReader.GetString(0) + "\t"+ dataReader.GetDecimal(1));
                            Console.WriteLine("\n");
                        }
                        sqlconnection.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
        public void CountOfEmployeesGenderWise()
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (this.sqlconnection)
                {
                    string query = @"select gender, COUNT(gender) from Employee_Payroll group by gender";
                    SqlCommand command = new SqlCommand(query, sqlconnection);
                    sqlconnection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Console.WriteLine("CountOfEmployeesGenderWise");
                            Console.Write(dataReader.GetString(0) + "\t"+ dataReader.GetInt32(1));
                            Console.WriteLine("\n");
                        }
                        sqlconnection.Close();
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
        public bool DeleteValue()
        {
            using (this.sqlconnection)
            {
                try
                {
                    this.sqlconnection.Open();
                    SqlCommand command = this.sqlconnection.CreateCommand();
                    command.CommandText = "delete from employee_payroll where id=3";
                    int deletedRows = command.ExecuteNonQuery();
                    if (deletedRows != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception exception)
                {

                    throw new Exception(exception.Message);
                }
                finally
                {
                    this.sqlconnection.Close();
                }
            }
        }
    }
}