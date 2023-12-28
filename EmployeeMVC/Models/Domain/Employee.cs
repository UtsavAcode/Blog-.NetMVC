namespace EmployeeMVC.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; } 

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public long Salary { get; set; }

       

        public string Department { get; set; } = null!;


    }
}
