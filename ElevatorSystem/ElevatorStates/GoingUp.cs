using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.ElevatorStates
{
    // State for the Elevator when it is going down
    public class GoingUp : ElevatorState
    {
        // Constructor
        public GoingUp(ElevatorState state) :
            base(state)
        {
            CheckStateChange();
        }

        // Logic to determine what to do if the elevator is requested for a specific floor in this state
        public override void CallElevator(int floor)
        {
            if (floor > _elevator.HighestFloor || floor < _elevator.LowestFloor)
            {
                log("Call for invalid floor occured");
            }
            else if (floor > _currentFloor)
            {
                _upList.Enqueue(floor);
            }
            else
            {
                _downList.Enqueue(floor);
            }
            CheckStateChange();
        }

        // When a floor is reached we need to determine if it is a stop requested
        protected override void OnFloorReached(int floor)
        {
            base.OnFloorReached(floor);

            if (_upList.isEmpty() || floor == _elevator.HighestFloor)
            {
                _upList = new PriorityQueue<int>();
                CheckStateChange();
                return;
            }
            else if (floor == _upList.Peek())
            {
                _upList.Dequeue();
                PassengerLoadSequence();
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
            if (_upList.isEmpty() && !_downList.isEmpty())
            {
                _elevator.State = new GoingDown(this);
            }
            else if (_upList.isEmpty() && _downList.isEmpty())
            {
                _elevator.State = new Idle(this);
            }
            else if (_currentFloor < _elevator.HighestFloor)
            {
                MoveUpOneFloor();
            }
            else
            {
                _upList = new PriorityQueue<int>();     // empty the queue, the old queue to the GC
                _elevator.State = new Idle(this);
            }
        }
    }
}
