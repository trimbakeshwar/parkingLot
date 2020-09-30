using parkingCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace parkingBL.Interface
{
    public interface IvehicalParkingBL
    {
        //Car park
        dynamic ParkingCarInLot(parkingDetails Details);
        dynamic DeleteCarParkingDetails(int ParkingID);
        parkingDetails CarUnPark(int ParkingID);
        List<parkingDetails> GetAllParkingCarsDetails();
        List<parkingDetails> GetAllUnparkedCarsDetails();
        List<parkingDetails> GetCarDetailByNumber(string number);
        List<parkingDetails> GetAllCarDetailByColor(string color);
        List<parkingDetails> GetAllCarDetailByBrand(string brand);
        List<parkingDetails> GetAllHandicapDriverDetail(string driverType);
        List<parkingDetails> GetCarDetailsByParkingSlot(string Slot);



    }
}
