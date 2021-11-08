using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusalaDrones.Common.Enums;
using MusalaDrones.Core.Interfaces;
using MusalaDrones.Core.ViewModel;
using MusalaDrones.Data;
using MusalaDrones.Data.Models;


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
                    Model = Enum.GetName(typeof(DroneModel), x.Model),
                    State = Enum.GetName(typeof(DroneState), x.State)

                }).ToListAsync();

            return availableDrones;
        }

        public async Task<double> CheckBatteryLevel(int DroneId)
        {
            
            double batteryLevel = 0;

            //get drone 
            var drone = await _context.Drones.Where(x => x.Id == DroneId).FirstOrDefaultAsync();

            if (drone == null)
                return batteryLevel;
            
            //get battery level
            batteryLevel = drone.BatteryCapacity;

            return batteryLevel;
          
        }

        public async Task<bool> BatteryPeriodicCheck()
        {
           //get all drones to get their battery capacity
           var allDrones = _context.Drones.ToList();
           
           //check each one of them and log their current capacity, Id

           foreach (var drone in allDrones)
           {
               
               //we can also do a check to perform some actions here like send an alert if battery is low and change drone state 
               //
               _context.PeriodicHistoryLogs.Add(new PeriodicHistoryLog
               {
                    InsertedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    DroneId = drone.Id,
                    EventData = $"Drone with Id {drone.Id} checked: Level is {drone.BatteryCapacity}",
                    BatteryCapacity = drone.BatteryCapacity

               });
               
               
           }

           await _context.SaveChangesAsync();
           return true;
        }

        public async Task<List<DroneMedicationItems>> GetDroneMedicationItems(int DroneId)
        {
            //checking loaded medication items for a given drone
            List<DroneMedicationItems> loadedItems = new List<DroneMedicationItems>();
             //check if drone Id is a valid Drone 

            var drone = await _context.Drones.Where(x => x.Id == DroneId).FirstOrDefaultAsync();

            if(drone == null)
                return null;

            //drone is valid, get loaded medication items for drone
            loadedItems = await (from p in _context.DroneMedications
                join e in _context.Medications
                    on p.DroneId equals e.Id
                join a in _context.MedicationImages
                    on e.ImageId equals a.Id
                where p.DroneId == DroneId
                select new DroneMedicationItems
                {
                    Name = e.Name,
                    Code = e.Code,
                    Weight = e.Weight,
                    MedicationImage = a.ImageBase64

                }).ToListAsync();

            return loadedItems;

        }

        public async Task<BaseResult> LoadDrone(LoadDrone model)
        {
           //Load drone with medications
           
           //check first if drone id is a valid drone Id
           var drone = await _context.Drones.Where(x => x.Id == model.DroneId)
               .FirstOrDefaultAsync();

           if (drone == null)
               return new BaseResult("Drone not found");
           
           //check the state of the drone
           if(drone.State >= DroneState.Loaded)
               return new BaseResult("Drone cannot be loaded at this time");
           
           //drone is available for loading, check the battery level
           if(drone.BatteryCapacity < 25)
               return new BaseResult("Drone battery is too low");
           
           //battery is above 25%, now change the status of the drone to loading 
           drone.State = DroneState.Loading;
           
           //now get the weight sum of the selected medication items
           var itemsWeight = _context.Medications.Where(x => model.MedicationIds.Contains(x.Id))
               .Sum(x => x.Weight);
           
           //sum of weight will only be zero when the ids passed are not found
           if(itemsWeight <= 0)
               return new BaseResult("Medication items not found");
            
           //if items are found, the sum of the weight cannot be more than the drone load
           if(itemsWeight > drone.Weight)
               return new BaseResult("Items weight cannot be more than the drone weight");

           //load each medication
           foreach (var item in model.MedicationIds)
           {
               DroneMedication droneItems = new DroneMedication
               {
                  DroneId = model.DroneId,
                  MedicationId = item,
                  TimeLoaded =DateTime.Now
                  
               };

               _context.DroneMedications.Add(droneItems);
           }

           
           await _context.SaveChangesAsync();

           return new BaseResult();

        }

        public async Task<BaseResult> RegisterDrone(RegisterDrone model)
        {
            //register drone
            
            //first, check if drone serial number exists

            var checkSerial = await _context.Drones.AnyAsync(x => x.SerialNumber.ToLower()
                                                                  == model.SerialNumber.ToLower());

            if (checkSerial == true)
                return new BaseResult("Serial Number Exists");
            
            //now, save drone

            _context.Drones.Add(new Drone
            {

                SerialNumber = model.SerialNumber,
                Model =model.Model,
                State = DroneState.Idle,
                Weight = model.Weight,
                BatteryCapacity = 100
                
             });
            await _context.SaveChangesAsync();
            return new BaseResult();
        }
    }
}
