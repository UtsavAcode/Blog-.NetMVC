namespace EmployeeMVC.Models.Domain
{
    public class Employee
    {
        public int Id { get; set; } 

        public string Name { get; set; }    

        public string Email { get; set; }

        public string Phone { get; set; }   

        public long Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Department { get; set; }


    }
}
