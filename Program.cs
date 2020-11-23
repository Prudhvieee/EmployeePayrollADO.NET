using System;

namespace EmployeePayrollADO.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to employee Payroll DB");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.GetEmployeeNameInParticularRange("SELECT * FROM Employee_Payroll where Start_Date between CAST('2018-04-21' AS DATE) AND CAST('2020-11-05' AS DATE)");
        }
    }
}
