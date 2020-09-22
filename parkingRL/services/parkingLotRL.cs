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
                SqlCommand command = new SqlCommand("[spUserRegisters]", con);
                //string encrypted = EncryptPassword(data.passWord);
                command.CommandType = CommandType.StoredProcedure;
                //send parameter to stored procedure
                command.Parameters.AddWithValue("@firstName", data.firstName);
                command.Parameters.AddWithValue("@lastName", data.lastName);
                command.Parameters.AddWithValue("@Address", data.Address);
                command.Parameters.AddWithValue("@Email", data.Email);
                command.Parameters.AddWithValue("@passWord", data.passWord);
                command.Parameters.AddWithValue("@DriverCategory", data.DriverCategory);
               
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
        public dynamic DeleteUser(int id)
        {
            try
            {
                Connection();
                //creat instance of store procedure
                SqlCommand command = new SqlCommand("spUserDeleteRegistration", con);
                command.CommandType = CommandType.StoredProcedure;
                //send parameter to store procedure
                command.Parameters.AddWithValue("@userId", id);
                //open connection EmployeeTable
                con.Open();
                //this qury return 1 after succesfuly run 0 for fail
                int i = command.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return (true, "delete successful");
                }
                else
                {
                    return (false, "delete fail");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        public dynamic Delete(int id)
        {
            try
            {
                Connection();
                //creat instance of store procedure
                SqlCommand command = new SqlCommand("spUserDeleteRegistration", con);
                command.CommandType = CommandType.StoredProcedure;
                //send parameter to store procedure
                command.Parameters.AddWithValue("@userId", id);
                //open connection EmployeeTable
                con.Open();
                //this qury return 1 after succesfuly run 0 for fail
                int i = command.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return (true, "delete successful");
                }
                else
                {
                    return (false, "delete fail");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// update employee detail
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public dynamic UpdateUserDetail(RegistrationModel data)
        {
            try
            {
                Connection();
                //creat instance of store procedure
                SqlCommand command = new SqlCommand("spUserUpdateRegistration", con);
                command.CommandType = CommandType.StoredProcedure;
                //send parameter to store procedure
                command.Parameters.AddWithValue("@firstName", data.firstName);
                command.Parameters.AddWithValue("@lastName", data.lastName);
                command.Parameters.AddWithValue("@Address", data.Address);
                command.Parameters.AddWithValue("@Email", data.Email);
                command.Parameters.AddWithValue("@passWord", data.passWord);
                command.Parameters.AddWithValue("@userId", data.userId);
                command.Parameters.AddWithValue("@DriverCategory", data.DriverCategory);
                //open connection EmployeeTable
                con.Open();
                //this qury return 0 after succesfuly run 1 for fail
                int i = command.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return (true, "update successful");
                }
                else
                {
                    return (true, "update fail");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// get all employee
        /// </summary>
        /// <returns>list of employee</returns>
        public dynamic GetAllUserDetail()
        {
            Connection();
            //creat instance of store procedure
            SqlCommand command = new SqlCommand("AllEmployeeDetails", con);
            command.CommandType = CommandType.StoredProcedure;
            //call get data method
            return GetData(command);
        }
        public dynamic GetUserDetail(int uid)
        {
            Connection();
            //creat instance of store procedure
            SqlCommand command = new SqlCommand("EmployeeDetails", con);
            command.CommandType = CommandType.StoredProcedure;
            //send parameter to store procedure
            command.Parameters.AddWithValue("@userId", uid);
            //call get method
            return GetData(command);

        }
        public dynamic GetData(SqlCommand command)
        {
            // command.CommandType = CommandType.StoredProcedure;
            List<RegistrationModel> list = new List<RegistrationModel>();
            //open connection EmployeeTable
            con.Open();
            //data from databse return in reder
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var RegistrationModel = new RegistrationModel
                {
                    //get oridinal is return the name of column on the basis of case insensative
                    //getstring retun the data in sting or particular type 
                    firstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    lastName = reader.GetString(reader.GetOrdinal("LastName")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    userId = reader.GetInt32(reader.GetOrdinal("ID")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    DriverCategory = reader.GetString(reader.GetOrdinal("DriverCategory")),

                };
                list.Add(RegistrationModel);
            }
            con.Close();
            return (true, "successful", list);
        }
    }
}
