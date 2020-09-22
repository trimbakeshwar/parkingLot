using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace parkingCL
{
   public class RegistrationModel
    {
        [RegularExpression(@"^[A-Z][a-z]{2,}$", ErrorMessage = "Please enter a valid first Name")]
        public string firstName { get; set; }
        [RegularExpression(@"^[A-Z][a-z]{2,}$", ErrorMessage = "Please enter a valid last Name")]
        public string lastName { get; set; }
        public string Address { get; set; }
        public int userId { get; set; }
        [RegularExpression(@"^((.[A-Z]+[a-z]*[0-9]*)|(.[A-Z]*[a-z]+[0-9]*)|(.[A-Z]*[a-z]*[0-9]+)?)?@.co(.[a-z]{2,})?$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        
        [RegularExpression(@"^.*(?=.*[A-Z])*(?=.*[0-9])*(?=.*[a-z])*(?=.*[!@#$%^&*_+]{1})(.{8,})$", ErrorMessage = "Please enter a valid password")]
        public string passWord { get; set; }
        public string DriverCategory { get; set; }
    }
}
