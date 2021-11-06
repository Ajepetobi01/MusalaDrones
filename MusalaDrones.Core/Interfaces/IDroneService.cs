using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusalaDrones.Core.ViewModel;

namespace MusalaDrones.Core.Interfaces
{
    public interface IDroneService
    {
        Task<BaseResult> RegisterDrone(RegisterDrone model);

        Task<BaseResult> LoadDrone(LoadDrone model);

        Task<List<DroneMedicationItems>> GetDroneMedicationItems(int DroneId);

        Task<List<DroneList>> CheckAvailableDrones();

        Task<double> CheckBatteryLevel(int DroneId);
    }
}
