using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace parkingCL
{
    public class UserLogin
    {
        public class LoginModel
        {
            [Required(ErrorMessage = "UserType Is Required")]
            public int UserId { get; set; }

            //User Type
            [Required(ErrorMessage = "UserType Is Required")]
            [MaxLength(50)]
            public string UserTypes { get; set; }

            //Email Id
            [Required(ErrorMessage = "Email Is Required")]
            [EmailAddress]
            [StringLength(50)]
            public string Email { get; set; }

            //Password
            [Required(ErrorMessage = "Password Is Required")]
            [DataType(DataType.Password)]
            [StringLength(50, MinimumLength = 6)]
            public string Password { get; set; }
        }
    }
}
