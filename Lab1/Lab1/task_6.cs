namespace task_6{
  class Program6{

            public class Animal
            {
                  public virtual void Sound()
                  {
                        Console.WriteLine("To zwierzę wydaje właśnie dźwięk:");
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
        
    
    public static void Run6(){
                  Animal voice1 = new Cat();
                  Animal voice2 = new Dog();
                  Animal voice3 = new Cow();

                  voice1.Sound();
                  voice2.Sound();
                  voice3.Sound();
      }
  }
}