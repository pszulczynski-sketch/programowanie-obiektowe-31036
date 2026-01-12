using System.Text.Json;

namespace Lab3
{
      public static class DeleteCar
      {
            public static void EraseCar(string carFile)
            {
                  Console.WriteLine("Podaj numer rejestracyjny auta, które chcesz usunąć!\n");

                  while (true)
                  {
                        string carToDelete = Console.ReadLine() ?? "";
                        Console.WriteLine("");
                        if (string.IsNullOrWhiteSpace(carToDelete))
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
                                    if(existingCars != null && existingCars.ContainsKey(carToDelete))
                                    {
                                          existingCars.Remove(carToDelete);

                                          string jsonSave = JsonSerializer.Serialize(existingCars);
                                          File.WriteAllText(carFile,jsonSave);

                                          Console.WriteLine("Auto zostało pomyślnie usunięte!\n");
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
                                    Console.WriteLine("Wystąpił błąd podczas usuwania danych z pliku! Spróbuj ponownie lub skontaktuj się z działem IT.\n");
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