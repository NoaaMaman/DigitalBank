namespace OffersSystemAPI.AlogarithmLogic
{
    public class Customer
    {
        public int Age;
        public double Income;
        public int CreditScore;
        public bool IsMarried;
        public int NumDependents;
        public double SavingsBalance;
        public double CheckingBalance;
        public double CreditCardBalance;
        public int NumCreditCards;
        public bool HasAutoLoan;
        public bool HasStudentLoan;
        public bool HasMortgage;
        public bool HasPersonalLoan;

        public Customer(int age, double income, int creditScore, bool isMarried, int numDependents,
                        double savingsBalance, double checkingBalance, double creditCardBalance,
                        int numCreditCards, bool hasAutoLoan, bool hasStudentLoan,
                        bool hasMortgage, bool hasPersonalLoan)
        {
            Age = age;
            Income = income;
            CreditScore = creditScore;
            IsMarried = isMarried;
            NumDependents = numDependents;
            SavingsBalance = savingsBalance;
            CheckingBalance = checkingBalance;
            CreditCardBalance = creditCardBalance;
            NumCreditCards = numCreditCards;
            HasAutoLoan = hasAutoLoan;
            HasStudentLoan = hasStudentLoan;
            HasMortgage = hasMortgage;
            HasPersonalLoan = hasPersonalLoan;
        }
    }
}
