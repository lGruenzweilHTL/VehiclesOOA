namespace VehicleModel;

public class Car : PassengerVehicle
{
    public Car(string make, string model, int year, double speed, double consumptionPer100Kilometers, double fuelCap, FuelType fuelType) : base(make, model, year, speed, consumptionPer100Kilometers, fuelCap, fuelType)
    {
        
    }
}