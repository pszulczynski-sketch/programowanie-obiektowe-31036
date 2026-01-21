using System.Text.Json;

namespace projekt_bank
{
      public class CreateAccount : IPrintable
      {
            public Client CurrentClient {get;set;} = new Client();


            public string DocumentContent()
            {
                  string date = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                  return $@"
                  -------------------------------------------
                  POTWIERDZENIE UTWORZENIA KONTA
                  -------------------------------------------
                  DATA: {date}
                  KLIENT: {CurrentClient.Name} {CurrentClient.Surname}
                  PESEL: {CurrentClient.Pesel}
                  ADRES: {CurrentClient.PlaceOfLive}, {CurrentClient.City}
                  SALDO: {CurrentClient.Balance}
                  -------------------------------------------";
            }


            private string? isPeselUnique(string message)
            {
                  while (true)
                  {
                        Console.Write($"\n\t\t{message}");
                        string myInput = Console.ReadLine()?.Trim() ?? "";
                        Console.WriteLine("");
                        if (string.IsNullOrWhiteSpace(myInput) || myInput.Length != 11)
                        {
                              FailMessage.FMessage("Proszę podać poprawne dane!");
                              continue;
                        }

                        string folderPath = Path.Combine("Baza-danych",myInput);

                        if (Directory.Exists(folderPath))
                        {
                              FailMessage.FMessage("Ten pesel znajduje się już w bazie danych!");
                              return null;
                        }
                        else
                        {
                              SuccessMessage.SMessage("Podany pesel został zaakceptowany!");
                              return myInput;
                        }
                  }
            }


            public void AddAccount()
            {
                  CurrentClient.Pesel = isPeselUnique("PESEL: ")!;
                  if (CurrentClient.Pesel != null)
                  {
                        CurrentClient.Name = IsDataEmpty.CheckData("IMIE: ");
                        CurrentClient.Surname = IsDataEmpty.CheckData("NAZWISKO: ");
                        CurrentClient.PlaceOfLive = IsDataEmpty.CheckData("ADRES ZAMIESZKANIA: ");
                        CurrentClient.City = IsDataEmpty.CheckData("MIASTO: ");

                        Console.Write($"\n\t\tPODANE DANE:\n\n\t\tPESEL: {CurrentClient.Pesel} \n\t\tIMIE: {CurrentClient.Name} \n\t\tNAZWISKO: {CurrentClient.Surname} \n\t\tADRES ZAMIESZKANIA: {CurrentClient.PlaceOfLive} \n\t\tMIASTO: {CurrentClient.City}\n\n\t\t Czy podane dane się zgadzają (TAK/NIE)? ");
                        string decision = Console.ReadLine()?.ToUpper()?.Trim() ?? "";

                        if (decision == "TAK")
                        {
                              string path = Path.Combine("Baza-danych",CurrentClient.Pesel);
                              try
                              {
                                    Directory.CreateDirectory(path);

                                    string newClient = JsonSerializer.Serialize(CurrentClient);
                                    string confirmation = DocumentContent();

                                    File.WriteAllText(Path.Combine(path,"dane.json"),newClient);
                                    File.WriteAllText(Path.Combine(path,"potwierdzenie-założenia-konta.txt"),confirmation);

                                    SuccessMessage.SMessage("Konto klienta zostało utworzone!");
                              }
                              catch (Exception)
                              {
                                    FailMessage.FMessage("Wystąpił błąd podczas tworzenia konta klienta!");
                              }
                        }
                        else
                        {
                              FailMessage.FMessage("Anulowano tworzenie konta!");
                        }
                  }
                  
                  return;
            }
      }
}