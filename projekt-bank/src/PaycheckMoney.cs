using System.Text.Json;

namespace projekt_bank
{
      public class PaycheckMoney : IPrintable
      {
            public Client CurrentClient {get;set;} = new Client();
            private string MyPesel {get;set;} = "";


            public string DocumentContent()
            {
                  string date = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                  return $@"
                  -------------------------------------------
                  POTWIERDZENIE WYPŁATY ŚRODKÓW
                  -------------------------------------------
                  DATA: {date}
                  KLIENT: {CurrentClient.Name} {CurrentClient.Surname}
                  SALDO: {CurrentClient.Balance}
                  -------------------------------------------";
            }


            public void CollectMoney()
            {
                  MyPesel = CheckPesel.Checked("PODAJ PESEL DO WYPŁATY: ");

                  string path = Path.Combine("Baza-danych",MyPesel,"dane.json");
                  if (!File.Exists(path))
                  {
                        FailMessage.FMessage("Nie znaleziono klienta o takim peselu!");
                        return;
                  }

                  try
                  {
                        string jsonContent = File.ReadAllText(path);
                        var client = JsonSerializer.Deserialize<Client>(jsonContent);
                        if (client != null)
                        {
                              if (client.Balance == 0)
                              {
                                    FailMessage.FMessage("Brak środków na koncie!");
                                    return;
                              }

                              while (true)
                              {
                                    Console.Write("\n\t\tPODAJ KWOTĘ WYPŁATY: ");
                                    if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                                    {
                                          if (amount > client.Balance)
                                          {
                                                FailMessage.FMessage($"ODMOWA: Brak środków na koncie! (Dostępne: {client.Balance} PLN)");
                                          }
                                          else
                                          {
                                                client.Balance -= amount;
                                                CurrentClient = client;
                                                try
                                                {
                                                      string updatedJson = JsonSerializer.Serialize(client);
                                                      string confirmation = DocumentContent();
                                                      File.WriteAllText(path,updatedJson);
                                                      string folderPath = Path.GetDirectoryName(path) ?? "";
                                                      File.WriteAllText(Path.Combine(folderPath,"potwierdzenie-wypłaty.txt"),confirmation);
                                                      LogTransaction.NewLog(MyPesel,"WYPŁATA",amount,client.Balance);

                                                      SuccessMessage.SMessage($"Pomyślnie wypłacono {amount} PLN. Nowe saldo: {client.Balance} PLN");
                                                      break;
                                                }
                                                catch(Exception)
                                                {
                                                      FailMessage.FMessage("Wystąpił błąd podczas aktualizacji środków klienta!");
                                                      break;
                                                }
                                          }
                                    }
                                    else
                                    {
                                          FailMessage.FMessage("Podana kwota jest nieprawidłowa!");
                                    }
                              }
                        }
                        else
                        {
                              FailMessage.FMessage("Wystąpił błąd podczas odczytu danych klienta!");
                        }
                  }
                  catch (Exception)
                  {
                        FailMessage.FMessage("Wystąpił błąd podczas wypłaty środków z konta klienta!");
                  }

                  return;
            }
      }
}