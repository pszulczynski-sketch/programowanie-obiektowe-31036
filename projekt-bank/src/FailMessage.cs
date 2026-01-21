namespace projekt_bank
{
      public static class FailMessage
      {
            public static void FMessage(string message)
            {
                  Console.Beep(500,500);
                  Console.ForegroundColor = ConsoleColor.Red;
                  Console.WriteLine($"\n\t\t{message}");
                  Console.ResetColor();
                  Console.ForegroundColor = ConsoleColor.Green;
                  Thread.Sleep(5000);
                  Console.Clear();
            }
      }
}