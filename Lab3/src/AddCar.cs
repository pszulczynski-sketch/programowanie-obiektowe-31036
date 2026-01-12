using System.Text.Json;

namespace Lab3
{
      public class AddCar
      {
            private string Carbrand{get;set;} = "";
            private string CarEngine {get;set;} = "";
            private string CarHorsePower {get;set;} = "";
            private string CarRegistrationNumber {get;set;} = "";


            private string isCarRegistrationNumberUnique(string message, string file)
            {
                  Console.WriteLine($"{message}\n");

                  while (true)
                  {
                        string myInput = Console.ReadLine() ?? "";
                        Console.WriteLine("");
                        if (string.IsNullOrWhiteSpace(myInput))
                        {
                              Console.WriteLine("Proszę podać poprawny numer rejestracyjny auta!\n");
                              continue;
                        }

                        bool isUnique = true;
                        if (File.Exists(file))
                        {
                              try
                              {
                                    string jsonContent = File.ReadAllText(file);
                                    var existingCars = JsonSerializer.Deserialize<Dictionary<string,List<string>>>(jsonContent);
                                    if(existingCars != null && existingCars.ContainsKey(myInput))
                                    {
                                          isUnique = false;
                                    }
                              }
                              catch (Exception)
                              {
                                    Console.WriteLine("Wystąpił błąd podczas odczytywania danych z pliku! Spróbuj ponownie lub skontaktuj się z działem IT.\n");
                                    continue;
                              }
                        }

                        if(isUnique)
                        {
                              Console.WriteLine("Podany numer rejestracyjny auta został zaakceptowany!\n");
                              return myInput;
                        }
                        else
                        {
                              Console.WriteLine("Uwaga! Auto o podanym numerze rejestracyjnym już znajduje się na liście!\n");
                        }
                  }
            }


            public void AddNewCar(string carFile)
            {
                  Carbrand = isDataEmpty.CheckData("Podaj markę auta!");
                  CarEngine = isDataEmpty.CheckData("Podaj silnik auta!");
                  CarHorsePower = isDataEmpty.CheckData("Podaj ilość koni mechanicznych!");
                  CarRegistrationNumber = isCarRegistrationNumberUnique("Podaj numer rejestracyjny auta!",carFile);

                  try
                  {
                        Dictionary<string,List<string>> allCars;

                        if (File.Exists(carFile))
                        {
                              string jsonContent = File.ReadAllText(carFile);
                              allCars = JsonSerializer.Deserialize<Dictionary<string,List<string>>>(jsonContent) ?? new Dictionary<string, List<string>>();
                        }
                        else
                        {
                              allCars = new Dictionary<string, List<string>>();
                        }

                        List<string> allCarData = new List<string>{Carbrand,CarEngine,CarHorsePower};
                        allCars[CarRegistrationNumber] = allCarData;

                        string jsonSave = JsonSerializer.Serialize(allCars);
                        File.WriteAllText(carFile,jsonSave);

                        Console.WriteLine("Auto zostało pomyślnie dodane!\n");
                  }
                  catch (Exception)
                  {
                        Console.WriteLine("Wystąpił błąd podczas dodawania auta do pliku! Spróbuj ponownie lub skontaktuj się z działem IT.\n");
                  }

                  return;
            }
      }
}