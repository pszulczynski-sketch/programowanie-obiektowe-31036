using System.Text.Json;

namespace projekt_bank
{
      public class UpdateAccount : IPrintable
      {
            public Client CurrentClient {get;set;} = new Client();


            public string DocumentContent()
            {
                  string date = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                  return $@"
                  -------------------------------------------
                  POTWIERDZENIE AKTUALIZACJI DANYCH
                  -------------------------------------------
                  DATA: {date}
                  KLIENT: {CurrentClient.Name} {CurrentClient.Surname}
                  PESEL: {CurrentClient.Pesel}
                  ADRES: {CurrentClient.PlaceOfLive}, {CurrentClient.City}
                  SALDO: {CurrentClient.Balance}
                  -------------------------------------------";
            }


            private void SaveAndExit(string path)
            {
                  try
                  {
                        string updatedClient = JsonSerializer.Serialize(CurrentClient);
                        string folderPath = Path.GetDirectoryName(path) ?? "";
                        string confirmation = DocumentContent();

                        File.WriteAllText(path,updatedClient);
                        File.WriteAllText(Path.Combine(folderPath,"potwierdzenie-aktualizacji-konta.txt"),confirmation);

                        SuccessMessage.SMessage("Dane zostały pomyślnie zaktualizowane!");
                  }
                  catch (Exception)
                  {
                        FailMessage.FMessage("Wystąpił błąd podczas zapisu nowych danych klienta!");
                  }
            }


            public void UpdateExistingAccount()
            {
                  CurrentClient.Pesel = CheckPesel.Checked("PODAJ PESEL DO ZMIANY DANYCH: ");

                  string path = Path.Combine("Baza-danych",CurrentClient.Pesel,"dane.json");
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
                              CurrentClient = client;

                              bool editing = true;
                              while (editing)
                              {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"\n\t\tEDYCJA KLIENTA: {CurrentClient.Pesel}");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\t\t1. Imię: {CurrentClient.Name}");
                                    Console.WriteLine($"\t\t2. Nazwisko: {CurrentClient.Surname}");
                                    Console.WriteLine($"\t\t3. Adres zamieszkania: {CurrentClient.PlaceOfLive}");
                                    Console.WriteLine($"\t\t4. Miasto: {CurrentClient.City}");
                                    Console.WriteLine($"\t\t5. Zapisz i wyjdź");
                                    Console.WriteLine($"\t\t6. Anuluj");

                                    Console.Write("\n\t\tWYBRANA OPCJA: ");
                                    string choice = Console.ReadLine()?.Trim() ?? "";
                                    switch (choice)
                                    {
                                          case "1": CurrentClient.Name = IsDataEmpty.CheckData("NOWE IMIE: "); break;
                                          case "2": CurrentClient.Surname = IsDataEmpty.CheckData("NOWE NAZWISKO: "); break;
                                          case "3": CurrentClient.PlaceOfLive = IsDataEmpty.CheckData("NOWY ADRES ZAMIESZKANIA: "); break;
                                          case "4": CurrentClient.City = IsDataEmpty.CheckData("NOWE MIASTO: "); break;
                                          case "5": SaveAndExit(path); editing = false; break;
                                          case "6": Console.Beep(500,500); editing = false; break;
                                          default: Console.Clear(); Console.Beep(500,500); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\tNieprawidłowy wybór!"); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Green; Thread.Sleep(5000); break;
                                    }
                              }
                              return;
                        }
                        else
                        {
                              FailMessage.FMessage("Wystąpił błąd podczas odczytu danych klienta!");
                        }
                  }
                  catch (Exception)
                  {
                        FailMessage.FMessage("Wystąpił błąd podczas modyfikacji konta klienta!");
                  }
            }
      }
}