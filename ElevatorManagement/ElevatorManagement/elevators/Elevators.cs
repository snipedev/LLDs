namespace ElevatorManagement.elevators;

public enum ElevatorState
{
    Idle,
    MovingUp,
    MovingDown,
    Maintenance
}

public enum Directions
{
    Up,
    Down,
    Idle,
}

public enum ElevatorDoor
{
    Open,
    Closed,
}

public class Elevators
{
    public int Id { get; }
    public int CurrentFloor { get; }

    public ElevatorState State { get; set; }
    public Directions Direction { get; set; }

    public ElevatorDoor DoorState { get; set; }

    public Elevators(int id, int currentFloor)
    {
        Id = id;
        CurrentFloor = currentFloor;
    }

    public void Move(int FloorNumber)
    {
        if(FloorNumber > CurrentFloor)
        {
            State = ElevatorState.MovingUp;
            Direction = Directions.Up;
        }
        else if(FloorNumber < CurrentFloor)
        {
            State = ElevatorState.MovingDown;
            Direction = Directions.Down;
        }
        else
        {
            State = ElevatorState.Idle;
            Direction = Directions.Idle;
        }
    }
}

public class ElevatorController
{
    public int Id { get; }

    public ElevatorController(int id)
    {
        Id = id;
        upRequests = new SortedSet<int>();
        downRequests = new SortedSet<int>();
    }

    public SortedSet<int> upRequests { get; set; }
    public SortedSet<int> downRequests { get; set; }

    public void AddRequest(int floorNumber, Directions direction)
    {
        if(direction == Directions.Up)
        {
            upRequests.Add(floorNumber);
        }
        else if(direction == Directions.Down)
        {
            downRequests.Add(floorNumber);
        }
    }
}