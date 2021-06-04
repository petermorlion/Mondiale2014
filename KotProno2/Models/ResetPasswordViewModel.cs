using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KotProno2.Models
{
    public class ResetPasswordViewModel
    {
        public string UserId { get; set; }
        public string Code { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Je {0} moet ten minste {2} karakters lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nieuw paswoord")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bevestig nieuw paswoord")]
        [Compare("NewPassword", ErrorMessage = "Het nieuwe paswoord en de bevestiging komen niet overeen.")]
        public string ConfirmPassword { get; set; }
    }
}