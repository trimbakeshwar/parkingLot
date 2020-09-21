using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using parkingBL.Interface;
using parkingCL;
using static parkingCL.UserLogin;

namespace parkingLot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private BLInterface data;
        public UserController(BLInterface data)
        {
            this.data = data;
        }
        [HttpPost]
        public IActionResult Registration(RegistrationModel info)
        {
            if (!info.Equals(null))
            {
                RegistrationModel orignal = data.Registration(info);
                return Ok(new { success = true, Massage = "registration is successful", data = orignal });
            }
            else
            {
                return this.Ok(new { success = false, Message = "Registration Failed" });
            }

        }
        public IActionResult UserLogin(LoginModel user)
        {
            if (user!=null)
            {
                LoginModel orignal = data.userLogin(user);
                return Ok(new { success = true, Massage = "login is successful", data = orignal });

            }
            else
            {
                return Ok(new { success = true, Massage = "login fail" });
            }

          
        }
    }
}
