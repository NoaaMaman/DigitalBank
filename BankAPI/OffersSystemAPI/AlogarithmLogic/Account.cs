namespace OffersSystemAPI.AlogarithmLogic
{
    public class Account
    {
        public string Name;
        public double InterestRate;
        public int Term;
        public double Fee;


        public Account(string name, double interestRate, int term, double fee)
        {
            Name = name;
            InterestRate = interestRate;
            Term = term;
            Fee = fee;
        }
    }
}
