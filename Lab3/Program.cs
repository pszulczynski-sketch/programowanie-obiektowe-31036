using Lab3;

Console.Title = "Komis samochodowy";
Console.WriteLine("Aplikacja obsługująca komis samochodowy\n\n");

string CarListFile = "ListaAut.json";

while (true)
{
      Console.WriteLine("Dodaj nowy pojazd -> DODAJ");
      Console.WriteLine("Zmodyfikuj określony pojazd -> MODYFIKUJ");
      Console.WriteLine("Usuń określony pojazd -> USUŃ");
      Console.WriteLine("Pokaż listę pojazdów -> LISTA");
      Console.WriteLine("Wyjdź z aplikacji -> WYJŚCIE\n\n");

      Console.WriteLine("Wpisz co chcesz zrobić:\n");

      string decision = Console.ReadLine() ?? "";
      Console.WriteLine("");
      switch (decision)
      {
            case "DODAJ": AddCar newCar = new AddCar(); newCar.AddNewCar(CarListFile); break;
            case "MODYFIKUJ": ModifyCar changeCar = new ModifyCar(); changeCar.ChangeData(CarListFile); break;
            case "USUŃ": DeleteCar.EraseCar(CarListFile); break;
            case "LISTA": ShowCars.DisplayAllCars(CarListFile); break;
            case "WYJŚCIE": Environment.Exit(0); break;
            default: Console.WriteLine("Nie rozpoznano wyboru! Wpisz odpowiednią komendę i zatwierdź klawiszem ENTER.\n"); break;
      }
}