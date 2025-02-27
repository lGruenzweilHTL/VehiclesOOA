namespace VehicleModel;

public class GasStation : FuelStation
{
    public override FuelType[] AvailableFuelTypes { get; protected set; } = [FuelType.Gasoline, FuelType.Diesel];
}