// Task 1

Console.WriteLine("Podaj hasło!");
string password = Console.ReadLine();

do{
    if (password == "admin123")
    {
        Console.WriteLine("Podałeś prawidłowe hasło!");
    }
    else
    {
        Console.WriteLine("Podałeś nieprawidłowe hasło spróbuj ponownie!");
        password = Console.ReadLine();
        if (password == "admin123")
        {
            Console.WriteLine("Podałeś prawidłowe hasło!");
        }
    }
}while(password != "admin123");


// Task 2

Console.WriteLine("Podaj liczbę większą od zera!");
string positiveNumber = Console.ReadLine();
int okNumber = int.Parse(positiveNumber);
bool flag = true;

do
{
    
    if (okNumber > 0)
    {
        Console.WriteLine("Podałeś prawidłową liczbę!");
        flag = false;
    }
    else
    {
        if (okNumber == 0)
        {
            Console.WriteLine("Podałeś nieprawidłową liczbę - zero! Spróbuj ponownie!");
            positiveNumber = Console.ReadLine();
            okNumber = int.Parse(positiveNumber);
        }
        else
        {
            Console.WriteLine("Podałeś nieprawidłową liczbę - ujemną! Spróbuj ponownie!");
            positiveNumber = Console.ReadLine();
            okNumber = int.Parse(positiveNumber);
        }
    }

}while(flag);


// Task 3
string[] miasta = {"Warszawa","Berlin","Moskwa","Londyn","Oslo"}
;

foreach (string nazwy in miasta)
{
    Console.WriteLine(nazwy);
}
