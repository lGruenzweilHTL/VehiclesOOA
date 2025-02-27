namespace VehicleModel;

public class Bicycle : Vehicle
{
    public Bicycle(string make, string model, int year, double speed) : base(make, model, year, speed)
    {
    }

    public override (double consumption, TimeSpan time) Drive(double distanceKilometer, RoadType roadType)
    {
        if (distanceKilometer <= 0 || Speed <= 0)
        {
            return default;
        }

        var scaledSpeed = GetScaledSpeed(roadType);
        var time = TimeSpan.FromHours(distanceKilometer / scaledSpeed);

        return (0, time);
    }
}