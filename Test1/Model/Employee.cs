using System.ComponentModel.DataAnnotations;

namespace Test1.Model
{
    public class Employee : Person
    {
        public string EmployeeId { get; set; }
        public string Address { get; set; }

    }
}
