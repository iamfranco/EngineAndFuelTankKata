using EngineAndFuelTank.Models;

namespace EngineAndFuelTank.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEngineStopsCauseOfNoFuelExactly()
        {
            double initialFuelLevel = 0;
            var car = new Car(initialFuelLevel);

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
        }

        [Test]
        public void TestEngineStopsCauseOfNoFuelOver()
        {
            double initialFuelLevel = -10;
            var car = new Car(initialFuelLevel);

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
        }

        [Test]
        public void TestFuelConsumptionOnIdle()
        {
            var car = new Car(1);

            car.EngineStart();

            Enumerable.Range(0, 3000).ToList().ForEach(s => car.RunningIdle());

            Assert.AreEqual(0.10, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void TestFuelLevelAllowedUpTo60()
        {
            var car = new Car(100);

            Assert.AreEqual(60, car.fuelTankDisplay.FillLevel, "Fuel Level should not exceed 60");
        }

        [Test]
        public void TestFuelTankDisplayIsComplete()
        {
            var car = new Car(60);

            Assert.IsTrue(car.fuelTankDisplay.IsComplete, "Fuel tank must be complete!");
        }

        [Test]
        public void TestFuelTankDisplayIsNotComplete()
        {
            var car = new Car(50);

            Assert.IsFalse(car.fuelTankDisplay.IsComplete, "Fuel tank must not be complete!");
        }

        [Test]
        public void TestFuelTankDisplayIsNotOnReserve()
        {
            var car = new Car(10);

            Assert.IsFalse(car.fuelTankDisplay.IsOnReserve, "Fuel tank must not be on reserve!");
        }

        [Test]
        public void TestFuelTankDisplayIsOnReserve()
        {
            var car = new Car(4);

            Assert.IsTrue(car.fuelTankDisplay.IsOnReserve, "Fuel tank must be on reserve!");
        }

        [Test]
        public void TestMotorDoesntStartWithEmptyFuelTank()
        {
            double initialFuelLevel = 0;
            var car = new Car(initialFuelLevel);

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");

            car.EngineStart();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
        }

        [Test]
        public void TestMotorStartAgainAndStopAgain()
        {
            var car = new Car();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");

            car.EngineStart();

            Assert.IsTrue(car.EngineIsRunning, "Engine should be running.");

            car.EngineStop();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");

            car.EngineStart();

            Assert.IsTrue(car.EngineIsRunning, "Engine should be running.");

            car.EngineStop();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
        }

        [Test]
        public void TestMotorStartAndStop()
        {
            var car = new Car();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");

            car.EngineStart();

            Assert.IsTrue(car.EngineIsRunning, "Engine should be running.");

            car.EngineStop();

            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
        }

        [Test]
        public void TestNoConsumptionWhenEngineNotRunning()
        {
            double initialFuelLevel = 40;
            var car = new Car(initialFuelLevel);

            Enumerable.Range(0, 1000).ToList().ForEach(_ => car.RunningIdle());

            Assert.AreEqual(initialFuelLevel, car.fuelTankDisplay.FillLevel, "Fuel Level should not change");
        }

        [Test]
        public void TestNoNegativeFuelLevelAllowed()
        {
            var car = new Car(-2);

            Assert.IsTrue(car.fuelTankDisplay.FillLevel >= 0, "Fuel Level cannot be negative");
        }

        [Test]
        public void TestRefuel()
        {
            var car = new Car(5);

            car.Refuel(40);

            Assert.AreEqual(45, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void TestFuelOverMaximum()
        {
            var car = new Car(40);

            car.Refuel(30);

            Assert.AreEqual(60, car.fuelTankDisplay.FillLevel, "Fuel Level should not exceed 60");
        }
    }
}