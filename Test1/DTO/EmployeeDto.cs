using System.ComponentModel.DataAnnotations;

namespace Test1.DTO
{
    public class EmployeeDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [StringLength(50)]
        [Required]
        public string Address { get; set; }
    }

    public class EmployeeID: EmployeeDto
    {
        public string EmployeeId { get; set; }
    }
}
