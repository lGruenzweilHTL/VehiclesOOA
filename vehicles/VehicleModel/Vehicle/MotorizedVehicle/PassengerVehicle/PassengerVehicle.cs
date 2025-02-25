using System;

namespace VehicleModel;

public class PassengerVehicle : MotorizedVehicle
{
    public PassengerVehicle(string make, string model, int year, double speed, double consumptionPerKilometer, double fuelCap, FuelType fuelType) : base(make, model, year, speed, consumptionPerKilometer, fuelCap, fuelType)
    {
    }

    public override (double consumption, TimeSpan time) Drive(double distanceKilometer, RoadType roadType)
    {
        if (FuelLevel <= 0)
        {
            return (0, TimeSpan.Zero);
        }

        var scaledConsumption = GetScaledConsumption(roadType);
        var consumption = scaledConsumption * distanceKilometer;
        FuelLevel -= consumption / BaseConsumptionPerKilometer;
        var time = TimeSpan.FromHours(distanceKilometer / Speed);
        return (consumption, time);
    }
}