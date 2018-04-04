using EmpRestService.Entities;
using EmpRestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
namespace EmpRestService.Controllers
{
    [EnableCors("*","*","*","*")]
    public class EmployeeController : ApiController
    {
        [EnableCors("*", "*", "*", "*")]
        public List<Employee> GetAllEmployees()
        {
            var context = new inTimeDatabaseEntities();
            var data = context.EmpTables.Select(e => new Employee
            {
                EmpId = e.EmpID,
                EmpAddress = e.EmpAddress,
                EmpName = e.EmpName,
                EmpSalary = (double)e.EmpSalary,
                Dept = e.DeptTable.DeptName
            }).ToList();
            return data;
        }
        [EnableCors("*", "*", "*", "*")]
        public Employee GetEmployee(string id)
        {
            var context = new inTimeDatabaseEntities();
            var empId = int.Parse(id);
            var data = context.EmpTables.Where(e => e.EmpID == empId).Select(e => new Employee
            {
                EmpId = e.EmpID,
                EmpAddress = e.EmpAddress,
                EmpName = e.EmpName,
                EmpSalary = (double)e.EmpSalary,
                Dept = e.DeptTable.DeptName
            }).FirstOrDefault();
            return data;
        }

        [HttpPost]
        public bool AddNewEmployee(Employee emp)
        {
            var context = new inTimeDatabaseEntities();
            var dept = context.DeptTables.Where(d => d.DeptName == emp.Dept).FirstOrDefault();
            if (dept == null)
                throw new Exception("No dept exists, cannot add the Employee");
            var empRec = new EmpTable
            {
                EmpName = emp.EmpName,
                EmpAddress = emp.EmpAddress,
                EmpSalary = (decimal)emp.EmpSalary,
                DeptID = dept.DeptId
            };
            context.EmpTables.Add(empRec);
            context.SaveChanges();
            return true;
     }
        [EnableCors("*", "*", "*", "*")]
        [Route("api/Delete/{id}")]
        [HttpGet]
        public bool removeEmployee(string id)
        {
            var empid = int.Parse(id);
            var context = new inTimeDatabaseEntities();
            var rec = context.EmpTables.FirstOrDefault(e => e.EmpID == empid);
            if (rec == null)
                throw new Exception("Record not found to delete");
            context.EmpTables.Remove(rec);
            context.SaveChanges();
            return true;
        }
        [HttpPost]
        [EnableCors("*", "*", "*", "*")]
        [Route("api/Update")]
        public bool UpdateEmployee(Employee emp)
        {
            var context = new inTimeDatabaseEntities();
            var dept = context.DeptTables.Where(d => d.DeptName == emp.Dept).FirstOrDefault();
            if (dept == null)
                throw new Exception("No dept exists, cannot update the Employee");
            var rec = context.EmpTables.FirstOrDefault(e => e.EmpID == emp.EmpId);
            if (rec == null)
                throw new Exception("Record not found to update");
            rec.EmpName = emp.EmpName;
            rec.EmpSalary = (decimal)emp.EmpSalary;
            rec.EmpAddress = emp.EmpAddress;
            rec.DeptID = dept.DeptId;
            context.SaveChanges();
            return true;
        }
    }
}
