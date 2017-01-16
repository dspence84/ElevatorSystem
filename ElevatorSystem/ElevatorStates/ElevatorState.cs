using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.ElevatorStates
{
    public abstract class ElevatorState
    {        
        protected Elevator _elevator;                   // A reference to the elevator this state represents
        protected int _currentFloor;                    // the current floor of the elevator            
        protected PriorityQueue<int> _upList;           // A queue of all the floors to go up to
        protected PriorityQueue<int> _downList;         // a queue of all the floors to go down to
        protected bool _doorsClosed;                    // the current state of the elevator doors
        protected bool _moving;                         // the current state of the elevators movement
        protected IElevatorControl _controller;         // a reference to the real time elevator controller

        // public methods
        public abstract void CallElevator(int floor);   // Sends a request for the elevator

        // Properties
        public bool Moving { get { return _moving; } }
        public bool DoorsClosed { get { return _doorsClosed; } }
        public int CurrentFloor { get { return _currentFloor; } }

        // Constructors
        public ElevatorState(Elevator elevator, int currentFloor, PriorityQueue<int> upList, PriorityQueue<int> downList, IElevatorControl controller)
        {
            _elevator = elevator;
            _currentFloor = currentFloor;
            _upList = upList;
            _downList = downList;
            _controller = controller;
            _moving = false;
            _doorsClosed = true;
        }

        public ElevatorState(ElevatorState state)
        {
            _elevator = state._elevator;
            _currentFloor = state._currentFloor;
            _upList = state._upList;
            _downList = state._downList;
            _controller = state._controller;
            _moving = false;
            _doorsClosed = true;

        }               

        // Simple logging function
        protected void log(string s)
        {
            Console.WriteLine("Elevator {0}: {1}", _elevator.Id, s);
        }

        // Controller functions
        // =================================================
        protected void OpenDoors()
        {
            if (!_moving && _doorsClosed)
            {
                _controller.OpenDoors();
                log("Doors Opened");
                _doorsClosed = false;
            }
        }

        protected void CloseDoors()
        {
            if (!_doorsClosed)
            {
                log("Doors Closed");
                _controller.CloseDoors();
                _doorsClosed = true;
            }
        }

        protected void StopElevator()
        {
            if (_moving)
            {
                log("Stopping Elevator");
                _controller.StopElevator();
                log("Elevator Stopped");
                _moving = false;
            }
        }

        protected void MoveUpOneFloor()
        {
            if (_doorsClosed)
            {
                _moving = true;
                log("Moving Up");
                _controller.MoveUpOneFloor(_currentFloor + 1);
                _currentFloor += 1;
                OnFloorReached(_currentFloor);
            }
        }

        protected void MoveDownOneFloor()
        {
            if (_doorsClosed)
            {
                _moving = true;
                log("Moving Down");
                _controller.MoveDownOneFloor(_currentFloor - 1);
                _currentFloor -= 1;
                OnFloorReached(_currentFloor);
            }
        }

        // Utility
        // =================================================
        protected virtual void OnFloorReached(int n)
        {
            log("Elevator reached floor " + n);
            _currentFloor = n;
        }

        protected void PassengerLoadSequence()
        {
            StopElevator();
            OpenDoors();
            CloseDoors();
        }
    }
}
