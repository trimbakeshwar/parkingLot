using parkingBL.Interface;
using parkingCL;
using parkingRL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace parkingBL.services
{
    public class vehicalParkingBL : IvehicalParkingBL
    {
        private IparkingRL information;
        public vehicalParkingBL(IparkingRL information)
        {
            this.information = information;
        }

        public List<parkingDetails> GetAllParkingCarsDetails()
        {
           return this.information.GetAllParkingCarsDetails();
        }

        public parkingDetails ParkingCarInLot(parkingDetails Details)
        {
            return this.information.ParkingCarInLot(Details);
        }
    }
}
