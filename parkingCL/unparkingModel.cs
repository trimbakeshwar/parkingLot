using System;
using System.Collections.Generic;
using System.Text;

namespace parkingCL
{
    public class unparkingModel
    {
        public int VehicleUnParkID { get; set; }
        public int ParkingID { get; set; }
        public string Status { get; set; } 
        public double TotalTime { get; set; }
        public double TotalAmount { get; set; }
    }
}
