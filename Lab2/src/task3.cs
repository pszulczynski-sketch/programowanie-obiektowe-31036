namespace Lab2
{
      interface IDrukowalne
      {
            void Drukuj();
      }


      class Dokument : IDrukowalne
      {
            public void Drukuj()
            {
                  Console.WriteLine("Drukarka drukuje dokument...");
            }
      }


      class Zdjecie : IDrukowalne
      {
            public void Drukuj()
            {
                  Console.WriteLine("Drukarka drukuje zdjęcie...");
            }
      }


      class task3
      {
            public static void Main3()
            {
                  IDrukowalne[] wydrukuj =
                  {
                        new Dokument(),
                        new Zdjecie()
                  };

                  foreach (IDrukowalne d in wydrukuj)
                  {
                        d.Drukuj();
                  }
            }
      }
}