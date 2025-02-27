namespace VehicleModel;

public class ElectricCar : PassengerVehicle
{
    public ElectricCar(string make, string model, int year, double speed, double consumptionPer100Kilometers, double fuelCap) : base(make, model, year, speed, consumptionPer100Kilometers, fuelCap, FuelType.Electric)
    {
    }
}