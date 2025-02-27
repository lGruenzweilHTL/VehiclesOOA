using VehicleModel;

namespace VehicleModelTests;

public class TestingHelper
{
    public class Constants
    {
        
        public class SpeedMultiplier
        {
            public static double GetSpeedMultiplier(RoadType roadType)
            {
                return roadType switch
                {
                    RoadType.CityRoad => 0.6,
                    RoadType.Highway => 1.2,
                    RoadType.Backroad => 0.9,
                    RoadType.Offroad => 0.5,
                    _ => 1
                };
            }

            
            public const double CityRoad = 0.6;
            public const double Highway = 1.2;
            public const double Backroad = 0.9;
            public const double Offroad = 0.5;
        }

        public class ConsumptionMultiplier
        {
            public static double GetConsumptionMultiplier(RoadType roadType)
            {
                return roadType switch
                {
                    RoadType.CityRoad => 1.2,
                    RoadType.Highway => 0.8,
                    RoadType.Backroad => 1.1,
                    RoadType.Offroad => 1.5,
                    _ => 1
                };
            }
            
            public const double CityRoad = 1.2;
            public const double Highway = 0.8;
            public const double Backroad = 1.1;
            public const double Offroad = 1.5;
        }
    }
    public class VehicleBuilder
    {
        private string _make = "VM";
        private string _model = "Cougar";
        private int _year = 1961;
        private double _speed = 100; // km/h
        private double _consumption = 6; // l/100km
        private double _fuelCap = 60; // l
        private FuelType _fuelType = FuelType.Gasoline;

        public static VehicleBuilder Start()
        {
            return new VehicleBuilder();
        }
        
        public VehicleBuilder WithMake(string make)
        {
            _make = make;
            return this;
        }
        
        public VehicleBuilder WithModel(string model)
        {
            _model = model;
            return this;
        }
        
        public VehicleBuilder WithYear(int year)
        {
            _year = year;
            return this;
        }
        
        public VehicleBuilder WithSpeed(double speed)
        {
            _speed = speed;
            return this;
        }
        
        public VehicleBuilder WithConsumption(double consumptionPer100Kilometer)
        {
            _consumption = consumptionPer100Kilometer;
            return this;
        }
        
        public VehicleBuilder WithFuelCap(double fuelCap)
        {
            _fuelCap = fuelCap;
            return this;
        }
        
        public VehicleBuilder WithFuelType(FuelType fuelType)
        {
            _fuelType = fuelType;
            return this;
        }
        
        public PassengerVehicle BuildCar()
        {
            return new Car(_make, _model, _year, _speed, _consumption, _fuelCap, _fuelType);
        }
        public PassengerVehicle BuildTruck()
        {
            return new Truck(_make, _model, _year, _speed, _consumption, _fuelCap, _fuelType);
        }
    }
    
}