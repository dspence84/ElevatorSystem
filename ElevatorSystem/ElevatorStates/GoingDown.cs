using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.ElevatorStates
{
    // State for the Elevator when it is going down
    public class GoingDown : ElevatorState
    {
        // This will get the Elevator started
        public GoingDown(ElevatorState state) :
            base(state)
        {            
            CheckStateChange();
        }

        // Logic to determine what to do if the elevator is requested for a specific floor in this state
        public override void CallElevator(int floor)
        {
            if (floor < _elevator.LowestFloor || floor < _elevator.LowestFloor)
            {
                log("Call for invalid floor occured");
            }
            else if (floor < _currentFloor)
            {
                _downList.Enqueue(floor);
            }
            else
            {
                _upList.Enqueue(floor);
            }
            CheckStateChange();
        }

        // When a floor is reached we need to determine if it is a stop requested
        protected override void OnFloorReached(int floor)
        {
            base.OnFloorReached(floor);

            if (_downList.isEmpty() || floor == _elevator.LowestFloor)
            {
                _downList = new PriorityQueue<int>();
                CheckStateChange();
                return;
            }
            else if (floor == _downList.Peek())
            {
                _downList.Dequeue();
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
            if (_downList.isEmpty() && _upList.isEmpty())
            {
                _elevator.State = new GoingUp(this);
            }
            else if (_downList.isEmpty() && _upList.isEmpty())
            {
                _elevator.State = new Idle(this);
            }
            else if (_currentFloor > _elevator.LowestFloor)
            {
                MoveDownOneFloor();
            }
            else
            {
                _downList = new PriorityQueue<int>();     // empty the queue
                _elevator.State = new Idle(this);
            }
        }
    }
}
