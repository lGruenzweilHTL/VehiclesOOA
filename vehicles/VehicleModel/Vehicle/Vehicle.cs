using System;

namespace VehicleModel;

public abstract class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    
    public double Speed { get; protected set; }
    
    /// <summary>
    /// Calculates the consumption and time it takes to drive a certain distance.
    /// Updates the fuel level of the vehicle.
    /// </summary>
    /// <param name="distanceKilometer">The distance to drive [km]</param>
    /// <param name="roadType">The type of road to drive on.</param>
    /// <returns>The consumption and time the drive took. or (0, TimeSpan.Zero) if Fuel level is too low</returns>
    public abstract (double consumption, TimeSpan time) Drive(double distanceKilometer, RoadType roadType);

    protected Vehicle(string make, string model, int year, double speed)
    {
        Make = make;
        Model = model;
        Year = year;
        
        Speed = speed;
    }
    
    public virtual double GetScaledSpeed(RoadType roadType)
    {
        return Speed * roadType switch
        {
            RoadType.CityRoad => 0.6,
            RoadType.Highway => 1.2,
            RoadType.Backroad => 0.9,
            RoadType.Offroad => 0.5,
            _ => throw new ArgumentOutOfRangeException(nameof(roadType), "Invalid road type: " + roadType)
        };
    }

    public override string ToString()
    {
        return $"{Make} {Model} ({Year}) with a base speed of {Speed} km/h";
    }
}