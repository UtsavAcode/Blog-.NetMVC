namespace EmployeeMVC.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Customer(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
}
