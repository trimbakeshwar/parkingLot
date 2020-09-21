using parkingCL;
using System;
using System.Collections.Generic;
using System.Text;
using static parkingCL.UserLogin;

namespace parkingRL.Interface
{
    public interface RLInterface
    {
        RegistrationModel Registration(RegistrationModel modle);
        LoginModel userLogin(LoginModel user );
    }

}
