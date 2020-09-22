using Microsoft.Extensions.Configuration;
using parkingCL;
using parkingRL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
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
        public RegistrationModel Registration(RegistrationModel data)
        {
            try
            {
                //get connection
                Connection();
                //create instance of store procedure
                SqlCommand command = new SqlCommand("[spUserRegister]", con);
                //string encrypted = EncryptPassword(data.passWord);
                command.CommandType = CommandType.StoredProcedure;
                //send parameter to stored procedure
                command.Parameters.AddWithValue("@firstName", data.firstName);
                command.Parameters.AddWithValue("@lastName", data.lastName);
                command.Parameters.AddWithValue("@Address", data.Address);
                command.Parameters.AddWithValue("@userId", data.userId);
                command.Parameters.AddWithValue("@Email", data.Email);
                command.Parameters.AddWithValue("@userName", data.userName);
                command.Parameters.AddWithValue("@passWord", data.passWord);
                //open connection EmployeeTable
                con.Open();
                //this qury return 0 after succesfuly run 1 for fail
                int i = command.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return data;
                }
                else
                { 
                    return data;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public LoginModel userLogin(LoginModel user)
        {
            try
            {
                //establish connection
                Connection();
                //create a object of store procedure
                SqlCommand command = new SqlCommand("spUserLogin", con);
                command.CommandType = CommandType.StoredProcedure;
                //send parameter to store prrocedure
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@passWord", user.passWord);
               

                //open connection EmployeeTable
                con.Open();
                //this qury return 0 after succesfuly run 1 for fail
                SqlDataReader reader =  command.ExecuteReader();
                int Status = 0;
                while (reader.Read())
                {
                    Status = reader.GetInt32(0);
                }
                //close connection
                con.Close();
                return user;
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

      
    }
}
