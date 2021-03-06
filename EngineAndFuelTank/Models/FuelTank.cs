using EngineAndFuelTank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineAndFuelTank.Models
{
    public class FuelTank : IFuelTank
    {
        private const int MAX_TANK_SIZE = 60;

        public double FillLevel { get; private set; } = 0;

        public bool IsOnReserve => FillLevel < 5;

        public bool IsComplete => FillLevel == MAX_TANK_SIZE;

        public void Consume(double liters)
        {
            FillLevel -= PositiveOrZero(liters);
            EnsureFillLevelValid();
        }

        public void Refuel(double liters)
        {
            FillLevel += PositiveOrZero(liters);
            EnsureFillLevelValid();
        }

        private double PositiveOrZero(double liters) => liters < 0 ? 0 : liters;

        private void EnsureFillLevelValid()
        {
            if (FillLevel < 0)
                FillLevel = 0;

            if (FillLevel > MAX_TANK_SIZE)
                FillLevel = MAX_TANK_SIZE;
        }
    }
}
