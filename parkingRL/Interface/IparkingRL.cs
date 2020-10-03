using parkingCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace parkingRL.Interface
{
    public interface IparkingRL
    {
       dynamic ParkingCarInLot(parkingDetails Details);
        List<parkingDetails> GetAllParkingCarsDetails();
        List<parkingDetails> GetAllUnparkedCarsDetails();
        List<parkingDetails> GetCarDetailByNumber(string number);
        List<parkingDetails> GetAllCarDetailByColor(string color);
        List<parkingDetails> GetAllCarDetailByBrand(string brand);
        List<unparkingModel> CarUnPark(string VehicleNumber);
        List<parkingDetails> GetAllHandicapDriverDetail(string driverType);
        List<parkingDetails> GetCarDetailsByParkingSlot(string Slot);
        dynamic DeleteCarParkingDetails(int parkingID);
    }
}
