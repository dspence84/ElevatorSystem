ElevatorSystem: An software system with the design intent to run an elevator system.
Written By: Daniel Spence
Written For: Amherst

ElevatorSystem class contains a list of Elevator objects to run an elevator system.  The ElevatorSystem takes an IScheduler as a parameter, which contains the algorithm for deciding how to call an elevator within the system.  I included a DefaultScheduler class that maximizes transportation throughput by looking for elevators going the way in which the client asked.

The Elevator class contains a state machine.  It can change its behavior based on which state it is in.  I included 3 states, GoingUp, GoingDown and Idle.  More states could be added, I thought best practice was to keep extensibility in mind.  The ElevatorState is an abstract class from which each state must inherit.  Finally, there is an IElevatorControl interface in which the expected elevator controller is to use to communicate with this software.

I included a MockElevatorController class and a quick unit test to test the functionality of the Elevator.  I wanted to implement the Elevator functionality using the .NET Task based asynchronus programming, however it was slightly outside of my scope as far as time to implement.  An event based system would have been a better practice for this exercise as well.

Thank you for giving me this opportunity, I hope this suits the spirit of this exercise.