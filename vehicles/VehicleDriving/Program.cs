using VehicleModel;

Console.WriteLine("Vehicle Driving Demo");
Console.WriteLine("---------------------\n");

// Ride a bike
var bike = new Bicycle("Giant", "Escape 3", 2021, 25);
Console.WriteLine($"Creating bike: {bike.Make} {bike.Model} ({bike.Year})");
var bikeDistance = 15;
var bikeRoadType = RoadType.CityRoad;
var bikeResult = bike.Drive(bikeDistance, bikeRoadType);
Console.WriteLine($"Riding {bikeDistance} km on {bikeRoadType} road with {bike.Make} {bike.Model} ({bike.Year}) with a base speed of {bike.Speed} km/h");
Console.WriteLine($"Result: {bikeResult.consumption} liters, {bikeResult.time.TotalMinutes} minutes at {bike.GetScaledSpeed(bikeRoadType)}km/h\n");

// Drive a car
var car = new Car("Toyota", "Corolla", 2020, 120, 7, 50, FuelType.Gasoline);
Console.WriteLine($"Creating car: {car.Make} {car.Model} ({car.Year})");
var carDistance = 100;
var carRoadType = RoadType.Highway;
var carResult = car.Drive(carDistance, carRoadType);
Console.WriteLine($"Driving {carDistance} km on {carRoadType} road with {car.Make} {car.Model} ({car.Year}) with a base speed of {car.Speed} km/h");
Console.WriteLine($"Result: {carResult.consumption} liters, {carResult.time.TotalMinutes} minutes at {car.GetScaledSpeed(carRoadType)}km/h\n");

// Drive a truck
var truck = new Truck("Ford", "F-150", 2018, 90, 15, 80, FuelType.Diesel);
Console.WriteLine($"Creating truck: {truck.Make} {truck.Model} ({truck.Year})");
var truckDistance = 50;
var truckRoadType = RoadType.Backroad;
var truckResult = truck.Drive(truckDistance, truckRoadType);
Console.WriteLine($"Driving {truckDistance} km on {truckRoadType} road with {truck.Make} {truck.Model} ({truck.Year}) with a base speed of {truck.Speed} km/h");
Console.WriteLine($"Result: {truckResult.consumption} liters, {truckResult.time.TotalMinutes} minutes at {truck.GetScaledSpeed(truckRoadType)}km/h\n");

// Ride a bike offroad
var offroadBike = new Bicycle("Trek", "Marlin 7", 2022, 15);
Console.WriteLine($"Creating offroad bike: {offroadBike.Make} {offroadBike.Model} ({offroadBike.Year})");
var offroadBikeDistance = 5;
var offroadBikeRoadType = RoadType.Offroad;
var offroadBikeResult = offroadBike.Drive(offroadBikeDistance, offroadBikeRoadType);
Console.WriteLine($"Riding {offroadBikeDistance} km on {offroadBikeRoadType} road with {offroadBike.Make} {offroadBike.Model} ({offroadBike.Year}) with a base speed of {offroadBike.Speed} km/h");
Console.WriteLine($"Result: {offroadBikeResult.consumption} liters, {offroadBikeResult.time.TotalMinutes} minutes at {offroadBike.GetScaledSpeed(offroadBikeRoadType)}km/h\n");

/*
// Drive a motorcycle
var motorcycle = new Motorcycle("Harley-Davidson", "Street 750", 2019, 100, 5, 15, FuelType.Gasoline);
Console.WriteLine($"Creating motorcycle: {motorcycle.Make} {motorcycle.Model} ({motorcycle.Year})");
var motorcycleDistance = 80;
var motorcycleRoadType = RoadType.CityRoad;
var motorcycleResult = motorcycle.Drive(motorcycleDistance, motorcycleRoadType);
Console.WriteLine($"Driving {motorcycleDistance} km on {motorcycleRoadType} road with {motorcycle.Make} {motorcycle.Model} ({motorcycle.Year}) with a base speed of {motorcycle.Speed} km/h");
Console.WriteLine($"Result: {motorcycleResult.consumption} liters, {motorcycleResult.time.TotalMinutes} minutes at {motorcycle.GetScaledSpeed(motorcycleRoadType)}km/h\n");

// Drive a bus
var bus = new Bus("Mercedes-Benz", "Citaro", 2017, 60, 20, 300, FuelType.Diesel);
Console.WriteLine($"Creating bus: {bus.Make} {bus.Model} ({bus.Year})");
var busDistance = 30;
var busRoadType = RoadType.CityRoad;
var busResult = bus.Drive(busDistance, busRoadType);
Console.WriteLine($"Driving {busDistance} km on {busRoadType} road with {bus.Make} {bus.Model} ({bus.Year}) with a base speed of {bus.Speed} km/h");
Console.WriteLine($"Result: {busResult.consumption} liters, {busResult.time.TotalMinutes} minutes at {bus.GetScaledSpeed(busRoadType)}km/h\n");
*/