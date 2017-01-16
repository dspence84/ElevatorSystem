using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    // A sample Test program to test the functionality of an elevator
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new MockElevatorController();
            var elevator = new Elevator(1, 1, 10, "1", controller);

            elevator.CallElevator(5);
            elevator.CallElevator(4);
            elevator.CallElevator(2);
            elevator.CallElevator(9);
            elevator.CallElevator(12);

            Console.ReadLine();                  
        }
    }
}
