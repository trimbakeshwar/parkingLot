using Microsoft.Extensions.Configuration;
using parkingCL;
using parkingRL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using static parkingCL.UserLogin;

namespace parkingRL.services
{
    public class parkingLotRL : RLInterface
    {
        private readonly IConfiguration configuration;
        private SqlConnection con = null;
        string constr = null;
        public parkingLotRL(IConfiguration configuratio)
        {
            configuration = configuratio;
        }
        /// <summary>
        /// establish connection
        /// </summary>
        private void Connection()
        {
            try
            {
                //call the connection string
                constr = configuration.GetSection("ConnectionStrings").GetSection("EmployeeContext").Value;
                con = new SqlConnection(constr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public RegistrationModel Registration(RegistrationModel modle)
        {
            throw new NotImplementedException();
        }

        public LoginModel userLogin(LoginModel user)
        {
            throw new NotImplementedException();
        }

      
    }
}
