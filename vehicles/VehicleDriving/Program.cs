using VehicleModel;

Console.WriteLine("Vehicle Driving Demo");
Console.WriteLine("---------------------\n");

// Create gas stations
var gasStation = new GasStation();
var chargingStation = new ChargingStation();
Console.WriteLine("Created gas station and charging station\n");

// Ride a bike
var bike = new Bicycle("Giant", "Escape 3", 2021, 25);
Console.WriteLine($"Creating bike: {bike}");
var bikeDistance = 15;
var bikeRoadType = RoadType.CityRoad;
var bikeResult = bike.Drive(bikeDistance, bikeRoadType);
Console.WriteLine($"Riding {bikeDistance} km on {bikeRoadType} road with {bike}");
Console.WriteLine($"Result: {bikeResult.consumption} liters, {bikeResult.time.TotalMinutes} minutes at {bike.GetScaledSpeed(bikeRoadType)} km/h\n");

// Drive a car
var car = new Car("Toyota", "Corolla", 2020, 120, 7, 50, FuelType.Gasoline);
Console.WriteLine($"Creating car: {car}");
var carDistance = 100;
var carRoadType = RoadType.Highway;
var carResult = car.Drive(carDistance, carRoadType);
Console.WriteLine($"Driving {carDistance} km on {carRoadType} road with {car}");
Console.WriteLine($"Result: {carResult.consumption} liters, {carResult.time.TotalMinutes} minutes at {car.GetScaledSpeed(carRoadType)} km/h\n");

// Attempt to drive beyond fuel limits
var carLongDistance = 1000;
var carLongResult = car.Drive(carLongDistance, carRoadType);
if (carLongResult.consumption == 0)
{
    Console.WriteLine($"Failed to drive {carLongDistance} km on {carRoadType} road with {car} due to insufficient fuel\n");
}

// Refuel the car at gas station
if (gasStation.Refuel(car))
{
    Console.WriteLine($"Refueled car at gas station: {car}\n");
}
else
{
    Console.WriteLine($"Failed to refuel car at gas station: {car}\n");
}

// Drive a truck
var truck = new Truck("Ford", "F-150", 2018, 90, 15, 80, FuelType.Diesel);
Console.WriteLine($"Creating truck: {truck}");
var truckDistance = 50;
var truckRoadType = RoadType.Backroad;
var truckResult = truck.Drive(truckDistance, truckRoadType);
Console.WriteLine($"Driving {truckDistance} km on {truckRoadType} road with {truck}");
Console.WriteLine($"Result: {truckResult.consumption} liters, {truckResult.time.TotalMinutes} minutes at {truck.GetScaledSpeed(truckRoadType)} km/h\n");

// Attempt to refuel the truck with gasoline
var gasolineStation = new GasStation(FuelType.Gasoline);
if (gasolineStation.Refuel(truck))
{
    Console.WriteLine($"Refueled truck at gasoline station: {truck}\n");
}
else
{
    Console.WriteLine($"Failed to refuel truck at gasoline station: {truck} due to incompatible fuel type\n");
}

// Refuel the truck at gas station
if (gasStation.Refuel(truck))
{
    Console.WriteLine($"Refueled truck at gas station: {truck}\n");
}
else
{
    Console.WriteLine($"Failed to refuel truck at gas station: {truck}\n");
}

// Ride a bike offroad
var offroadBike = new Bicycle("Trek", "Marlin 7", 2022, 15);
Console.WriteLine($"Creating offroad bike: {offroadBike}");
var offroadBikeDistance = 5;
var offroadBikeRoadType = RoadType.Offroad;
var offroadBikeResult = offroadBike.Drive(offroadBikeDistance, offroadBikeRoadType);
Console.WriteLine($"Riding {offroadBikeDistance} km on {offroadBikeRoadType} road with {offroadBike}");
Console.WriteLine($"Result: {offroadBikeResult.consumption} liters, {offroadBikeResult.time.TotalMinutes} minutes at {offroadBike.GetScaledSpeed(offroadBikeRoadType)} km/h\n");

// Drive a motorcycle
var motorcycle = new Motorcycle("Harley-Davidson", "Street 750", 2019, 100, 5, 15, FuelType.Gasoline);
Console.WriteLine($"Creating motorcycle: {motorcycle}");
var motorcycleDistance = 80;
var motorcycleRoadType = RoadType.CityRoad;
var motorcycleResult = motorcycle.Drive(motorcycleDistance, motorcycleRoadType);
Console.WriteLine($"Driving {motorcycleDistance} km on {motorcycleRoadType} road with {motorcycle}");
Console.WriteLine($"Result: {motorcycleResult.consumption} liters, {motorcycleResult.time.TotalMinutes} minutes at {motorcycle.GetScaledSpeed(motorcycleRoadType)} km/h\n");

// Refuel the motorcycle at gas station
Console.WriteLine("Attempting to refuel motorcycle at gas station...");
if (gasStation.Refuel(motorcycle))
{
    Console.WriteLine($"Refueled motorcycle at gas station: {motorcycle}\n");
}
else
{
    Console.WriteLine($"Failed to refuel motorcycle at gas station: {motorcycle}\n");
}

// Drive a bus
var bus = new Bus("Mercedes-Benz", "Citaro", 2017, 60, 20, 300, FuelType.Diesel);
Console.WriteLine($"Creating bus: {bus}");
var busDistance = 30;
var busRoadType = RoadType.CityRoad;
var busResult = bus.Drive(busDistance, busRoadType);
Console.WriteLine($"Driving {busDistance} km on {busRoadType} road with {bus}");
Console.WriteLine($"Result: {busResult.consumption} liters, {busResult.time.TotalMinutes} minutes at {bus.GetScaledSpeed(busRoadType)} km/h\n");

// Refuel the bus at gas station#
Console.WriteLine("Attempting to refuel bus at gas station...");
if (gasStation.Refuel(bus))
{
    Console.WriteLine($"Refueled bus at gas station: {bus}\n");
}
else
{
    Console.WriteLine($"Failed to refuel bus at gas station: {bus}\n");
}

// Drive an electric car
var electricCar = new ElectricCar("Tesla", "Model S", 2021, 150, 100, 120);
Console.WriteLine($"Creating electric car: {electricCar}");
var electricCarDistance = 200;
var electricCarRoadType = RoadType.Highway;
var electricCarResult = electricCar.Drive(electricCarDistance, electricCarRoadType);
Console.WriteLine($"Driving {electricCarDistance} km on {electricCarRoadType} road with {electricCar}");
Console.WriteLine($"Result: {electricCarResult.consumption} kWh, {electricCarResult.time.TotalMinutes} minutes at {electricCar.GetScaledSpeed(electricCarRoadType)} km/h\n");

// Attempt to recharge the electric car at gas station
Console.WriteLine("Attempting to recharge electric car at gas station...");
if (gasStation.Refuel(electricCar))
{
    Console.WriteLine($"Recharged electric car at gas station: {electricCar}\n");
}
else
{
    Console.WriteLine($"Failed to recharge electric car at gas station: {electricCar} due to incompatible fuel type\n");
}

// Recharge the electric car at charging station
Console.WriteLine("Attempting to recharge electric car at charging station...");
if (chargingStation.Refuel(electricCar))
{
    Console.WriteLine($"Recharged electric car at charging station: {electricCar} to full\n");
}
else
{
    Console.WriteLine($"Failed to recharge electric car at charging station: {electricCar}\n");
}