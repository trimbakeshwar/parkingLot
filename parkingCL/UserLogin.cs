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

            //Email Id
            [Required(ErrorMessage = "Email Is Required")]
            [EmailAddress]
            [StringLength(50)]
            public string Email { get; set; }

            //Password
            [Required(ErrorMessage = "Password Is Required")]
            [DataType(DataType.Password)]
            [StringLength(50, MinimumLength = 6)]
            public string passWord { get; set; }
             
        }
    }
}
