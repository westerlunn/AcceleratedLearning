using System;

namespace Week2Modul7
{
    public class Elevator
    {
        public string ElevatorName { get; set; }
        public int CurrentFloor { get; set; }
        public int LowestFloor { get; set; }
        public int HighestFloor { get; set; }
        public int ElevatorRange => HighestFloor - LowestFloor + 1;

        public Elevator(string elevatorName, int lowestFloor, int highestFloor, int currentFloor)
        {
            ElevatorName = elevatorName;
            CurrentFloor = currentFloor;
            LowestFloor = lowestFloor;
            HighestFloor = highestFloor;

           
                if (LowestFloor > HighestFloor)
                {
                    throw new Exception();
                }
            
            
        }

        public Elevator(string elevatorName, int lowestFloor, int highestFloor) : this(elevatorName, lowestFloor, 12, lowestFloor)
        {

        }
        
        public void PrintElevatorRange()
        {
            Console.WriteLine($"The number of levels are {ElevatorRange}");
        }

        public void FloorNow()
        {

        }
        public void GoUp()
        {
            CurrentFloor++;
            if (CurrentFloor > HighestFloor)
            {
                CurrentFloor = HighestFloor;
            }

        }

        public void GoDown()
        {
            CurrentFloor--;
            if (CurrentFloor < LowestFloor)
            {
                CurrentFloor = LowestFloor;
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            var elevator = new Elevator("Hissen", 0, 10,3);
            var elevator2 = new Elevator("Hiss", 8, 7);
            Console.WriteLine(elevator.CurrentFloor);
            elevator.GoUp();
            elevator.GoUp();
            elevator.GoDown();
            elevator.PrintElevatorRange();

            //Weird?
            try
            {
                Console.WriteLine(elevator2.CurrentFloor);
            }
            catch (Exception)
            {
                Console.WriteLine("error");
                throw;
            }
            

            Console.WriteLine(elevator.CurrentFloor);
        }
    }
}
