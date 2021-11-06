using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusalaDrones.Common.Enums;
using MusalaDrones.Core.Interfaces;
using MusalaDrones.Core.ViewModel;
using MusalaDrones.Data;


namespace MusalaDrones.Core.Services
{
    public class DroneService : IDroneService
    {

        private readonly DroneContext _context;

        public DroneService(DroneContext context)
        {
            _context = context;
        }

        public async Task<List<DroneList>> CheckAvailableDrones()
        {
            var availableDrones = await _context.Drones.Where(x => x.State == DroneState.Idle).Select(x =>

                new DroneList
                {

                    SerialNumber = x.SerialNumber,
                    BatteryCapacity = x.BatteryCapacity,
                    Id = x.Id,
                    Weight = x.Weight,
                    Model = nameof(x.Model),
                    State = nameof(x.State)

                }).ToListAsync();

            return availableDrones;
        }

        public Task<double> CheckBatteryLevel(int DroneId)
        {
            throw new NotImplementedException();
        }

        public Task<List<DroneMedicationItems>> GetDroneMedicationItems(int DroneId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> LoadDrone(LoadDrone model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult> RegisterDrone(RegisterDrone model)
        {
            throw new NotImplementedException();
        }
    }
}
