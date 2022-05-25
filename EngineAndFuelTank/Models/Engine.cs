using EngineAndFuelTank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineAndFuelTank.Models
{
    public class Engine : IEngine
    {
        private readonly IFuelTank _fuelTank;

        public bool IsRunning { get; private set; } = false;

        public Engine(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }

        public void Consume(double liters)
        {
            _fuelTank.Consume(liters);
            if (_fuelTank.FillLevel == 0)
                Stop();
        }

        public void Start()
        {
            if (_fuelTank.FillLevel > 0)
                IsRunning = true;
        }

        public void Stop() => IsRunning = false;
    }
}
