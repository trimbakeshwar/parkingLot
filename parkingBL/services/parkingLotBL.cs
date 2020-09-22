using parkingBL.Interface;
using parkingCL;
using parkingRL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using static parkingCL.UserLogin;

namespace parkingBL.services
{
    public class parkingLotBL : BLInterface
    {
        private RLInterface information;
        public parkingLotBL(RLInterface information)
        {
            this.information = information;
        }
        public RegistrationModel Registration(RegistrationModel data)
        {
            return this.information.Registration(data);
        }

        public LoginModel userLogin(LoginModel user)
        {
            return this.information.userLogin(user);
        }
        public dynamic DeleteUser(int id)
        {
            return this.information.DeleteUser(id);
        }

        public dynamic UpdateUserDetail(RegistrationModel Data)
        {
            return this.information.UpdateUserDetail(Data);
        }

        public dynamic GetAllUserDetail()
        {
            return this.information.GetAllUserDetail();
        }

        public dynamic GetUserDetail(int userId)
        {
            return this.information.GetUserDetail(userId);
        }
    }
}
