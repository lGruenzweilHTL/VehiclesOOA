using System;

namespace VehicleModel;

public class PassengerVehicle : MotorizedVehicle
{
    public PassengerVehicle(string make, string model, int year, double speed, double consumptionPer100Kilometers, double fuelCap, FuelType fuelType) : base(make, model, year, speed, consumptionPer100Kilometers, fuelCap, fuelType)
    {
    }

    public override (double consumption, TimeSpan time) Drive(double distanceKilometer, RoadType roadType)
    {
        if (distanceKilometer <= 0 || Speed <= 0)
        {
            return default;
        }
        
        var scaledSpeed = GetScaledSpeed(roadType);
        var time = TimeSpan.FromHours(distanceKilometer / scaledSpeed);
        
        var consumption = distanceKilometer / 100f * GetScaledConsumption(roadType);
        
        if (consumption > FuelLevel)
        {
            return default;
        }
        
        FuelLevel -= consumption;
        return (consumption, time);
    }
}