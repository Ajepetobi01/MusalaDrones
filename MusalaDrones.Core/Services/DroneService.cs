﻿using System;
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
                    Model = nameof(x.Model),
                    State = nameof(x.State)

                }).ToListAsync();

            return availableDrones;
        }

        public async Task<double> CheckBatteryLevel(int DroneId)
        {

          throw new NotImplementedException();
        }

        public async Task<List<DroneMedicationItems>> GetDroneMedicationItems(int DroneId)
        {
        

            throw new NotImplementedException();
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

        public Task<BaseResult> RegisterDrone(RegisterDrone model)
        {
            throw new NotImplementedException();
        }
    }
}
