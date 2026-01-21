using System.Text.Json;

namespace projekt_bank
{
    public class LoanApplication : IPrintable
    {
        public List<Transaction> History {get;set;} = new List<Transaction>();
        private readonly List<string> Status = new List<string>{"Nie przyznano","Do sprawdzenia","Oczekujący","Przyznano"};
        private string FinalDecision {get;set;} = "";
        private string MyPesel {get;set;} = "";


        public string DocumentContent()
        {
            string date = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            int count = History.Count(item => item.Type == "WPŁATA");
            return $@"
            -------------------------------------------
            WNIOSEK O POŻYCZKĘ
            -------------------------------------------
            DATA: {date}
            ANALIZA: Na koncie odnotowano {count} wpłat.
            STATUS: {FinalDecision}
            -------------------------------------------";
        }


        public void LoanResult()
        {
            MyPesel = CheckPesel.Checked("PODAJ PESEL DO WNIOSKU O POŻYCZKĘ: ");

            string folderPath = Path.Combine("Baza-danych",MyPesel);
            if (!Directory.Exists(folderPath))
            {
                FailMessage.FMessage("Nie znaleziono klienta o takim peselu!");
                return;
            }

            string path = Path.Combine(folderPath,"historia-transakcji.json");
            if (!File.Exists(path))
            {
                FailMessage.FMessage("Brak możliwości udzielenia pożyczki przez brak transakcji!");
                return;
            }

            try
            {
                string jsonContent = File.ReadAllText(path);
                History = JsonSerializer.Deserialize<List<Transaction>>(jsonContent)!;
                if (History != null)
                {
                    int depositCount = History.Count(item => item.Type == "WPŁATA");
                    if (depositCount <= 10)
                    {
                        FinalDecision = Status[0];
                    }else if (depositCount <= 20)
                    {
                        FinalDecision = Status[1];
                    }else if (depositCount <= 30)
                    {
                        FinalDecision = Status[2];
                    }else
                    {
                        FinalDecision = Status[3];
                    }

                    string confirmation = DocumentContent();
                    File.WriteAllText(Path.Combine(folderPath,"wniosek-pożyczkowy.txt"),confirmation);
                    
                    SuccessMessage.SMessage($"Twój wniosek o pożyczkę otrzymał status - {FinalDecision}!");
                }
                else
                {
                    FailMessage.FMessage("Wystąpił błąd podczas odczytu transakcji klienta!");
                }
            }
            catch (Exception)
            {
                FailMessage.FMessage("Wystąpił błąd podczas odczytu transakcji klienta!");
            }

            return;
        }
    }
}