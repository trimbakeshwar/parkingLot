using parkingCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace parkingBL.Interface
{
    public interface IvehicalParkingBL
    {
        //Car park
        parkingDetails ParkingCarInLot(parkingDetails Details);
        List<parkingDetails> GetAllParkingCarsDetails();

        
    }
}
