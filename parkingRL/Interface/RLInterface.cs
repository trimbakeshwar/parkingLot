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
        dynamic DeleteUser(int id);
        dynamic UpdateUserDetail(RegistrationModel Data);
        dynamic GetAllUserDetail();
        dynamic GetUserDetail(int userId);
    }

}
