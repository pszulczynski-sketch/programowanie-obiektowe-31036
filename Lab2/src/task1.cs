namespace Lab2
{
      class Zwierze
      {
            public virtual void DajGlos()
            {
                  Console.WriteLine("Zwierzę wydaje dźwięk!");
            }
      }


      class Pies : Zwierze
      {
            public override void DajGlos()
            {
                  Console.WriteLine("Hau hau!");
            }
      }


      class Kot : Zwierze
      {
            public override void DajGlos()
            {
                  Console.WriteLine("Miau!");
            }
      }


      class Krowa : Zwierze
      {
            public override void DajGlos()
            {
                  Console.WriteLine("Muuu!");
            }
      }


      class task1
      {
            public static void Main1()
            {
                  Zwierze[] zwierzeta = {new Pies(), new Kot(), new Krowa()};

                  foreach (Zwierze z in zwierzeta)
                  {
                        z.DajGlos();
                  }
            }
      }
}