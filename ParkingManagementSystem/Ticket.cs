public abstract class Gate
{
    public string gateId {get;}

    protected Gate(string gateId)
    {
        this.gateId = gateId;
    }
}

public class EntryGate : Gate
{
    public EntryGate(string gateId) : base(gateId)
    {
    }
}

public class ExitGate : Gate
{
    public ExitGate(string gateId) : base(gateId)
    {
    }
}