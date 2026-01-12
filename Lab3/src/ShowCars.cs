using System.Text.Json;

namespace Lab3
{
      public static class ShowCars
      {
            public static void DisplayAllCars(string carFile)
            {     
                  if (File.Exists(carFile))
                  {
                        try
                        {
                              string jsonContent = File.ReadAllText(carFile);
                              var carList = JsonSerializer.Deserialize<Dictionary<string,List<string>>>(jsonContent);
                              if(carList != null && carList.Count > 0)
                              {
                                    int number = 1;
                                    foreach (var car in carList)
                                    {
                                          Console.WriteLine($"Auto numer: {number}");
                                          Console.WriteLine($"Numer rejestracyjny auta: {car.Key}");
                                          Console.WriteLine($"Marka auta: {car.Value[0]}");
                                          Console.WriteLine($"Silnik auta: {car.Value[1]}");
                                          Console.WriteLine($"Konie mechaniczne auta: {car.Value[2]}\n");
                                          number++;
                                    }
                              }
                              else
                              {
                                    Console.WriteLine("Plik jest pusty i nie zawiera żadnych aut!\n");
                              }
                        }
                        catch (Exception)
                        {
                              Console.WriteLine("Wystąpił błąd podczas wczytywania danych z pliku! Spróbuj ponownie lub skontaktuj się z działem IT.\n");
                        }
                  }
                  else
                  {
                        Console.WriteLine("Plik z listą aut nie został znaleziony!\n");
                  }

                  return;
            }
      }
}