﻿using FluentAssertions;
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
    [InlineData(100, 6, 100, RoadType.CityRoad)]
    [InlineData(100, 6, 100, RoadType.Highway)]
    [InlineData(50, 6, 60, RoadType.Offroad)]
    public void Drive_GivenDistanceAndDrivingMode_ReturnsCorrectConsumptionAndTime(double distanceKilometer, double carBaseConsumption, double carBaseSpeed, RoadType roadType)
    {
        var car = TestingHelper.VehicleBuilder.Start()
            .WithSpeed(carBaseSpeed)
            .WithConsumption(carBaseConsumption)
            .BuildPassengerVehicle();
        
        var (consumption, time) = car.Drive(distanceKilometer, roadType);

        var expectedConsumption = carBaseConsumption * TestingHelper.Constants.ConsumptionMultiplier.GetConsumptionMultiplier(roadType);
        var expectedTimeHours = distanceKilometer / (carBaseSpeed * TestingHelper.Constants.SpeedMultiplier.GetSpeedMultiplier(roadType));
        
        consumption.Should().Be(expectedConsumption, "the consumption of the drive should be equal to the expected consumption.");
        time.Should().Be(TimeSpan.FromHours(expectedTimeHours), "the time of the drive should be equal to the expected time.");
    }
}