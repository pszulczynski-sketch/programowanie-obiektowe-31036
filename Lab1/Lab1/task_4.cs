namespace task_4{
  class Program4{

        public class Person
        {
            public string name;
            public int age;
            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }

            public void IntroduceYourself()
            {
                Console.WriteLine("Mam na imię " + name + " oraz mój wiek to " + age);
            }

        }
        
    
    public static void Run4(){
        var add1 = new Person("Przemek",28);
        var add2 = new Person("Piotr",42);
        
        add1.IntroduceYourself();
        add2.IntroduceYourself();
        }
  }
}