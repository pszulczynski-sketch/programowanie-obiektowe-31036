namespace projekt_bank
{
      public static class SuccessMessage
      {
            public static void SMessage(string message)
            {
                  Console.WriteLine($"\n\t\t{message}");
                  Console.Beep(1500,200);
                  Thread.Sleep(5000);
                  Console.Clear();
            }
      }
}