using projekt_bank;

BlockExit finish = new BlockExit();
finish.DisableCloseButton();

Console.Title = "SYSTEM OBSŁUGI TERMINALOWEJ V. 1.01";
Console.ForegroundColor = ConsoleColor.Green;
string header = @"
    ___________________________________________________________________________
   /                                                                           \
   |   #####################################################################   |
   |   ##                                                                 ##   |
   |   ##               ____       _        _   _   _  __                 ##   |
   |   ##              | __ )     / \      | \ | | | |/ /                 ##   |
   |   ##              |  _ \    / _ \     |  \| | | ' /                  ##   |
   |   ##              | |_) |  / ___ \    | |\  | | . \                  ##   |
   |   ##              |____/  /_/   \_\   |_| \_| |_|\_\                 ##   |
   |   ##                                                                 ##   |
   |   ##             SYSTEM OBSŁUGI TERMINALOWEJ V. 1.01                 ##   |
   |   #####################################################################   |
   \___________________________________________________________________________/
    ";
Console.WriteLine(header);

while (true)
{
    LogIn start = new LogIn();
    string whatUser = start.EnterTheSystem();

    UserMenu menu;
    switch (whatUser)
    {
        case "KASJER": menu = new CashierMenu(); break;
        case "KIEROWNIK": menu = new ManagerMenu(); break;
        case "DYREKTOR": menu = new DirectorMenu(); break;
        default: Console.ForegroundColor = ConsoleColor.Red; Console.Beep(500,500); Console.WriteLine("Nie rozpoznano roli użytkownika! Naciśnij dowolny klawisz, aby zamknąć konsolę..."); Console.ReadKey(true); Environment.Exit(0); return;
    }

    menu.Run();
}