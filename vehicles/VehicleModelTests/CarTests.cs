using FluentAssertions;
using VehicleModel;
using VehicleModelTests.Util;

namespace VehicleModelTests;

public class CarTests
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
    [InlineData(100, 6, 100, RoadType.CityRoad, 7.2, 0.9)]
    [InlineData(100, 6, 100, RoadType.Highway, 4.8, 1)]
    public void Drive_GivenDistanceAndDrivingMode_ReturnsCorrectConsumptionAndTime(double distanceKilometer, double carBaseConsumption, double carBaseSpeed, RoadType drivingMode, double expectedConsumption, double expectedTimeHours)
    {
        var car = TestingHelper.VehicleBuilder.Start()
            .WithSpeed(carBaseSpeed)
            .WithConsumption(carBaseConsumption)
            .BuildPassengerVehicle();
        
        var (consumption, time) = car.Drive(distanceKilometer, drivingMode);
        
        consumption.Should().Be(expectedConsumption, "the consumption of the drive should be equal to the expected consumption.");
        time.Should().Be(TimeSpan.FromHours(expectedTimeHours), "the time of the drive should be equal to the expected time.");
    }
}