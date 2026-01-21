namespace projekt_bank
{
    public class Transaction
    {
        public DateTime Date{get;set;}
        public string Type{get;set;} = "";
        public decimal Amount{get;set;} = 0;
        public decimal BalanceAfter{get;set;} = 0;
    }
}