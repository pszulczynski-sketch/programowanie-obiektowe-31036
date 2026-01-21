namespace projekt_bank
{
      public static class CheckPesel
      {
            public static string Checked(string message)
            {
                  while (true)
                  {
                        Console.Write($"\n\t\t{message}");
                        string MyPesel = Console.ReadLine()?.Trim() ?? "";
                        Console.WriteLine("");
                        if (string.IsNullOrWhiteSpace(MyPesel) || MyPesel.Length != 11)
                        {
                              FailMessage.FMessage("Proszę podać poprawne dane!");
                        }
                        else
                        {
                              SuccessMessage.SMessage("Podany pesel jest poprawny!");
                              return MyPesel;
                        }
                  }
            }
      }
}