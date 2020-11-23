using System;

namespace EmployeePayrollADO.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to employee Payroll DB");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            Console.WriteLine(employeeRepo.UpdateTables("update employee_payroll set Basic_Pay = 12345678.00 where Id=2"));
        }
    }
}
