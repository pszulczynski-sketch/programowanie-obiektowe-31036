using System.Text.Json;

namespace projekt_bank
{
      public static class LogTransaction
      {
            public static void NewLog(string pesel, string type, decimal amount, decimal balanceAfter)
            {
                  string path = Path.Combine("Baza-danych",pesel,"historia-transakcji.json");
                  List<Transaction> history;

                  try
                  {
                        if (File.Exists(path))
                        {
                              string jsonContent = File.ReadAllText(path);
                              history = JsonSerializer.Deserialize<List<Transaction>>(jsonContent) ?? new List<Transaction>();
                        }
                        else
                        {
                              history = new List<Transaction>();
                        }

                        history.Add(new Transaction
                        {
                              Date = DateTime.Now,
                              Type = type,
                              Amount = amount,
                              BalanceAfter = balanceAfter
                        });

                        string updatedHistory = JsonSerializer.Serialize(history);
                        File.WriteAllText(path, updatedHistory);
                  }
                  catch (Exception)
                  {
                        FailMessage.FMessage("Wystąpił błąd podczas zapisu transakcji środków klienta!");
                  }
            }
      }
}