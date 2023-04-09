namespace OffersSystemAPI.AlogarithmLogic
{
    public class DecisionTree
    {
        public static Graph _graph = new Graph();

        public static Account SuggestAccount(Customer customer)
        {
            //Use customer attributes to determine the best account offer
            if (customer.Age < 30 && customer.NumDependents == 0)
            {
                _graph.AddEdge("Start", "Youth Savings");
                return new Account("Youth Savings", 0.02, 12, 0);

            }
            else if (customer.Income < 50000 && customer.NumDependents == 0)
            {
                _graph.AddEdge("Start", "Basic Savings");
                return new Account("Basic Savings", 0.01, 12, 0);
            }
            else if (customer.CreditScore < 600 && customer.NumDependents == 0)
            {
                _graph.AddEdge("Start", "Basic Savings");
                return new Account("Credit Builder Savings", 0.03, 12, 0);
            }
            else if (customer.IsMarried &&
                customer.Income >= 100000 &&
                customer.SavingsBalance >= 1000 &&
                customer.NumCreditCards >= 2)
            {
                _graph.AddEdge("Start", "Joint High-Yield Savings");
                return new Account("Joint High-Yield Savings", 0.6, 12, 0);
            }
            else
            {
                return new Account("High-Yield Savings", 0.05, 12, 0);
            }
        }
    }
}
}
