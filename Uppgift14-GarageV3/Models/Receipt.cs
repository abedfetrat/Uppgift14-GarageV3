﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Uppgift14_GarageV3.Helpers;

namespace Uppgift14_GarageV3.Models
{
    [ModelMetadataType(typeof(VehicleModelMetaData))]
    public class Receipt
    {
        public int ParkedVehicleId { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public DateTime ArrivalTime { get; set; }
        public TimeSpan TotalParkingTime { get; private set; }
        public decimal TotalCost { get; private set; }

        public Receipt(int parkedVehicleId, string registrationNumber, DateTime arrivalTime, decimal pricePerHour)
        {
            ParkedVehicleId = parkedVehicleId;
            RegistrationNumber = registrationNumber;
            ArrivalTime = arrivalTime;

            TotalParkingTime = HelperFunctions.ParkedTimeAmount(ArrivalTime);
            TotalCost = HelperFunctions.CostCalculation(TotalParkingTime, pricePerHour);
        }
    }
}
