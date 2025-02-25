using System;

namespace VehicleModel;

public abstract class Vehicle
{
    public abstract double Speed { get; protected set; }
    public abstract (double consumption, TimeSpan time) Drive(double distanceKilometer, DrivingMode drivingMode);
    public abstract double BaseConsumptionPerKilometer { get; protected set; }

    public virtual double GetScaledConsumption(DrivingMode drivingMode)
    {
        return BaseConsumptionPerKilometer * drivingMode switch
        {
            DrivingMode.CityRoad => 1.2,
            DrivingMode.Highway => 0.8,
            DrivingMode.Backroad => 1.1,
            DrivingMode.Offroad => 1.5,
            _ => throw new ArgumentOutOfRangeException(nameof(drivingMode), "Invalid driving mode: " + drivingMode)
        };
    }
}