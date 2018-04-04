namespace EmpRestService.Entities
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
        public string Dept { get; set; }
    }

    public class Dept
    {
        public int DeptId { get; set; }

        public string DeptName { get; set; }
    }
}