namespace task_2{
      public class Program2
      {
            public static void Run2()
            {
                  Console.WriteLine("Podaj liczbę większą od zera!");
                  string positiveNumber = Console.ReadLine();
                  int okNumber = int.Parse(positiveNumber);
                  bool flag = true;

                  do{
                        if (okNumber > 0)
                        {
                              Console.WriteLine("Podałeś prawidłową liczbę!");
                              flag = false;
                        }
                        else
                        {
                              if (okNumber == 0)
                              {
                                    Console.WriteLine("Podałeś nieprawidłową liczbę - zero! Spróbuj ponownie!");
                                    positiveNumber = Console.ReadLine();
                                    okNumber = int.Parse(positiveNumber);
                              }
                              else
                              {
                                    Console.WriteLine("Podałeś nieprawidłową liczbę - ujemną! Spróbuj ponownie!");
                                    positiveNumber = Console.ReadLine();
                                    okNumber = int.Parse(positiveNumber);
                              }
                        }
                  }while(flag);
            }
      }
}