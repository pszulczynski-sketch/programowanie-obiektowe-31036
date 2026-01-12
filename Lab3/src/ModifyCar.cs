using System.Text.Json;

namespace Lab3
{
      public class ModifyCar
      {
            private string newCarbrand{get;set;} = "";
            private string newCarEngine {get;set;} = "";
            private string newCarHorsePower {get;set;} = "";


            public void ChangeData(string carFile)
            {
                  Console.WriteLine("Podaj numer rejestracyjny auta, które chcesz zmodyfikować!\n");

                  while (true)
                  {
                        string searchCar = Console.ReadLine() ?? "";
                        Console.WriteLine("");
                        if (string.IsNullOrWhiteSpace(searchCar))
                        {
                              Console.WriteLine("Proszę podać poprawny numer rejestracyjny auta!\n");
                              continue;
                        }

                        if (File.Exists(carFile))
                        {
                              try
                              {
                                    string jsonContent = File.ReadAllText(carFile);
                                    var existingCars = JsonSerializer.Deserialize<Dictionary<string,List<string>>>(jsonContent);
                                    if(existingCars != null && existingCars.ContainsKey(searchCar))
                                    {
                                          Console.WriteLine("Co chcesz zmienić w podanym aucie?\n");
                                          Console.WriteLine("Zmodyfikuj markę auta -> MARKA");
                                          Console.WriteLine("Zmodyfikuj silnik auta -> SILNIK");
                                          Console.WriteLine("Zmodyfikuj ilość koni mechanicznych auta -> KONIE MECHANICZNE");
                                          Console.WriteLine("Anuluj operację modyfikacji -> ANULUJ\n");
                                          while (true)
                                          {
                                                string choice = Console.ReadLine() ?? "";
                                                Console.WriteLine("");
                                                switch (choice)
                                                {
                                                      case "MARKA": newCarbrand = isDataEmpty.CheckData("Podaj nową markę auta!"); existingCars[searchCar][0] = newCarbrand; break;
                                                      case "SILNIK": newCarEngine = isDataEmpty.CheckData("Podaj nowy silnik auta!"); existingCars[searchCar][1] = newCarEngine; break;
                                                      case "KONIE MECHANICZNE": newCarHorsePower = isDataEmpty.CheckData("Podaj nową ilość koni mechanicznych auta!"); existingCars[searchCar][2] = newCarHorsePower; break;
                                                      case "ANULUJ": return;
                                                      default: Console.WriteLine("Nie rozpoznano wyboru! Wpisz odpowiednią komendę i zatwierdź klawiszem ENTER.\n"); continue;
                                                }
                                                break;
                                          }

                                          string jsonSave = JsonSerializer.Serialize(existingCars);
                                          File.WriteAllText(carFile,jsonSave);

                                          Console.WriteLine("Auto zostało pomyślnie zmodyfikowane!\n");
                                          return;
                                    }
                                    else
                                    {
                                          Console.WriteLine("Auto o podanym numerze rejestracyjnym nie istnieje!\n");
                                          continue;
                                    }
                              }
                              catch (Exception)
                              {
                                    Console.WriteLine("Wystąpił błąd podczas modyfikowania danych w pliku! Spróbuj ponownie lub skontaktuj się z działem IT.\n");
                                    continue;
                              }
                        }
                        else
                        {
                              Console.WriteLine("Plik z listą aut nie został znaleziony!\n");
                              return;
                        }
                  }
            }
      }
}