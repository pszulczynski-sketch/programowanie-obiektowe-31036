using System.Text.Json;

namespace projekt_bank
{
      public class TransactionList : IPrintable
      {
            public List<Transaction> History {get;set;} = new List<Transaction>();
            private string MyPesel {get;set;} = "";


            public string DocumentContent()
            {
                  string date = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                  string content = "-------------------------------------------";
                  content += "\nHISTORIA TRANSAKCJI";
                  content += "\n-------------------------------------------";
                  content += $"\nDATA: {date}";

                  foreach(var item in History)
                  {
                        content += $"\n{item.Date:dd.MM.yyyy HH:mm:ss} | {item.Type,-10} | {item.Amount,8} PLN | Saldo: {item.BalanceAfter,8} PLN";
                  }
                  content += "\n-------------------------------------------";

                  return content;
            }


            public void ShowHistory()
            {
                  MyPesel = CheckPesel.Checked("PODAJ PESEL DO LISTY TRANSAKCJI: ");

                  string folderPath = Path.Combine("Baza-danych",MyPesel);
                  if (!Directory.Exists(folderPath))
                  {
                        FailMessage.FMessage("Nie znaleziono klienta o takim peselu!");
                        return;
                  }
                  
                  string path = Path.Combine(folderPath,"historia-transakcji.json");
                  if (!File.Exists(path))
                  {
                        FailMessage.FMessage("Brak historii transakcji!");
                        return;
                  }

                  try
                  {
                        string jsonContent = File.ReadAllText(path);
                        History = JsonSerializer.Deserialize<List<Transaction>>(jsonContent)!;
                        if (History != null)
                        {
                              var lastTransactions = History.TakeLast(10);
                              foreach (var item in lastTransactions)
                              {
                                    Console.WriteLine($"{item.Date:dd.MM.yyyy HH:mm:ss} | {item.Type,-10} | {item.Amount,8} PLN | Saldo: {item.BalanceAfter,8} PLN\n\t");
                              }

                              string confirmation = DocumentContent();
                              File.WriteAllText(Path.Combine(folderPath,"wykaz-historii-transakcji.txt"),confirmation);

                              Console.Beep(1500,200);
                              Console.WriteLine($"\n\t\tHistoria transakcji została wysłana do wydruku!");
                              Console.WriteLine("\n\t\tNaciśnij dowolny klawisz, aby kontynuować...");
                              Console.ReadKey(true);
                              Console.Clear();
                        }
                        else
                        {
                              FailMessage.FMessage("Wystąpił błąd podczas odczytu transakcji klienta!");
                        }
                  }
                  catch(Exception)
                  {
                        FailMessage.FMessage("Wystąpił błąd podczas odczytu transakcji klienta!");
                  }

                  return;
            }
      }
}