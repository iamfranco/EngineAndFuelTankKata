using EngineAndFuelTank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineAndFuelTank.Models
{
    public class FuelTankDisplay : IFuelTankDisplay
    {
        private readonly IFuelTank _fuelTank;

        public FuelTankDisplay(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }
        public double FillLevel => Math.Round(_fuelTank.FillLevel, 2);

        public bool IsOnReserve => _fuelTank.IsOnReserve;

        public bool IsComplete => _fuelTank.IsComplete;
    }
}
