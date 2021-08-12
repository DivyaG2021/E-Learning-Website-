using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public enum Rating
    {
        Excellent,Great,Good,Average,Poor
    }
    public enum Courses
    {
        HTML, CSS, JAVASCRIPT, JAVA, PYTHON, CSHARP
    }
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name"), MaxLength(15), MinLength(3)]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }
        public Courses Courses { get; set; }
        public string comments { get; set; }
        public Rating Rating { get; set; }
    }
}
