﻿namespace Uppgift14_GarageV3.Helpers
{
    public class HelperFunctions
    {
        /// <summary>
        /// Overload to make departureTime optional.
        /// Note: Passing an arrivalTime that has not yet happened will cause
        /// an exception to be thrown.
        /// </summary>
        /// <param name="arrivalTime"></param>
        /// <returns>TimeSpan object</returns>
        public static TimeSpan ParkedTimeAmount(DateTime arrivalTime)
        {
            return ParkedTimeAmount(arrivalTime, DateTime.Now);
        }
        /// <summary>
        /// Accepts two DateTime-objects and returns a TimeSpan-object of 
        /// time passed between arrival and departure.
        /// </summary>
        /// <param name="arrivalTime"></param>
        /// <param name="departureTime"></param>
        /// <exception cref="ArgumentException">When departureTime is ahead of arrivalTime.</exception>
        /// <returns>TimeSpan object</returns>
        public static TimeSpan ParkedTimeAmount(DateTime arrivalTime, DateTime departureTime)
        {
            if (departureTime < arrivalTime)
                throw new ArgumentException("Departure time cannot be before arrival time");

            TimeSpan parkedTime = departureTime - arrivalTime;

            return parkedTime;
        }


        public static decimal CostCalculation(TimeSpan parkedTime, decimal pricePerHour)
        {
            decimal totalCost;

            totalCost = (decimal)parkedTime.TotalHours * pricePerHour;

            return totalCost;
        }
    }
}
