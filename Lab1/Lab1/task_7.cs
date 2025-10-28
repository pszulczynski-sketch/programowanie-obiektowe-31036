namespace task_7{
  class Program7{

            public class Animal
            {
                  public virtual void Sound()
                  {
                        Console.WriteLine("");
                  }
            }

            public class Cat : Animal
            {
                  public override void Sound()
                  {
                        base.Sound();
                        Console.WriteLine("Miauuuuu!");
                  }
            }

            public class Dog : Animal
            {
                  public override void Sound()
                  {
                        base.Sound();
                        Console.WriteLine("Hauuuuu!");
                  }
            }
            
            public class Cow : Animal
            {
                  public override void Sound()
                  {
                        base.Sound();
                        Console.WriteLine("Muuuuu!");
                  }
            }
        
    
    public static void Run7(){
            Animal[] animals = new Animal[] { new Cat(), new Dog(), new Cow(), new Cat(), new Dog(), new Cow() };
            Console.WriteLine("Zwierzęta dają głos po kolei po dwa razy!");

                  foreach (var variable in animals){
                        variable.Sound();
                  }
      }
  }
}