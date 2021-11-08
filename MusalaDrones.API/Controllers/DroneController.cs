using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusalaDrones.Core.Interfaces;
using MusalaDrones.Core.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusalaDrones.API.Controllers
{
    [Route("api/[controller]")]
    public class DroneController : Controller
    {
        IDroneService _droneService;

        public DroneController(IDroneService droneService)
        {
            _droneService = droneService;

        }

        
        [HttpGet("available-drones")]
        public async Task<IActionResult> GetAvailableDrones()
        {
            var drones = await _droneService.CheckAvailableDrones();
            return Ok(drones);
        }

        [HttpPost("load-drones")]
        public async Task<IActionResult> LoadDrones([FromBody]LoadDrone model)
        {
            var response = await _droneService.LoadDrone(model);
            return StatusCode((int) response.Status, response);
        }

      

    }
}
