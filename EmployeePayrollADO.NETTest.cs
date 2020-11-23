using EmployeePayrollADO.NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace EmployeePayrollADO.NETTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CompareEmployeePayrollObject_withDBObject()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            bool Basic_pay= employeeRepo.UpdateTables("update employee_payroll set Basic_Pay = 12345678.00 where Id=2");
            Assert.AreEqual(Basic_pay, true);
        }
    }
}
