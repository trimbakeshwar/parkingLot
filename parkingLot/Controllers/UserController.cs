﻿using System;
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
        [HttpGet]
        [Route("login")]
        public IActionResult UserLogin(LoginModel user)
        {
            if (user!=null)
            {
                LoginModel orignal = data.userLogin(user);
              
                return Ok(new { status=true, massage="login successful" });

            }
            else
            {
                return Ok(new { success = false, Massage = "login fail" });
            }

          
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteUser(int id)
        {
          
                dynamic orignal = data.DeleteUser(id);
                bool status = orignal.Item1;
                string massage = orignal.Item2;
                return Ok(new { status, massage });
           
        }
        [HttpPatch]
        public IActionResult UpdateUserDetail(RegistrationModel Data)
        {
            dynamic orignal = data.UpdateUserDetail(Data);
            bool status = orignal.Item1;
            string massage = orignal.Item2;
            return Ok(new { status, massage });
        }
        [HttpGet]
        public IActionResult GetAllUserDetail()
        {
            dynamic orignal = data.GetAllUserDetail();
            bool status = orignal.Item1;
            string massage = orignal.Item2;
            dynamic result = orignal.Item3;
            return Ok(new { status, massage, result });
        }
        [HttpGet("{userId}")]

        public IActionResult GetUserDetail(int userId)
        {
            dynamic orignal = data.GetUserDetail(userId);
            bool status = orignal.Item1;
            string massage = orignal.Item2;
            dynamic result = orignal.Item3;
            return Ok(new { status, massage, result });
        }
    }
}
