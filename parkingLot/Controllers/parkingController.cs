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
            parkingDetails orignal =  data.ParkingCarInLot(Details);
            return Ok(new { success = true, Massage = "parking is successful", data = orignal });
        }
        [HttpGet]
        public IActionResult GetAllParkingCarsDetails()
        {
            List<parkingDetails> orignal = data.GetAllParkingCarsDetails();
            return Ok(new { success = true, Massage = "all car details", data = orignal });
        }
    }
}
