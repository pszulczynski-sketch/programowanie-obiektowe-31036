namespace task_1{
      public class Program1
      {
            public static void Run1()
            {
                  Console.WriteLine("Podaj hasło!");
                  string password = Console.ReadLine();

                  do{
                        if (password == "admin123")
                        {
                              Console.WriteLine("Podałeś prawidłowe hasło!");
                        }else{
                              Console.WriteLine("Podałeś nieprawidłowe hasło spróbuj ponownie!");
                              password = Console.ReadLine();
                              if (password == "admin123")
                              {
                                    Console.WriteLine("Podałeś prawidłowe hasło!");
                              }
                        }
                  }while(password != "admin123");
            }
      }
}