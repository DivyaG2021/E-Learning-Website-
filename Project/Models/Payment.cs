using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public enum Subscription
    {
        Basic, Standard, Premium
    }
    public class Payments
        {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please choose one subscription ")]
        public Subscription Subscription { get; set; }
        [MaxLength(16, ErrorMessage = "Card number should contain 16 digits"), MinLength(16, ErrorMessage = "Card number should contain 16 digits")]
        [Required(ErrorMessage = "Please enter your 16-digit card number")]
        public string CardNumber { get; set; }
        public int Amount { get; set; }

        [MaxLength(3, ErrorMessage = "Its only a 3 digit code"), MinLength(3, ErrorMessage = "Its only a 3 digit code")]
        [Required(ErrorMessage = "Please enter your CVV")]
        public string CVV { get; set; }
        [Required(ErrorMessage = "Please enter your expiration Date as MM/YY")]
        [MaxLength(5, ErrorMessage = "Invalid date")]
        [MinLength(5, ErrorMessage = "Invalid date")]
        public string ExpiryDate { get; set; }

    }
}
