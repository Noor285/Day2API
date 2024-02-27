using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day1.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student name is required.")]
        public string Name { get; set; }

        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60.")]
        public int Age { get; set; }

        [StringLength(100, ErrorMessage = "Address length must be between {2} and {1} characters.", MinimumLength = 5)]
        public string Address { get; set; }

        public string Image { get; set; }


    }
}
