namespace projekt_bank
{
      public abstract class UserMenu
      {
            protected string CurrentUserRole {get;set;} = "";

            public UserMenu(string role)
            {
                  CurrentUserRole = role;
            }

            protected void ShowHeader()
            {
                  Console.Clear();
                  Console.ForegroundColor = ConsoleColor.Cyan;
                  Console.WriteLine($"\n\t\tZALOGOWANO JAKO: {CurrentUserRole}");
                  Console.ResetColor();
                  Console.ForegroundColor = ConsoleColor.Green;
            }

            public abstract void DisplayOptions();
            public abstract void ChooseOption(string choice);

            public virtual void Run()
            {
                  bool isRunning = true;
                  while (isRunning)
                  {
                        ShowHeader();
                        DisplayOptions();
                        Console.Write("\n\t\tOPCJA: > ");
                        string choice = Console.ReadLine()?.Trim() ?? "";
                        if (choice == "0")
                        {
                              Console.Beep(1200, 100);
                              Console.Clear();
                              Console.WriteLine("\n\t\t WYLOGOWYWANIE...");
                              Thread.Sleep(5000);
                              Console.Clear();
                              isRunning = false;
                        }
                        else
                        {
                              ChooseOption(choice);
                        }
                  }
            }
      }


      public class CashierMenu : UserMenu
      {
            public CashierMenu() : base("KASJER"){}
            public override void DisplayOptions()
            {
                  Console.WriteLine("\t\t1. Lista Transakcji");
                  Console.WriteLine("\t\t2. Wpłata gotówki");
                  Console.WriteLine("\t\t3. Wypłata gotówki");
                  Console.WriteLine("\t\t0. Wyloguj");
            }

            public override void ChooseOption(string choice)
            {
                  switch (choice)
                  {
                        case "1": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ LISTA TRANSAKCJI ]"); TransactionList Transactions = new TransactionList(); Transactions.ShowHistory(); break;
                        case "2": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ WPŁATA GOTÓWKI ]"); DepositMoney MoreMoney = new DepositMoney(); MoreMoney.AddMoney(); break;
                        case "3": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ WYPŁATA GOTÓWKI ]"); PaycheckMoney LessMoney = new PaycheckMoney(); LessMoney.CollectMoney(); break;
                        default: Console.Clear(); Console.Beep(500,500); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\tNieprawidłowy wybór!"); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Green; Thread.Sleep(5000); break;
                  }
            }
      }


      public class ManagerMenu : UserMenu
      {
            public ManagerMenu() : base("KIEROWNIK"){}
            public override void DisplayOptions()
            {
                  Console.WriteLine("\t\t1. Lista Transakcji");
                  Console.WriteLine("\t\t2. Wpłata gotówki");
                  Console.WriteLine("\t\t3. Wypłata gotówki");
                  Console.WriteLine("\t\t4. Utworzenie konta bankowego");
                  Console.WriteLine("\t\t5. Aktualizacja danych klienta");
                  Console.WriteLine("\t\t0. Wyloguj");
            }

            public override void ChooseOption(string choice)
            {
                  switch (choice)
                  {
                        case "1": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ LISTA TRANSAKCJI ]"); TransactionList Transactions = new TransactionList(); Transactions.ShowHistory(); break;
                        case "2": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ WPŁATA GOTÓWKI ]"); DepositMoney MoreMoney = new DepositMoney(); MoreMoney.AddMoney(); break;
                        case "3": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ WYPŁATA GOTÓWKI ]"); PaycheckMoney LessMoney = new PaycheckMoney(); LessMoney.CollectMoney(); break;
                        case "4": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ UTWORZENIE KONTA ]"); CreateAccount Account = new CreateAccount(); Account.AddAccount(); break;
                        case "5": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ AKTUALIZACJA DANYCH ]"); UpdateAccount ExistsAccount = new UpdateAccount(); ExistsAccount.UpdateExistingAccount(); break;
                        default: Console.Clear(); Console.Beep(500,500); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\tNieprawidłowy wybór!"); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Green; Thread.Sleep(5000); break;
                  }
            }
      }


      public class DirectorMenu : UserMenu
      {
            public DirectorMenu() : base("DYREKTOR"){}
            public override void DisplayOptions()
            {
                  Console.WriteLine("\t\t1. Lista Transakcji");
                  Console.WriteLine("\t\t2. Wpłata gotówki");
                  Console.WriteLine("\t\t3. Wypłata gotówki");
                  Console.WriteLine("\t\t4. Utworzenie konta bankowego");
                  Console.WriteLine("\t\t5. Aktualizacja danych klienta");
                  Console.WriteLine("\t\t6. Udzielenie pożyczki");
                  Console.WriteLine("\t\t7. Zamknięcie systemu");
                  Console.WriteLine("\t\t0. Wyloguj");
            }

            public override void ChooseOption(string choice)
            {
                  switch (choice)
                  {
                        case "1": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ LISTA TRANSAKCJI ]"); TransactionList Transactions = new TransactionList(); Transactions.ShowHistory(); break;
                        case "2": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ WPŁATA GOTÓWKI ]"); DepositMoney MoreMoney = new DepositMoney(); MoreMoney.AddMoney(); break;
                        case "3": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ WYPŁATA GOTÓWKI ]"); PaycheckMoney LessMoney = new PaycheckMoney(); LessMoney.CollectMoney(); break;
                        case "4": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ UTWORZENIE KONTA ]"); CreateAccount Account = new CreateAccount(); Account.AddAccount(); break;
                        case "5": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ AKTUALIZACJA DANYCH ]"); UpdateAccount ExistsAccount = new UpdateAccount(); ExistsAccount.UpdateExistingAccount(); break;
                        case "6": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ UDZIELENIE POŻYCZKI ]"); LoanApplication NewLoan = new LoanApplication(); NewLoan.LoanResult(); break;
                        case "7": Console.Clear(); Console.Beep(1500,200); Console.WriteLine("\n\t\t[ ZAMKNIĘCIE SYSTEMU ]");  Environment.Exit(0); break;
                        default: Console.Clear(); Console.Beep(500,500); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n\t\tNieprawidłowy wybór!"); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Green; Thread.Sleep(5000); break;
                  }
            }
      }
}