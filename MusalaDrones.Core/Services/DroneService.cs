using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task<List<DroneList>> CheckAvailableDrones()
        {
            throw new NotImplementedException();
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
