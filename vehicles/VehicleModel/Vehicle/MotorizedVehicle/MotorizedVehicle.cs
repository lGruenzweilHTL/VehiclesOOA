using System;

namespace VehicleModel;

public abstract class MotorizedVehicle : Vehicle
{
    protected MotorizedVehicle(string make, string model, int year,
        double speed, double consumptionPer100Kilometers, double fuelCap, FuelType fuelType)
        : base(make, model, year, speed)
    {
        FuelCap = fuelCap;
        FuelType = fuelType;
        FuelLevel = fuelCap;
        BaseConsumptionPer100Kilometers = consumptionPer100Kilometers;
    }


    public double FuelCap { get; protected set; }
    public double FuelLevel { get; protected set; }
    public FuelType FuelType { get; protected set; }

    /// <summary>
    /// The base consumption of the car (in liters/100km or Wh/km for electrics)
    /// </summary>
    public double BaseConsumptionPer100Kilometers { get; protected set; }

    public virtual void FillTank()
    {
        FuelLevel = FuelCap;
    }

    public virtual double GetScaledConsumption(RoadType roadType)
    {
        return BaseConsumptionPer100Kilometers * roadType switch
        {
            RoadType.CityRoad => 1.2,
            RoadType.Highway => 0.8,
            RoadType.Backroad => 1.1,
            RoadType.Offroad => 1.5,
            _ => throw new ArgumentOutOfRangeException(nameof(roadType), "Invalid road type: " + roadType)
        };
    }
}