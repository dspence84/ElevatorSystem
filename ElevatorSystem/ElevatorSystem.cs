using ElevatorSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    // A representation of multiple Elevators in a group
    public class ElevatorSystem
    {        
        private List<Elevator> _elevators;              // All Elevators controlled by this system
        private IScheduler _scheduler;                  // A Scheduler algorithm for this system

        // Constructor
        public ElevatorSystem(List<Elevator> e, IScheduler scheduler)
        {
            _elevators = e;
            _scheduler = scheduler;
        }

        // Allows the schedular to be changed at any time
        public void SetScheduler(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        // Adds an elevator to the system
        public void AddElevator(Elevator e)
        {
            if(e != null && _elevators != null)
            {
                _elevators.Add(e);
            }
        }

        // Representations of pressing the Up or Down button on an elevator system
        public void CallElevatorUp(int floor)
        {
            _scheduler.CallElevatorUp(floor, _elevators);
        }

        public void CallElevatorDown(int floor)
        {
            _scheduler.CallElevatorDown(floor, _elevators);
        }

                    
    }
}
