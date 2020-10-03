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

        public List<unparkingModel> CarUnPark(string VehicleNumber)
        {
            return this.information.CarUnPark(VehicleNumber);
        }

        public dynamic DeleteCarParkingDetails(int ParkingID)
        {
            return this.information.DeleteCarParkingDetails( ParkingID);
           
        }

        public List<parkingDetails> GetAllCarDetailByBrand(string brand)
        {
            return this.information.GetAllCarDetailByBrand(brand);
        }

        public List<parkingDetails> GetAllCarDetailByColor(string color)
        {
            return this.information.GetAllCarDetailByColor(color);
        }

        public List<parkingDetails> GetAllHandicapDriverDetail(string driverType)
        {
            return this.information.GetAllHandicapDriverDetail(driverType);
        }

        public List<parkingDetails> GetAllParkingCarsDetails()
        {
           return this.information.GetAllParkingCarsDetails();
        }

        public List<parkingDetails> GetAllUnparkedCarsDetails()
        {
            return this.information.GetAllUnparkedCarsDetails();
        }

        public List<parkingDetails> GetCarDetailByNumber(string number)
        {
            return this.information.GetCarDetailByNumber(number);
        }

        public List<parkingDetails> GetCarDetailsByParkingSlot(string Slot)
        {
            return this.information.GetCarDetailsByParkingSlot(Slot);
        }

        public dynamic ParkingCarInLot(parkingDetails Details)
        {
            return this.information.ParkingCarInLot(Details);
        }
    }
}
