namespace Lab2
{
      abstract class Zwierze2
      {
            public string Nazwa{get;set;}

            public abstract void WydajDzwiek();
      }


      interface IKarmione
      {
            void Jedz();
      }


      interface ITrenowane
      {
            void Trenuj();
      }


      class Lew : Zwierze2, IKarmione, ITrenowane
      {
            public override void WydajDzwiek()
            {
                  Console.WriteLine("Lew: Roooar!");
            }

            public void Jedz()
            {
                  Console.WriteLine("Lew je mięso.");
            }

            public void Trenuj()
            {
                  Console.WriteLine("Lew trenuje skoki!");
            }
      }


      class Slon : Zwierze2, IKarmione, ITrenowane
      {
            public override void WydajDzwiek()
            {
                  Console.WriteLine("Słoń: Truuu!");
            }

            public void Jedz()
            {
                  Console.WriteLine("Słoń je trawę.");
            }

            public void Trenuj()
            {
                  Console.WriteLine("Słoń trenuje trąbienie!");
            }
      }


      class Papuga : Zwierze2, IKarmione, ITrenowane
      {
            public override void WydajDzwiek()
            {
                  Console.WriteLine("Papuga: Witaj!");
            }

            public void Jedz()
            {
                  Console.WriteLine("Papuga je ziarno.");
            }

            public void Trenuj()
            {
                  Console.WriteLine("Papuga trenuje mówienie!");
            }
      }


      class Tygrys : Zwierze2, IKarmione, ITrenowane
      {
            public override void WydajDzwiek()
            {
                  Console.WriteLine("Tygrys: RRRR!");
            }

            public void Jedz()
            {
                  Console.WriteLine("Tygrys je inne zwierzęta.");
            }

            public void Trenuj()
            {
                  Console.WriteLine("Tygrys trenuje polowanie!");
            }
      }


      class task4
      {
            public static void Main4()
            {
                  List<Zwierze2> zwierzeta = new List<Zwierze2>
                  {
                        new Lew{Nazwa = "Simba"},
                        new Slon{Nazwa = "Dumbo"},
                        new Papuga{Nazwa = "Polly"},
                        new Tygrys{Nazwa = "Król"}
                  };

                  foreach (Zwierze2 z in zwierzeta)
                  {
                        Console.WriteLine($"Zwierzę: {z.Nazwa}");
                        z.WydajDzwiek();

                        if (z is IKarmione karmione)
                        {
                              karmione.Jedz();
                        }

                        if (z is ITrenowane trenowane)
                        {
                              trenowane.Trenuj();
                        }

                        Console.WriteLine();
                  }
            }
      }
}