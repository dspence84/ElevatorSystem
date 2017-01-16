using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ElevatorSystem
{
    // A simple control interface for an elevator
    public interface IElevatorControl
    {
        void StopElevator();        
        void MoveUpOneFloor(int n);
        void MoveDownOneFloor(int n);     
        void OpenDoors();
        void CloseDoors();        
    }
}
