using ElevatorSystem.ElevatorStates;
using ElevatorSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    // An implementation of a schedular -- the main algorithm for the elevator system
    public class DefaultScheduler : IScheduler
    {
        public void CallElevatorDown(int floor, List<Elevator> elevators)
        {
            // find an elevator that is idle sittong on the current floor
            foreach (Elevator e in elevators)
            {
                if (e.CurrentFloor == floor && e.State is Idle)
                {
                    e.CallElevator(floor);
                    return;
                }
            }

            // try to find an elevator currently moving down towards the callers floor
            foreach (Elevator e in elevators)
            {
                if (e.CurrentFloor > floor && e.State is GoingDown)
                {
                    e.CallElevator(floor);
                    return;
                }
            }

            // try to find an idle elevator
            foreach (Elevator e in elevators)
            {
                if (e.State is Idle)
                {
                    e.CallElevator(floor);
                    return;
                }
            }

            // finally, just pick the first elevator if all else fails
            if (elevators.Count > 0)
            {
                elevators[0].CallElevator(floor);
            }
        }

        // similar to the strategy used in CallElevatorDown
        public void CallElevatorUp(int floor, List<Elevator> elevators)
        {
            // find an elevator that is idle sittong on the current floor
            foreach (Elevator e in elevators)
            {
                if (e.CurrentFloor == floor && e.State is Idle)
                {
                    e.CallElevator(floor);
                    return;
                }
            }

            // try to find an elevator currently moving up towards the callers floor
            foreach (Elevator e in elevators)
            {
                if(e.CurrentFloor < floor && e.State is GoingUp)
                {
                    e.CallElevator(floor);
                    return;
                }
            }

            // try to find an idle elevator
            foreach (Elevator e in elevators)
            {
                if(e.State is Idle)
                {
                    e.CallElevator(floor);
                    return;
                }
            }

            // finally just pick an elevator if nothing else works
            if(elevators.Count > 0)
            {
                elevators[0].CallElevator(floor);
            }

        }
    }
}
