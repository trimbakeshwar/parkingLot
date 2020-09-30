using Microsoft.Extensions.Configuration;
using parkingCL;
using parkingRL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace parkingRL.services
{
    public class ParkingRL : IparkingRL
    {
        private readonly IConfiguration configuration;
        private SqlConnection con = null;
        string constr = null;
        public ParkingRL(IConfiguration configuratio)
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
        public List<parkingDetails> GetAllParkingCarsDetails()
        {
            Connection();
            //creat instance of store procedure
            SqlCommand command = new SqlCommand("AllparkingCarDetails", con);
            command.CommandType = CommandType.StoredProcedure;
            //call get data method
            return GetParkingData(command);
        }

        private List<parkingDetails> GetParkingData(SqlCommand command)
        {
            // command.CommandType = CommandType.StoredProcedure;
            List<parkingDetails> list = new List<parkingDetails>();
            //open connection EmployeeTable
            con.Open();
            //data from databse return in reder
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var parkingDetails = new parkingDetails
                {

                    ParkingID = reader.GetInt32(reader.GetOrdinal("ParkingID")),
                    VehicleOwnerName = reader.GetString(reader.GetOrdinal("VehicleOwnerName")),
                    DriverName = reader.GetString(reader.GetOrdinal("DriverName")),
                    VehicleNumber = reader.GetString(reader.GetOrdinal("VehicleNumber")),
                    VehicalBrand = reader.GetString(reader.GetOrdinal("VehicalBrand")),
                    VehicalColor = reader.GetString(reader.GetOrdinal("VehicalColor")),
                    ParkingSlot  = reader.GetString(reader.GetOrdinal("ParkingSlot")),
                    ParkingUserCategory  = reader.GetString(reader.GetOrdinal("ParkingUserCategory")),
                    Status  = reader.GetString(reader.GetOrdinal("Status")),
                    ParkingDate = reader.GetDateTime(reader.GetOrdinal("ParkingDate"))

    };
                list.Add(parkingDetails);
            }
            con.Close();
            return list;
        }

        public dynamic ParkingCarInLot(parkingDetails Details)
        {
            try
            {
                //get connection
                Connection();
                //create instance of store procedure
                SqlCommand command = new SqlCommand("[spParkingInSlot]", con);
                //string encrypted = EncryptPassword(data.passWord);
                command.CommandType = CommandType.StoredProcedure;
                //send parameter to stored procedure
                command.Parameters.AddWithValue("@VehicleOwnerName", Details.VehicleOwnerName);
                command.Parameters.AddWithValue("@DriverName", Details.DriverName);
                command.Parameters.AddWithValue("@VehicleNumber", Details.VehicleNumber);
                command.Parameters.AddWithValue("@VehicalBrand", Details.VehicalBrand);
                command.Parameters.AddWithValue("@VehicalColor", Details.VehicalColor);
                command.Parameters.AddWithValue("@ParkingSlot", Details.ParkingSlot);
                command.Parameters.AddWithValue("@ParkingUserCategory", Details.ParkingUserCategory);
                command.Parameters.AddWithValue("@Status", Details.Status);
              
                //open connection EmployeeTable
                con.Open();
                //this qury return 0 after succesfuly run 1 for fail
                int i = command.ExecuteNonQuery();
                con.Close();
                if (i >= 0)
                {
                    return (true, "parking successful", Details);
                }
                else if (i == -1)
                {
                    return (false, "parking is full", Details);
                }
                else if (i == -2)
                {
                    return (false, "slot is full", Details);
                }
                else
                {
                    return (false, "parking fail", Details);
                }
               
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
          


        }

        public List<parkingDetails> GetAllUnparkedCarsDetails()
        {
            Connection();
            //creat instance of store procedure
            SqlCommand command = new SqlCommand("GetAllUnparkedCarsDetails", con);
            command.CommandType = CommandType.StoredProcedure;

            //call get data method
            return GetParkingData(command);
        }
       
        public List<parkingDetails> GetCarDetailByNumber(string number)
        {
            Connection();
            //creat instance of store procedure
            SqlCommand command = new SqlCommand("GetCarDetailByNumber", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@VehicleNumber", number);
            //call get data method
            return GetParkingData(command);
        }
    
        public List<parkingDetails> GetAllCarDetailByColor(string color)
        {
            Connection();
            //creat instance of store procedure
            SqlCommand command = new SqlCommand("GetAllCarDetailByColor", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@VehicalColor", color);
            //call get data method
            return GetParkingData(command);
        }
       
        public List<parkingDetails> GetAllCarDetailByBrand(string brand)
        {
            Connection();
            //creat instance of store procedure
            SqlCommand command = new SqlCommand("GetAllCarDetailByBrand", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@VehicalBrand", brand);
            //call get data method
            return GetParkingData(command);
        }
       
        public List<parkingDetails> GetAllHandicapDriverDetail(string driverType)
        {
            Connection();
            //creat instance of store procedure
            SqlCommand command = new SqlCommand("GetAllHandicapDriverDetail", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ParkingUserCategory", driverType);
            //call get data method
            return GetParkingData(command);
        }
       
        public List<parkingDetails> GetCarDetailsByParkingSlot(string Slot)
        {
            Connection();
            //creat instance of store procedure
            SqlCommand command = new SqlCommand("GetCarDetailsByParkingSlot", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ParkingSlot", Slot);
            //call get data method
            return GetParkingData(command);
        }

        public parkingDetails CarUnPark(int parkingID)
        {
            throw new NotImplementedException();
        }

        public parkingDetails DeleteCarParkingDetails(int parkingID)
        {
            throw new NotImplementedException();
        }
    }
}
