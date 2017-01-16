using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Interfaces
{
    // Scheduler interface for the elevator system
    public interface IScheduler
    {
        void CallElevatorDown(int floor, List<Elevator> elevators);
        void CallElevatorUp(int floor, List<Elevator> elevators);
    }
}
