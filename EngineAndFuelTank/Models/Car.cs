using EngineAndFuelTank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineAndFuelTank.Models
{
    public class Car : ICar
    {
        private const int DEFAULT_FUEL_LEVEL = 20;
        private const double IDLE_FUEL_CONSUMPTION = 0.0003;

        public readonly IFuelTankDisplay fuelTankDisplay;
        private readonly IEngine _engine;
        private readonly IFuelTank _fuelTank;

        public Car() : this(DEFAULT_FUEL_LEVEL)
        {
        }

        public Car(double fuelLevel)
        {
            if (fuelLevel < 0)
                fuelLevel = 0;

            _fuelTank = new FuelTank();
            fuelTankDisplay = new FuelTankDisplay(_fuelTank);
            _engine = new Engine(_fuelTank);

            _fuelTank.Refuel(fuelLevel);
        }

        public bool EngineIsRunning => _engine.IsRunning;

        public void EngineStart() => _engine.Start();

        public void EngineStop() => _engine.Stop();

        public void Refuel(double liters) => _fuelTank.Refuel(liters);

        public void RunningIdle()
        {
            if (_engine.IsRunning)
                _engine.Consume(IDLE_FUEL_CONSUMPTION);
        }
    }
}
