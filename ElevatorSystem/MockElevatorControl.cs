using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ElevatorSystem
{
    // A mockup of an elevator controller -- synchronus
    public class MockElevatorController : IElevatorControl
    {

        public void CloseDoors()
        {
            Thread.Sleep(1000);
        }

        public void MoveUpOneFloor(int n)
        {
            Thread.Sleep(2000);
        }

        public void MoveDownOneFloor(int n)
        {
            Thread.Sleep(2000);
        }

        public void OpenDoors()
        {
            Thread.Sleep(1000);
        }

        public void StopElevator()
        {
            Thread.Sleep(1000);
        }
    }
}
