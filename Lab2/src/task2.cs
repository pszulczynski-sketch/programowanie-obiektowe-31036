namespace Lab2
{
      abstract class Pojazd
      {
            public string Marka{get;set;}

            public abstract void UruchomSilnik();

            public void Info()
            {
                  Console.WriteLine($"Pojazd marki {Marka}");
            }
      }


      class Samochod : Pojazd
      {
            public override void UruchomSilnik()
            {
                  Console.WriteLine("Silnik samochodu został uruchomiony!");
            }
      }


      class Motocykl : Pojazd
      {
            public override void UruchomSilnik()
            {
                  Console.WriteLine("Motocykl odpala z głośnym dźwiękiem");
            }
      }

      class Ciezarowka : Pojazd
      {
            public override void UruchomSilnik()
            {
                  Console.WriteLine("Ciężarówka została odpalona z hukiem");
            }
      }


      class task2
      {
            public static void Main2()
            {
                  List<Pojazd> pojazdy = new List<Pojazd>
                  {
                        new Samochod(), new Motocykl(), new Ciezarowka()
                  };

                  foreach (Pojazd p in pojazdy)
                  {
                        p.Marka = "Mercedez";
                        p.UruchomSilnik();
                        p.Info();

                        Console.WriteLine("");
                  }
            }
      }
}