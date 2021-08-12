using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public enum Gender
    {
        Male, Female, Others
    }
    public enum Qualification
    {
        School, College, UG, PG
    }
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name"), MaxLength(15), MinLength(3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression("^[a-zA-Z0-9 + _.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please enter a valid format")]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Please select the Qualification")]
        public Qualification Qualification { get; set; }
        [Required(ErrorMessage = "Please enter name"), MaxLength(15), MinLength(3)]
        public string Username { get; set; }
        [DataType(DataType.Password), Required]
        public string Password { get; set; }
        [DataType(DataType.Password), Required,MaxLength(8),MinLength(3)]
        public string ConfirmPassword { get; set; }
    }
}
