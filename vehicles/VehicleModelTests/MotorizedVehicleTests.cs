using FluentAssertions;
using VehicleModel;
using Xunit;

namespace VehicleModelTests;

public class MotorizedVehicleTests
{
    [Fact]
    public void FillTank_OnCalled_FuelLevelIsEqualToFuelCap()
    {
        var vehicle = TestingHelper.VehicleBuilder.Start()
            .BuildCar() as MotorizedVehicle;
        
        vehicle.FillTank();
        
        vehicle.FuelLevel.Should().Be(vehicle.FuelCap, "the fuel level should be equal to the fuel cap after refueling because the tank is full.");
    }
    
    [Theory]
    [InlineData(100, 6, 100, RoadType.CityRoad)]
    [InlineData(100, 6, 100, RoadType.Highway)]
    [InlineData(50, 6, 60, RoadType.Offroad)]
    [InlineData(50, 6, 60, RoadType.Backroad)]
    [InlineData(0, 6, 0, RoadType.CityRoad)]
    [InlineData(27, 10, 2, RoadType.Highway)]
    public void Drive_GivenConstructionAndDrivingParams_ReturnsCorrectConsumptionAndTimeAndSetsValues(double distanceKilometer, double carBaseConsumption, double carBaseSpeed, RoadType roadType)
    {
        var vehicle = TestingHelper.VehicleBuilder.Start()
            .WithSpeed(carBaseSpeed)
            .WithConsumption(carBaseConsumption)
            .BuildCar() as MotorizedVehicle;
        
        var (consumption, time) = vehicle.Drive(distanceKilometer, roadType);

        var expectedConsumption = (carBaseConsumption * TestingHelper.Constants.ConsumptionMultiplier.GetConsumptionMultiplier(roadType) / 100) * distanceKilometer;
        var expectedTimeHours = carBaseSpeed == 0 ? 0 : distanceKilometer / (carBaseSpeed * TestingHelper.Constants.SpeedMultiplier.GetSpeedMultiplier(roadType));        
        
        consumption.Should().Be(expectedConsumption, "the consumption of the drive should be equal to the expected consumption.");
        time.Should().Be(TimeSpan.FromHours(expectedTimeHours), "the time of the drive should be equal to the expected time.");
        
        vehicle.FuelLevel.Should().Be(vehicle.FuelCap - expectedConsumption, "the fuel level should be equal to remaining fuel in the tank.");
    }
    
    [Fact]
    public void Drive_GivenDistanceGreaterThanFuelLevel_ReturnsDefault()
    {
        var vehicle = TestingHelper.VehicleBuilder.Start()
            .WithSpeed(100)
            .WithConsumption(10)
            .WithFuelCap(10)
            .BuildCar() as MotorizedVehicle;

        vehicle.Drive(101, RoadType.CityRoad).Should().Be(default);
    }
}