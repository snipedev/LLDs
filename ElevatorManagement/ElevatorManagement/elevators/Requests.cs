public abstract class Requests
{
    public int FloorNumber {get;set;}

    private Requests GetRequest(int floorNumber)
    {
        return new Requests(floorNumber);
    }
}

public class ExternalRequest : Requests
{
    public Directions Direction {get;set;}

    public ExternalRequest(int floorNumber, Directions direction) : base(floorNumber)
    {
        FloorNumber = floorNumber;
        Direction = direction;
    }
}

public class InternalRequest : Requests
{
    public InternalRequest(int floorNumber) : base(floorNumber)
    {
        FloorNumber = floorNumber;
    }
}