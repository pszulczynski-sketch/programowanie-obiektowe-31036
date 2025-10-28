namespace task_8{
  class Program8{

            public class Vehicle
            {
                  public virtual void Start()
                  {
                        Console.WriteLine("Pojazd został uruchomiony!");
                        Console.WriteLine("");
                  }

                  public virtual void Ride(){}

                  public virtual void Load(){}
            }

            public class Car : Vehicle
            {
                  public override void Ride()
                  {
                        Console.WriteLine("Pojazd jedzienie!");
                        Console.WriteLine("");
                  }
            }

            public class ElectricCar : Vehicle
            {
                  public override void Load()
                  {
                        Console.WriteLine("Pojazd właśnie się ładuje!");
                        Console.WriteLine("");
                  }
            }
    
    public static void Run8(){
                  var start = new Vehicle();
                  Vehicle ride = new Car();
                  Vehicle load = new ElectricCar();

                  start.Start();
                  ride.Ride();
                  load.Load();
      }
  }
}