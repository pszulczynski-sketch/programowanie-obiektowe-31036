namespace task_5{
  class Program5{

        public class Person
        {
            public double balance;
            public Person()
            {
                  this.balance = 0.00;
            }

                  public void Salary(double amount)
                  {
                        if (amount<=0)
                        {
                              Console.WriteLine("Kwota musi być dodatnia!");
                        } else if (balance>=amount)
                        {
                              balance -= amount;
                              Console.WriteLine("Wypłata została wykonana!");
                        } else
                        {
                              Console.WriteLine("Brak wystarczających środków!");
                        }
                  }
        }
        
    
    public static void Run5(){
            var add1 = new Person();
            var add2 = new Person();

            add1.balance = 1500.00;
            add2.balance = 500.00;

            add1.Salary(300.00);
            add2.Salary(1200.00);
            add1.Salary(-150.00);
        }
  }
}