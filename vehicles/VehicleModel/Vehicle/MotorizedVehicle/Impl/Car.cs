namespace VehicleModel;

public class Car : MotorizedVehicle
{
    public override double Speed { get; protected set; }
    public override (double consumption, TimeSpan time) Drive(double distanceKilometer, DrivingMode drivingMode)
    {
        throw new NotImplementedException();
    }

    public override double BaseConsumptionPerKilometer { get; protected set; }
    public override int FuelCap { get; protected set; }
    public override int FuelLevel { get; protected set; }
    public override FuelType FuelType { get; protected set; }
}