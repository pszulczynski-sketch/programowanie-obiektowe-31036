namespace Lab3
{
      public static class isDataEmpty
      {
            public static string CheckData(string message)
            {
                  Console.WriteLine($"{message}\n");

                  while (true)
                  {
                        string myInput = Console.ReadLine() ?? "";
                        Console.WriteLine("");
                        if (string.IsNullOrWhiteSpace(myInput))
                        {
                              Console.WriteLine("Proszę podać poprawne dane!\n");
                        }
                        else
                        {
                              Console.WriteLine("Podane dane zostały zaakceptowane!\n");
                              return myInput;
                        }
                  }
            }
      }
}