using System.Text.Json;

namespace projekt_bank
{
      public class LogIn
      {
            private string _login = "";
            private string login
            {
                  get => _login;
                  set
                  {
                        if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                        {
                              throw new Exception("Login musi mieć co najmniej 5 znaków!");
                        }
                        _login = value;
                  }
            }


            private string _password = "";
            private string password
            {
                  get => _password;
                  set
                  {
                        if (string.IsNullOrWhiteSpace(value) || value.Length < 10)
                        {
                              throw new Exception("Hasło musi mieć co najmniej 10 znaków!");
                        }
                        _password = value;
                  }
            }


            private string GetHiddenConsoleInput()
            {
                  string myPassword = "";
                  while (true)
                  {
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                        {
                              break;
                        }

                        if (key.Key == ConsoleKey.Backspace && myPassword.Length > 0)
                        {
                              myPassword = myPassword.Remove(myPassword.Length - 1);
                        }else if (key.Key != ConsoleKey.Backspace)
                        {
                              myPassword += key.KeyChar;
                        }
                  }
                  return myPassword;
            }


            public string EnterTheSystem()
            {
                  Console.WriteLine("\n\t\t[ ZALOGUJ SIĘ DO SYSTEMU ]");

                  while (true)
                  {
                        Console.Write("\n\t\tIDENTYFIKATOR OPERATORA: > ");
                        string inputLogin = Console.ReadLine()?.ToUpper() ?? "";
                  
                        Console.Write("\n\t\tHASŁO OPERATORA: > ");
                        string inputPassword = GetHiddenConsoleInput();

                        try
                        {
                              login = inputLogin;
                              password = inputPassword;

                              string jsonFile = "users.json";
                              if (!File.Exists(jsonFile))
                              {
                                    throw new Exception("Brak pliku bazy danych!");
                              }
                              string jsonContent = File.ReadAllText(jsonFile);
                              var users = JsonSerializer.Deserialize<Dictionary<string,string>>(jsonContent);

                              if (users != null && users.ContainsKey(login))
                              {
                                    if (BCrypt.Net.BCrypt.Verify(password,users[login]))
                                    {
                                          string role = new string(login.Where(char.IsLetter).ToArray());

                                          Console.Clear();
                                          Console.ForegroundColor = ConsoleColor.Yellow;
                                          Console.Beep(1500,200);
                                          Console.WriteLine($"\n\t\t POMYŚLNA AUTORYZACJA, RANGA: {role}");
                                          Console.ResetColor();
                                          Console.ForegroundColor = ConsoleColor.Green;
                                          Thread.Sleep(6000);

                                          return role;
                                    }
                              }
                              throw new Exception("Błędny identyfikator lub hasło operatora!");
                        }
                        catch (Exception ex)
                        {
                              Console.Clear();
                              Console.ForegroundColor = ConsoleColor.Red;
                              Console.Beep(500,500);
                              Console.WriteLine($"\n\t\t BŁĄD: {ex.Message}");
                              Console.ResetColor();
                              Console.ForegroundColor = ConsoleColor.Green;
                        }
                  }
            }
      }
}