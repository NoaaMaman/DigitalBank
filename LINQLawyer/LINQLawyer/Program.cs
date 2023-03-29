using LINQLawyer;
using System.Linq.Expressions;
using System.Net.WebSockets;
//Our Data Model
var lawyers = new[]
{
    new Lawyer()
    {
        FirstName = "John",
        LastName = "Doe"
    },
    new Lawyer() 
    {
        FirstName = "Maria",
        LastName = "Maker"
    }

};
var clients = new[]
{
    new Client()
    {
        FirstName = "Tim",
        LastName = "Funny"
    },
    new Client()
    {
        FirstName = "Jim",
        LastName = "Decker"
    },
    new Client()
    {
        FirstName = "Yana",
        LastName = "Cat"
    }
};

var cases = new[]
{
    new Case()
    {
        Title = "Test",
        AmountInDispute = 10000,
        CaseType = CaseType.ProBono,
        client = clients[0],
        lawyer = lawyers[0]
    },
    new Case()
    {
        Title = "Death threat",
        AmountInDispute = 15000,
        CaseType = CaseType.Commercial,
        client = clients[1],
        lawyer = lawyers[1]
    },
    new Case()
    {
        Title = "Death threat",
        AmountInDispute = 1500,
        CaseType = CaseType.Commercial,
        client = clients[2],
        lawyer = lawyers[1]

    }
};

//Practice the Where clause
foreach (Lawyer lawyer in lawyers)
    lawyer.Cases = cases.Where(c => c.lawyer == lawyer).ToList();
//cases.Where(c => c.lawyer == lawyer). -> Returns IEnumberable->ToList
foreach(Client client in clients)
    client.Cases = cases.Where(c => c.client == client).ToList();

//First and Single
var workigFirstExample = lawyers.First(l => l.FirstName == "John");

try
{

    var firstExceptionExample = lawyers.First(l => l.FirstName == "John");


}
catch (InvalidOperationException ex)
{

    Console.WriteLine("Invalid operation exception has been thrown,  cause no matching elements found");
}

//FirstOrDefault returns the default value for the specified datatype,  if no matching was found.
//For classes that null and for value  tahts the defauilt value.
//For int is 0 for example.

var firstOfDefaultExample = lawyers.FirstOrDefault(l => l.FirstName == "Joh");


//Single works like First, but ensures, that only a single element matches the specified condition.
var workingSingleExample = lawyers.Single(l => l.FirstName == "John");

try
{
    var SingleExceptionExample = lawyers.Single(l => l.FirstName == "John");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Invalid operation exception has been thrown, cause no matching elements found.");
}

try
{
    var singleExceptionExample = lawyers.Single(l => l.FirstName == "Joh");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Invalid operation exception has been thrown, cause more than 1 element matches the condition");
}

//SingleOrDefault returns the default value for the specified datatype. if no matching element was found
//For classes thtas null and for value types thats the default value. for int is 0
//Everything else works just like this


//Any And all
var proBonoLawyers = lawyers.Where(l => l.Cases.Any(C => C.CaseType == CaseType.ProBono));
var commercialOnlyLawyers = lawyers.Where(l => l.Cases.All(c => c.CaseType == CaseType.Commercial));

//Working with numbers
var sumAmountInDispute = cases.Sum(c => c.AmountInDispute);
var averageAmountInDispute = cases.Average(c => c.AmountInDispute);
var minAmountInDispute = cases.Min(c => c.AmountInDispute);
var maxAmountInDispute = cases.Max(c => c.AmountInDispute);

//OrderBy
var lawyersByAmountInDisputeAsc = lawyers.OrderBy(l => l.Cases.Sum(c => c.AmountInDispute));
var lawyersByAmountInDisputeDesc = lawyers.OrderByDescending(l => l.Cases.Sum(c => c.AmountInDispute));


var caseTitles = cases.Select(c => c.Title);
var lawyerNames = lawyers.Select(l => l.FirstName + ", " + l.LastName);

//Select return a list of lists here
var casesPerLawyer = lawyers.Select(l => l.Cases);
//SelectMany returns a flattend list
var casesPerLawyerFlat = lawyers.SelectMany(l => l.Cases);

//Fluent - Chaining Linq Queries

var caseTitlesOfCommecialOnlyLawyers = lawyers
    .Where(l => l.Cases.All(c => c.CaseType == CaseType.Commercial))
    .SelectMany(l => l.Cases)
    .Select(c => c.Title);


