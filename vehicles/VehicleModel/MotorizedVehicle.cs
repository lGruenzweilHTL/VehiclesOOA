namespace VehicleModel;

public abstract class MotorizedVehicle
{
    public abstract int FuelCap { get; protected set; }
    public abstract int FuelLevel { get; protected set; }
    public abstract FuelType FuelType { get; protected set; }

    public virtual void FillTank()
    {
        FuelLevel = FuelCap;
    }
}