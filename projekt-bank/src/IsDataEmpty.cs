namespace projekt_bank
{
      public static class IsDataEmpty
      {
            public static string CheckData(string message)
            {
                  while (true)
                  {
                        Console.Write($"\n\t\t{message}");
                        string myInput = Console.ReadLine()?.Trim() ?? "";
                        if (string.IsNullOrWhiteSpace(myInput))
                        {
                              FailMessage.FMessage("Proszę podać poprawne dane!");
                        }
                        else
                        {
                              SuccessMessage.SMessage("Podane dane zostały zaakceptowane!");
                              return myInput;
                        }
                  }
            }
      }
}