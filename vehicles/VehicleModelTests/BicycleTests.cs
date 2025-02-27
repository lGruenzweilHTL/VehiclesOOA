using FluentAssertions;
using VehicleModel;
using Xunit;

namespace VehicleModelTests;

public class BicycleTests
{
    [Theory]
    [InlineData(100, 100, RoadType.CityRoad)]
    [InlineData(100, 100, RoadType.Highway)]
    [InlineData(50, 60, RoadType.Offroad)]
    [InlineData(50, 60, RoadType.Backroad)]
    [InlineData(0, 0, RoadType.CityRoad)]
    [InlineData(27, 2, RoadType.Highway)]
    public void Drive_GivenConstructionAndDrivingParams_ReturnsCorrectTime(double distanceKilometer, double baseSpeed, RoadType roadType)
    {
        var bicycle = TestingHelper.VehicleBuilder.Start()
            .WithSpeed(baseSpeed)
            .BuildBicycle();
        
        var (consumption, time) = bicycle.Drive(distanceKilometer, roadType);

        var expectedTimeHours = baseSpeed == 0 ? 0 : distanceKilometer / (baseSpeed * TestingHelper.Constants.SpeedMultiplier.GetSpeedMultiplier(roadType));        
        
        time.Should().Be(TimeSpan.FromHours(expectedTimeHours), "the time of the drive should be equal to the expected time.");
        consumption.Should().Be(0, "the consumption of a bicycle should always be 0.");
    }
}