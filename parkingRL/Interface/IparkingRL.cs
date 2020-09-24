using parkingCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace parkingRL.Interface
{
    public interface IparkingRL
    {
        parkingDetails ParkingCarInLot(parkingDetails Details);
        List<parkingDetails> GetAllParkingCarsDetails();
    }
}
