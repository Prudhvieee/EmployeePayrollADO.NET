using System;

namespace EmployeePayrollADO.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to employee Payroll DB");
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.GetAllEmployee();
        }
    }
}
