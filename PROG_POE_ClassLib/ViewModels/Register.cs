using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROG_POE_ClassLib.ViewModels
{
    public class Register
    {
        [Key]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(PassWord), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassWord { get; set; }
    }
}
