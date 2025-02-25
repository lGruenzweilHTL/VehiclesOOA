using FluentAssertions;
using VehicleModel;

namespace VehicleModelTests;

public class PassengerVehicleTests
{
    [Fact]
    public void FillTank_OnCalled_FuelLevelIsEqualToFuelCap()
    {
        var car = TestingHelper.VehicleBuilder.Start()
            .BuildPassengerVehicle();
        
        car.FillTank();
        
        car.FuelLevel.Should().Be(car.FuelCap);
    }
    
    [Theory]
    [InlineData(100, 6, 100, RoadType.CityRoad)]
    [InlineData(100, 6, 100, RoadType.Highway)]
    [InlineData(50, 6, 60, RoadType.Offroad)]
    [InlineData(50, 6, 60, RoadType.Backroad)]
    [InlineData(0, 6, 0, RoadType.CityRoad)]
    [InlineData(27, 10, 2, RoadType.Highway)]
    public void Drive_GivenDistanceAndDrivingMode_ReturnsCorrectConsumptionAndTime(double distanceKilometer, double carBaseConsumption, double carBaseSpeed, RoadType roadType)
    {
        var car = TestingHelper.VehicleBuilder.Start()
            .WithSpeed(carBaseSpeed)
            .WithConsumption(carBaseConsumption)
            .BuildPassengerVehicle();
        
        var (consumption, time) = car.Drive(distanceKilometer, roadType);

        var expectedConsumption = carBaseConsumption * TestingHelper.Constants.ConsumptionMultiplier.GetConsumptionMultiplier(roadType);
        var expectedTimeHours = carBaseSpeed == 0 ? 0 : distanceKilometer / (carBaseSpeed * TestingHelper.Constants.SpeedMultiplier.GetSpeedMultiplier(roadType));        
        
        consumption.Should().Be(expectedConsumption, "the consumption of the drive should be equal to the expected consumption.");
        time.Should().Be(TimeSpan.FromHours(expectedTimeHours), "the time of the drive should be equal to the expected time.");
    }
}