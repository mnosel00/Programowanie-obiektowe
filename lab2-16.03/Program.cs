
string messageType = "SMS";
switch (messageType)
{
    case "SMS":
        Console.WriteLine("Sending SMS");
        break;
    case "email":
        Console.WriteLine("Sending email");
        break;
}
User[] users =
    {
    new User() {Name="Karol", LastMessage= new SmsMessage(){ Content="Hello", FromPhone="090112",ToPhone="37483168"} },
    new User() {Name="Ewa", LastMessage= new EmailMessage(){ Content="Hello", From="Ewa@gmail.com",To="Karol@gmail.com",Subject="No siema"} },
    new User() {Name="Mateusz", LastMessage = new MessengerMessage(){ Content="Hello", NameFrom="Mateusz Nosel", NameTo="Ewa Kaczor"}}
};


int emailCounter = 0;

foreach (var item in users)
{
    item.LastMessage.Send();
    if (item.LastMessage is EmailMessage)
    {

        emailCounter++;
    }

    if (item.LastMessage is SmsMessage)
    {
        SmsMessage sms = (SmsMessage)item.LastMessage;
        Console.WriteLine(sms.ToPhone);
    }

}
Console.WriteLine($"Wysłano wiadomość email: {emailCounter}");

IFlyable[] flyingObject =
{
    new Duck(){Name="Kaczka", Size="Srednia"},
    new Wasp(){Name="Osa",Size="Mala"},
    new Hydroplane(){Name="Samolot",Size="Duzy"}
};
IAggregate aggregate = new SimpleAggregate();
IIterator iterator = aggregate.CreateIterator();

IAggregate aggregate1 = new CovertSimpleAggregate();
IIterator iterator1 = aggregate1.CreateIterator();

while (iterator.HasNext())
{
    Console.WriteLine(iterator.GetNext());
}
Console.WriteLine();
//------------------------------------------------------------------------------------------------------

//Main do cwiczen
Vehicle[] vehicles =
{
 
 new ElectricScooter(){Weight =40, MaxSpeed=40, MaxRange=10},
 new ElectricScooter(){Weight =40, MaxSpeed=40, MaxRange=5}
};


Console.WriteLine();
foreach (var vehicle in vehicles)
{

    Console.WriteLine($"{vehicle.Drive(5)}");
    Console.WriteLine($"Bateria naładowana w {vehicle.ChargeBatteries()}");
}

// Scooter test



//-----------------------------------------------------------------------------------------------------------
// Cwiczenia
//CW 1

public abstract class Vehicle
{
    public double Weight { get; init; }
    public int MaxSpeed { get; init; }
    protected int _mileage;
    public int Mealeage
    {
        get { return _mileage; }
    }
    public abstract decimal Drive(int distance);
    public abstract decimal ChargeBatteries();

    public override string ToString()
    {
        return $"Vehicle{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage} }}";
    }
}
public abstract class Scooter : Vehicle
{

}

public class ElectricScooter : Scooter
{
    protected decimal _batteriesLevel = 100;
    public decimal BatteriesLevel
    {
        get { return _batteriesLevel; }
    }
    public decimal MaxRange { get; init; } //20

    public override decimal ChargeBatteries()
    {
        if (_batteriesLevel != 100 && _batteriesLevel < 100)
        {
            while (_batteriesLevel != 100)
            {
                _batteriesLevel++;
            }
            return _batteriesLevel;
        }
        else
        {
            return _batteriesLevel;
        }



    }
    public override decimal Drive(int distance) //MAx range 10 distance 5 batlevel 100
    {
        decimal ProcentBateriNaJedenDistance = _batteriesLevel / MaxRange;
        if (ProcentBateriNaJedenDistance > 0)
        {
            while (distance != 0)
            {
                distance--;
                _batteriesLevel = _batteriesLevel -ProcentBateriNaJedenDistance;
            }
            
            _mileage += distance;
            return _batteriesLevel;
        }
        return -1;
    }
    public override string ToString()
    {
        return $"Scooter{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}";
    }
}




//Koniec cwiczen


interface IAggregate
{
    IIterator CreateIterator();
}
interface IIterator
{
    bool HasNext();
    int GetNext();
}

class SimpleAggregate : IAggregate
{
    internal int a = 5;
    internal int b = 9;
    internal int c = 10;
    public IIterator CreateIterator()
    {
        return new SimpleAggregateIterator(this);
    }
}

class CovertSimpleAggregate : IAggregate
{
    internal int c = 10;
    internal int b = 9;

    internal int a = 5;


    public IIterator CreateIterator()
    {
        return new CovertSimpleAggregateIterator(this);
    }
}
class CovertSimpleAggregateIterator : IIterator
{
    private CovertSimpleAggregate _convertaggregate;
    private int count = 0;

    public CovertSimpleAggregateIterator(CovertSimpleAggregate convertaggregate)
    {
        _convertaggregate = convertaggregate;
    }

    public int GetNext()
    {
        switch (++count)
        {
            case 1:
                return _convertaggregate.a;
            case 2:
                return _convertaggregate.b;
            case 3:
                return _convertaggregate.c;
            default:
                throw new ArgumentException();
        }
    }

    public bool HasNext()
    {
        return count < 3;
    }
}

class SimpleAggregateIterator : IIterator
{
    private SimpleAggregate _aggregate;
    private int count = 0;
    public SimpleAggregateIterator(SimpleAggregate aggregate)
    {
        _aggregate = aggregate;
    }

    public int GetNext()
    {
        switch (++count)
        {
            case 1:
                return _aggregate.a;
            case 2:
                return _aggregate.b;
            case 3:
                return _aggregate.c;
            default:
                throw new ArgumentException();
        }
    }

    public bool HasNext()
    {
        return count < 3;
    }
}

class EmailMessage : AbstractMessage
{
    public string To { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }

    public override bool Send()
    {
        Console.WriteLine($"Sending email from {From} to {To} with content {Content}");
        return true;
    }
}
class MessengerMessage : AbstractMessage
{
    public string NameFrom { get; set; }
    public string NameTo { get; set; }

    public override bool Send()
    {
        Console.WriteLine($"Sending message using Messanger from {NameFrom}, to {NameTo} with content {Content}");
        return true;
    }
}

class SmsMessage : AbstractMessage
{
    public string ToPhone { get; init; }
    public string FromPhone { get; init; }
    public override bool Send()
    {
        Console.WriteLine($"Sending sms from {FromPhone} to { ToPhone} with content {Content}");
        return true;
    }
}

class User
{
    public string Name { get; init; }
    public AbstractMessage LastMessage { get; init; }

}


abstract class AbstractMessage
{
    public string Content { get; set; }
    public abstract bool Send();
}


public interface IFlyable
{
    void fly();
}

public interface ISwimmingable
{
    void swim();
}

public class Duck : IFlyable, ISwimmingable
{
    public string Name { set; get; }
    public string Size { set; get; }
    public void fly()
    {
        throw new NotImplementedException();
    }

    public void swim()
    {
        throw new NotImplementedException();
    }
}

public class Wasp : IFlyable
{
    public string Name { set; get; }
    public string Size { set; get; }
    public void fly()
    {
        throw new NotImplementedException();
    }
}

public class Hydroplane : IFlyable, ISwimmingable
{
    public string Name { set; get; }
    public string Size { set; get; }
    public void fly()
    {
        throw new NotImplementedException();
    }

    public void swim()
    {
        throw new NotImplementedException();
    }
}
