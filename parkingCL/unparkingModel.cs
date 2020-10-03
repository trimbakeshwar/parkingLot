using System;
using System.Collections.Generic;
using System.Text;

namespace parkingCL
{
    public class unparkingModel
    {
        public int VehicleUnParkID { get; set; }
        public int ParkingID { get; set; }
        public string TotalTime { get; set; }
        public decimal TotalAmount { get; set; }
        public System.DateTime  UnParkDate { get; set; }
    }
}
