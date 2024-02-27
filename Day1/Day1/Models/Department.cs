using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Day1.Models
{
    public class Department
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Department name is required, Department name must be unique.")]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Manager { get; set; }

    }
}
