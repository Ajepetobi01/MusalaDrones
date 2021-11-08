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

        [ValidateModel]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterDrone(RegisterDrone droneModel)
        {
            var response = await _droneService.RegisterDrone(droneModel);
            return StatusCode((int)response.Status, response);
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
        
        [HttpGet("drone-items")]
        public async Task<IActionResult> GetDroneItems([FromQuery] int DroneId)
        {
            var droneItems = await _droneService.GetDroneMedicationItems(DroneId);
            return Ok(droneItems);
        }

        [HttpGet("battery-level")]
        public async Task<IActionResult> CheckDroneBattery([FromQuery] int DroneId)
        {
            var droneItems = await _droneService.CheckBatteryLevel(DroneId);
            return Ok(droneItems);
        }

    }
}
