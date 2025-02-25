namespace VehicleModel;

public class ChargingStation : FuelStation
{
    public override FuelType[] AvailableFuelTypes { get; protected set; }
}