namespace VehicleModel;

public class GasStation : FuelStation
{
    public GasStation() : base(FuelType.Gasoline, FuelType.Diesel)
    {
    }
    public GasStation(params FuelType[] fuelTypes) : base(fuelTypes.Where(t => t != FuelType.Electric).ToArray())
    {
    }
}