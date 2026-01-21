using System.Text.Json;

namespace projekt_bank
{
      public class DepositMoney : IPrintable
      {
            public Client CurrentClient {get;set;} = new Client();
            private string MyPesel {get;set;} = "";


            public string DocumentContent()
            {
                  string date = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                  return $@"
                  -------------------------------------------
                  POTWIERDZENIE WPŁATY ŚRODKÓW
                  -------------------------------------------
                  DATA: {date}
                  KLIENT: {CurrentClient.Name} {CurrentClient.Surname}
                  SALDO: {CurrentClient.Balance}
                  -------------------------------------------";
            }


            public void AddMoney()
            {
                  MyPesel = CheckPesel.Checked("PODAJ PESEL DO WPŁATY: ");

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
                              while (true)
                              {
                                    Console.Write("\n\t\tPODAJ KWOTĘ WPŁATY: ");
                                    if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                                    {
                                          client.Balance += amount;
                                          CurrentClient = client;
                                          try
                                          {
                                                string updatedJson = JsonSerializer.Serialize(client);
                                                string confirmation = DocumentContent();
                                                File.WriteAllText(path,updatedJson);
                                                string folderPath = Path.GetDirectoryName(path) ?? "";
                                                File.WriteAllText(Path.Combine(folderPath,"potwierdzenie-wpłaty.txt"),confirmation);
                                                LogTransaction.NewLog(MyPesel,"WPŁATA",amount,client.Balance);

                                                SuccessMessage.SMessage($"Pomyślnie wpłacono {amount} PLN. Nowe saldo: {client.Balance} PLN");
                                                break;
                                          }
                                          catch(Exception)
                                          {
                                                FailMessage.FMessage("Wystąpił błąd podczas aktualizacji środków klienta!");
                                                break;
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
                  catch(Exception)
                  {
                        FailMessage.FMessage("Wystąpił błąd podczas wpłaty środków na konto klienta!");
                  }

                  return;
            }
      }
}