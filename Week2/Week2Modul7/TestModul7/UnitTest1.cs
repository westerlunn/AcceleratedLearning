using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week2Modul7;

namespace TestModul7
{
    [TestClass]
    public class UnitTest1
    {
        Elevator elevator = new Elevator("Hiss", 0, 10, 10);
        [TestMethod]
        public void TestMethod1()
        {
            
            elevator.GoDown();
            elevator.GoDown();
            elevator.GoDown();
            elevator.GoDown();
            elevator.GoDown();
            elevator.GoDown();
            elevator.GoDown();
            elevator.GoDown();
        }

        [TestMethod]
        public  void TopFloor()
        {
            Assert.AreEqual(10, elevator.HighestFloor);
        }

        [TestMethod]
        public void TopFloorNotExceeded()
        {
            elevator.GoUp();
            Assert.AreEqual(elevator.HighestFloor, elevator.CurrentFloor);
        }

        [TestMethod]
        public void RangeOfElevator()
        {
            Assert.AreEqual(elevator.ElevatorRange, 11);
        }
    }
}
