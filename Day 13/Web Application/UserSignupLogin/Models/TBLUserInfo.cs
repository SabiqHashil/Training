//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserSignupLogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TBLUserInfo
    {
        public int IdUs { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Username")]
        public string UsernameUs { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        public string PasswordUs { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        [Compare("PasswordUs", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }

}
