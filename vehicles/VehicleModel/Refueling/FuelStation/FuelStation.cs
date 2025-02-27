using System.Linq;

namespace VehicleModel;

public abstract class FuelStation
{
    public FuelType[] AvailableFuelTypes { get; protected set; }

    protected FuelStation(params FuelType[] fuelTypes)
    {
        AvailableFuelTypes = fuelTypes;
    }

    /// <summary>
    /// Refuels a vehicle to full capacity instantly.
    /// </summary>
    /// <param name="vehicle">The vehicle to refuel</param>
    /// <returns>If the refueling was successful</returns>
    public virtual bool Refuel(MotorizedVehicle vehicle)
    {
        if (!CanRefuel(vehicle)) return false;
        
        vehicle.FillTank();
        return true;
    }

    /// <summary>
    /// If a Vehicle can refuel at this Fuel station
    /// </summary>
    /// <param name="vehicle">The vehicle that wants to refuel</param>
    /// <returns>If the vehicle is able to refuel at this Fuel station</returns>
    public bool CanRefuel(MotorizedVehicle vehicle)
    {
        return AvailableFuelTypes.Contains(vehicle.FuelType);
    }
}