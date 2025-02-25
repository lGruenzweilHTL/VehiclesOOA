using VehicleModel;

namespace VehicleModelTests.Util;

public class TestingHelper
{
    public class VehicleBuilder
    {
        private string _make = "VM";
        private string _model = "Cougar";
        private int _year = 1961;
        private double _speed = 100;
        private double _consumptionPer100Kilometer = 6;
        private double _fuelCap = 60;
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
            _consumptionPer100Kilometer = consumptionPer100Kilometer;
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
        
        public PassengerVehicle BuildPassengerVehicle()
        {
            return new PassengerVehicle(_make, _model, _year, _speed, _consumptionPer100Kilometer, _fuelCap, _fuelType);
        }
    }
    
}