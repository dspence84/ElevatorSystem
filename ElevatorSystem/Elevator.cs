using ElevatorSystem.ElevatorStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    // The Elevator representation
    public class Elevator
    {
        private ElevatorState _elevatorState;           // Current Elevator state -- GoingUp, GoingDown, Idle -- more if needed
        private int _lowestFloor;                       // The lowest floor this elevator is allowed to reach
        private int _highestFloor;                      // The highest floor this elevator is allowed to reach
        private string _id;                             // A string representation for this elevator for logging purposes

        // Properties
        public int LowestFloor { get { return _lowestFloor; } }
        public int HighestFloor { get { return _highestFloor; } }
        public string Id { get { return _id; } }
        public ElevatorState State {
            get { return _elevatorState; }
            set { _elevatorState = value; }
        }
        public int CurrentFloor { get { return _elevatorState.CurrentFloor; } }
        
        // Constructor
        public Elevator(int startingFloor, int lowestFloor, int highestFloor, string id, IElevatorControl controller)
        {
            _lowestFloor = lowestFloor;
            _highestFloor = highestFloor;
            _id = id;
            _elevatorState = new Idle(this, startingFloor, new PriorityQueue<int>(), new PriorityQueue<int>(), controller);
        }

        // Request a floor -- will request based on state (Transparent to the user of the class)
        public void CallElevator(int floor)
        {
            if(floor < _lowestFloor || floor > _highestFloor)
            {
                Console.WriteLine("Invalid Floor Called");
                return;
            }
            _elevatorState.CallElevator(floor);
        }    
    }
}
