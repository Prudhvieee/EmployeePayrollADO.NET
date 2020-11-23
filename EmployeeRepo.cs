using System;
using System.Collections.Generic;
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
                                employeeModel.Gender+" "+employeeModel.Employee_Address+" "+employeeModel.Department+" "+employeeModel.Phone_Number
                                +" "+employeeModel.Basic_Pay+" "+employeeModel.Deductions+ " " +employeeModel.Taxable_Pay+" "+employeeModel.Income_Tax
                                +" "+employeeModel.NetPay);
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
    }
}
