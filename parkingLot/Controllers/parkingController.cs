using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using parkingBL.Interface;
using parkingCL;
using parkingRL.Interface;

namespace parkingLot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class parkingController : ControllerBase
    {
        private IvehicalParkingBL data;
        public parkingController(IvehicalParkingBL data)
        {
            this.data = data;
        }
        [HttpPost]
       
        public IActionResult ParkingCarInLot(parkingDetails Details)
        {

           dynamic orignal =  data.ParkingCarInLot(Details);
            bool status = orignal.Item1;
            string massage = orignal.Item2;
            dynamic result = orignal.Item3;
            return Ok(new { success = status, Massage = massage, data = result });
        }
        [HttpGet]
        public IActionResult GetAllParkingCarsDetails()
        {
            List<parkingDetails> orignal = data.GetAllParkingCarsDetails();
            return Ok(new { success = true, Massage = "all car details", data = orignal });
        }
     
        [HttpGet]
        [Route("unparkCars")]
        public IActionResult GetAllUnparkedCarsDetails()
        {
            List<parkingDetails> orignal = data.GetAllUnparkedCarsDetails();
            return Ok(new { success = true, Massage = "all unpark car details", data = orignal });
        }
        [HttpGet]
        [Route("Vehical/{number}")]
        public IActionResult GetCarDetailByNumber(string number)
        {
            List<parkingDetails> orignal = data.GetCarDetailByNumber(number);
            return Ok(new { success = true, Massage = "all car details by number", data = orignal });
        }


        [HttpGet]
        [Route("VehicalColor/{color}")]
        public IActionResult GetAllCarDetailByColor(string color)
        {
            List<parkingDetails> orignal = data.GetAllCarDetailByColor(color);
            return Ok(new { success = true, Massage = "all car details by color", data = orignal });
        }

        [HttpGet]
        [Route("VehicalBrand/{brand}")]
        public IActionResult GetAllCarDetailByBrand(string brand)
        {
            List<parkingDetails> orignal = data.GetAllCarDetailByBrand(brand);
            return Ok(new { success = true, Massage = "all car details by brand", data = orignal });
        }

        [HttpGet]
        [Route("VehicaldriverType/{driverType}")]
        public IActionResult GetAllHandicapDriverDetail(string driverType)
        {
            List<parkingDetails> orignal = data.GetAllHandicapDriverDetail(driverType);
            return Ok(new { success = true, Massage = "all handicap driver car details", data = orignal });
        }

        [HttpGet]
        [Route("VehicalSlot/{Slot}")]
        public IActionResult GetCarDetailsByParkingSlot(string Slot)
        {
            List<parkingDetails> orignal = data.GetCarDetailsByParkingSlot(Slot);
            return Ok(new { success = true, Massage = "all car in slot", data = orignal });
        }
        [HttpPut]
        [Route("{ID}/Unpark")]
        public IActionResult CarUnPark(int ParkingID)
        {
            parkingDetails orignal = data.CarUnPark(ParkingID);
            return Ok(new { success = true, Massage = "car un park", data = orignal });
        }
        [HttpDelete]
        [Route("{ID}")]
        public IActionResult DeleteCarParkingDetails(int ParkingID)
        {
            parkingDetails orignal = data.DeleteCarParkingDetails(ParkingID);
            return Ok(new { success = true, Massage = "delete car details", data = orignal });

        }


    }
}
