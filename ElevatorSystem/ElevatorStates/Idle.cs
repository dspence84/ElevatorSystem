using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.ElevatorStates
{
    public class Idle : ElevatorState
    {
        // Constructors
        public Idle(ElevatorState state) :
            base(state)
        { }

        public Idle(Elevator elevator, int currentFloor, PriorityQueue<int> upList, PriorityQueue<int> downList, IElevatorControl controller) :
            base(elevator, currentFloor, upList, downList, controller)
        { }

        // Logic to determine what to do if the elevator is requested for a specific floor in this state
        public override void CallElevator(int floor)
        {
            if (floor < _elevator.LowestFloor || floor > _elevator.HighestFloor)
            {
                log("Invalid floor called");
                return;
            }

            if (floor > _currentFloor)
            {
                _upList.Enqueue(floor);
            }
            else if (floor < _currentFloor)
            {
                _downList.Enqueue(floor);
            }
            CheckStateChange();
        }

        /*
         * CheckStateChange()
         * checks if there is a state change necessary.
         * If no state change is needed, continues the elevator movement.
        */
        private void CheckStateChange()
        {
            if (!_downList.isEmpty() && _upList.isEmpty())
            {
                _elevator.State = new GoingDown(this);
            }
            else if (_downList.isEmpty() && !_upList.isEmpty())
            {
                _elevator.State = new GoingUp(this);
            }
        }
    }

}
