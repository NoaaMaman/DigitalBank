using System;
using System.Collections.Generic;

namespace Alogarithm
{
    public class Program
    {
        /*This function take as input a string node , which represent an account type ,
         A dictionary offers which contains offers for each account type
        A dictionary customers which containing information about the customer,
        A list transactions containing the customers trnsactions*
        The functions returns double value which representing the score of the offer associated 
        with the account type specified by node*/
        public static double EvaluateNode(string node, Dictionary<string, Dictionary<string, dynamic>> offers, Dictionary<string, dynamic> customer, List<Dictionary<string, dynamic>> transactions)
        {
            if (!offers.ContainsKey(node))
            {
                return 0;
            }
            double score = 0.0;
            // Determine the offer associated with the current node
            Dictionary<string, dynamic> offer = offers[node];
            if (offer == null)
            {
                return score;
            }
            // Evaluate the customer's eligibility for the offer
            if (offer.ContainsKey("minimumAge") && customer["age"] < offer["minimumAge"])
            {
                return double.MinValue;
            }

            if (offer.ContainsKey("dependents") && customer["dependents"] < offer["dependents"])
            {
                return double.MinValue;
            }

            if (offer.ContainsKey("minimumBalance") && customer.ContainsKey("balance") && customer["balance"] < offer["minimumBalance"])
            {
                return double.MinValue;
            }

            if (offer.ContainsKey("salary") && customer["salary"] < offer["salary"])
            {
                return double.MinValue;
            }

            if (offer.ContainsKey("creditScore") && customer["creditScore"] < offer["creditScore"])
            {
                return double.MinValue;
            }

            if (offer.ContainsKey("hasCreditCard") && !(bool)customer["hasCreditCard"])
            {
                return double.MinValue;
            }

            // Evaluate the profitability of the offer
            if (offer.ContainsKey("interestRate"))
            {
                score += offer["interestRate"] * 1000;
            }

            if (offer.ContainsKey("monthlyFee"))
            {
                score -= offer["monthlyFee"] * 100;
            }

            if (transactions != null && offer.ContainsKey("cashbackPercentage"))
            {
                double totalCashback = 0.0;
                foreach (Dictionary<string, dynamic> transaction in transactions)
                {
                    if (transaction.ContainsKey("accountType") && transaction["accountType"] == node && transaction.ContainsKey("amount"))
                    {
                        totalCashback += transaction["amount"] * offer["cashbackPercentage"];
                    }
                }
                score += totalCashback;
            }

            return score;


        }
        /*Takes as input a grpah representing the possible paths through the different 
         account types anb the associated weights(The cost to move from, one account to another),
        A dictionary of offers containign offers for each account type,
        A dictionary customers containing information about the customer ,
        list of transactions containing the customer trasnsactions
        The fucntion return the string value representing the account type that provides the 
        best offer to the customer eligbility for each offer and the profitability for each offer*/
        public static string FindBestOffer(Dictionary<string, Dictionary<string, int>> graph, Dictionary<string, Dictionary<string, dynamic>> offers, Dictionary<string, dynamic> customer, List<Dictionary<string, dynamic>> transactions)
        {
            Dictionary<string, int> neighbors;
            string currentNode = "start";
            while (true)
            {
                if (currentNode == "end")
                {
                    break;
                }
                neighbors = graph[currentNode];
                string bestNeighbor = "";
                double bestScore = double.MinValue;

                foreach (KeyValuePair<string, int> neighbor in neighbors)
                {
                    string neighborNode = neighbor.Key;
                    int weight = neighbor.Value;

                    // Evaluate the score of the neighbor node
                    double score = EvaluateNode(neighborNode, offers, customer, transactions);
                    score /= weight;

                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestNeighbor = neighborNode;
                    }
                }

                currentNode = bestNeighbor;

                if (currentNode == "end")
                {
                    break;
                }
            }

            return currentNode;
        }
        //Types of accoutns : start, youth, savings, high-yield,retirement
        static void Main(string[] args)
        {
            // Initialize the graph
            Dictionary<string, Dictionary<string, int>> graph = new Dictionary<string, Dictionary<string, int>>();
            graph.Add("start", new Dictionary<string, int>());
            graph["start"].Add("youth", 1);
            graph["start"].Add("savings", 2);

            graph.Add("youth", new Dictionary<string, int>());
            graph["youth"].Add("high-yield", 3);
            graph["youth"].Add("retirement", 10);

            graph.Add("savings", new Dictionary<string, int>());
            graph["savings"].Add("high-yield", 1);
            graph["savings"].Add("retirement", 5);

            graph.Add("high-yield", new Dictionary<string, int>());
            graph["high-yield"].Add("end", 1);

            graph.Add("retirement", new Dictionary<string, int>());
            graph["retirement"].Add("end", 5);

            // Initialize the hash table of account offers
            Dictionary<string, Dictionary<string, dynamic>> offers = new Dictionary<string, Dictionary<string, dynamic>>();
            offers.Add("youth", new Dictionary<string, dynamic>());
            offers["youth"].Add("interestRate", 0.02);
            offers["youth"].Add("monthlyFee", 0);
            offers["youth"].Add("minimumAge", 18);
            offers.Add("savings", new Dictionary<string, dynamic>());
            offers["savings"].Add("interestRate", 0.05);
            offers["savings"].Add("monthlyFee", 10);
            offers["savings"].Add("minimumBalance", 5000);
            offers.Add("high-yield", new Dictionary<string, dynamic>());
            offers["high-yield"].Add("interestRate", 0.1);
            offers["high-yield"].Add("monthlyFee", 25);
            offers["high-yield"].Add("minimumBalance", 25000);
            offers.Add("retirement", new Dictionary<string, dynamic>());
            offers["retirement"].Add("interestRate", 0.07);
            offers["retirement"].Add("monthlyFee", 0);
            offers["retirement"].Add("minimumAge", 55);

            // Initialize the customer's attributes and past transactions
            Dictionary<string, dynamic> customer = new Dictionary<string, dynamic>();
            customer.Add("age", 25);
            customer.Add("dependents", 0);
            customer.Add("salary", 40000);
            customer.Add("creditScore", 700);
            customer.Add("hasCreditCard", true);
            List<Dictionary<string, dynamic>> transactions = new List<Dictionary<string, dynamic>>();
            transactions.Add(new Dictionary<string, dynamic>() { { "type", "deposit" }, { "amount", 5000 }, { "accountType", "savings" } });

            // Run the algorithm
            string bestOffer = FindBestOffer(graph, offers, customer, transactions);
            Console.WriteLine("The best offer for the customer is: " + bestOffer);
        }
    }
}
