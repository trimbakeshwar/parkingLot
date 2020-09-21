using parkingCL;
using System;
using System.Collections.Generic;
using System.Text;
using static parkingCL.UserLogin;

namespace parkingBL.Interface
{
    public interface BLInterface
    {
        RegistrationModel Registration(RegistrationModel modle);
        LoginModel userLogin(LoginModel user);
    }
}
