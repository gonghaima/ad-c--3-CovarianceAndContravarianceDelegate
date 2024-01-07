namespace CovarianceAndContravarianceDelegate;

class Program
{
    delegate Car CarFactoryDel(int id, string name);
    delegate void LogICECarDetailsDel(ICECar car);
    delegate void LogEVCarDetailsDel(EVCar car);

    static void Main(string[] args)
    {
        CarFactoryDel carFactoryDel = CarFactory.ReturnICECar;

        Car iceCar = carFactoryDel(1, "Audi R8");

        Console.WriteLine($"Object type: {iceCar.GetType()}");
        Console.WriteLine($"Car Details: {iceCar.GetCarDetails()}");

        carFactoryDel = CarFactory.ReturnEvCar;
        Car evCar = carFactoryDel(2, "Tesla Model-3");

        Console.WriteLine();
        Console.WriteLine($"Object type: {evCar.GetType()}");
        Console.WriteLine($"Car Details: {evCar.GetCarDetails()}");

        Console.ReadKey();

    }
}

public static class CarFactory
{
    public static ICECar ReturnICECar(int id, string name)
    {
        return new ICECar { Id = id, Name = name };
    }
    public static EVCar ReturnEvCar(int id, string name)
    {
        return new EVCar { Id = id, Name = name };
    }
}

public abstract class Car
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public virtual string GetCarDetails()
    {
        return $"{Id} - {Name} ";
    }
}

public class ICECar : Car
{
    public override string GetCarDetails()
    {
        return $"{base.GetCarDetails()} - Internal Combustion Engine";
    }
}

public class EVCar : Car
{
    public override string GetCarDetails()
    {
        return $"{base.GetCarDetails()} - Electric";
    }
}


