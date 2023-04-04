using BankAPI.DAL;
using BankAPI.Services.Interfaces;
using BankAPI.Utility;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System.Text.Json.Serialization;
using Response = BankAPI.Models.Response;



namespace BankAPI.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private youBankingDbContext _dbContext;
        ILogger<TransactionService> _Logger;
        private AppSettings _settings;
        private static string _ourBankSettelmentAccount;
        private readonly IAccountService _accountService;
        public TransactionService(youBankingDbContext dbContext, ILogger<TransactionService> logger, IOptions<AppSettings> settings,IAccountService accountService)
        {
            _dbContext = dbContext;
            _Logger = logger;
            _settings = settings.Value;
            _ourBankSettelmentAccount = _settings.OurBankSettlementAccount;
            _accountService = accountService;
        }
        Response ITransactionService.CreateNewTransaction(Transaction transaction)
        {
           //Create New Transaction
           Response response = new Response();
            _dbContext.SaveChanges();
            response.ResponseCode = "00";
            response.ResponseMessage = "Transaction created Successfully";
            response.Data = null;

            return response;

        }
        

        Response ITransactionService.FindTransactionByDate(DateTime date)
        {
            Response response = new Response();
            var transaction = _dbContext.Transactions.Where(x => x.TransactionDate == date).ToList();
            response.ResponseCode = "00";
            response.ResponseMessage = "Transaction created Successfully";
            response.Data = null;

            return response;
        }

        public Response MakeDeposite(string AccountNumber, decimal Amount, string TransactionPin)
        {
            Response response = new Response();
            Account sourceAccount;
            Account destinationAccount;
            Transaction transaction = new Transaction();

            //First check if the user  - account owner is valid
            //we'll need authenticate in UserService, so let's inject IUserService Here
            var authUser = _accountService.Authenticate(AccountNumber, TransactionPin);

            if (authUser == null) throw new ApplicationException("Invalid Credentials");

            try
            {
                //or deposite, our bankSettlemenAccount is the source giving mouney to the user's account
                sourceAccount = _accountService.GetByNumber(_ourBankSettelmentAccount);
                destinationAccount = _accountService.GetByNumber(AccountNumber);

                //Now let's update their account balances
                sourceAccount.CurrentAccountBalance -= Amount;
                destinationAccount.CurrentAccountBalance += Amount;


                if ((_dbContext.Entry(sourceAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified) &&
                    (_dbContext.Entry(destinationAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified))
                {
                    //so transaction successful
                    transaction.TrnsactionStatus = TransStatus.Success;
                    response.ResponseCode = "02";
                    response.ResponseMessage = "Transaction successful!";
                    response.Data = null;
                }
                else
                {
                    //so transaction unsuccessful
                    transaction.TrnsactionStatus = TransStatus.Failed;
                    response.ResponseCode = "02";
                    response.ResponseMessage = "Transaction failed!";
                    response.Data = null;
                }

                
            }
            catch (Exception ex)
            {
                _Logger.LogError($"N ERROR OCCURRED..... =>{ex.Message}");
                //Set response object in case of exception
                //response.ResponseCode = "01";
                //response.ResponseMessage = "Transaction failed due to an error!";
                //response.Data = null;
            }
            transaction.TransactionType = TransType.Deposite;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionAmount = Amount;
            transaction.TrnsactionSourceAccount = _ourBankSettelmentAccount;
            transaction.TransactionDestinationAccount = AccountNumber;


            //set other props of transaction here
                transaction.TrnsactionParticulars = $"NEW TRANSACTION FROM SOURCE => {System.Text.Json.JsonSerializer.Serialize(transaction.TrnsactionSourceAccount)} To Destination Account => {System.Text.Json.JsonSerializer.Serialize(transaction.TransactionDestinationAccount)} ON DATE => {transaction.TransactionDate} FOR AMOUNT => {System.Text.Json.JsonSerializer.Serialize(transaction.TransactionAmount)} TRANSACTION TYPE =>{System.Text.Json.JsonSerializer.Serialize(transaction.TransactionType)} TRANSACTION STATUS =>{System.Text.Json.JsonSerializer.Serialize(transaction.TrnsactionStatus)}";

            //Add the transaction to the context and save changes
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
        }


        Response ITransactionService.MakeFundsTransfer(string FromAccount, string ToAccount, decimal Amount, string TransactionPin)
        {
            Response response = new Response();
            Account sourceAccount;
            Account destinationAccount;
            Transaction transaction = new Transaction();

            //First check if the user  - account owner is valid
            //we'll need authenticate in UserService, so let's inject IUserService Here
            var authUser = _accountService.Authenticate(FromAccount, TransactionPin);
            if (authUser == null) throw new ApplicationException("Invalid Credentials");

            try
            {
                //or deposite, our bankSettlemenAccount is the detination geting mouney from the user's account
                sourceAccount = _accountService.GetByNumber(FromAccount);
                destinationAccount = _accountService.GetByNumber(ToAccount);

                //Now let's update their account balances
                sourceAccount.CurrentAccountBalance -= Amount;
                destinationAccount.CurrentAccountBalance += Amount;



                if ((_dbContext.Entry(sourceAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified) &&
                    (_dbContext.Entry(destinationAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified))
                {
                    //so transaction successful
                    transaction.TrnsactionStatus = TransStatus.Success;
                    response.ResponseCode = "00";
                    response.ResponseMessage = "Transaction successful!";
                    response.Data = null;
                }
                else
                {
                    //so transaction unsuccessful
                    transaction.TrnsactionStatus = TransStatus.Failed;
                    response.ResponseCode = "02";
                    response.ResponseMessage = "Transaction failed!";
                    response.Data = null;
                }

                //set other props of transaction here
                transaction.TrnsactionParticulars = $"NEW TRANSACTION FROM SOURCE => {System.Text.Json.JsonSerializer.Serialize(transaction.TrnsactionSourceAccount)} To Destination Account => {System.Text.Json.JsonSerializer.Serialize(transaction.TransactionDestinationAccount)} ON DATE => {transaction.TransactionDate} FOR AMOUNT => {System.Text.Json.JsonSerializer.Serialize(transaction.TransactionAmount)} TRANSACTION TYPE =>{System.Text.Json.JsonSerializer.Serialize(transaction.TransactionType)} TRANSACTION STATUS =>{System.Text.Json.JsonSerializer.Serialize(transaction.TrnsactionStatus)}";

                //Add the transaction to the context and save changes
                _dbContext.Transactions.Add(transaction);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _Logger.LogError($"N ERROR OCCURRED..... =>{ex.Message}");
                //Set response object in case of exception
                response.ResponseCode = "01";
                response.ResponseMessage = "Transaction failed due to an error!";
                response.Data = null;
            }

            transaction.TransactionType = TransType.Transfer;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionAmount = Amount;
            transaction.TrnsactionSourceAccount = FromAccount;
            transaction.TransactionDestinationAccount = ToAccount;


            //set other props of transaction here
            transaction.TrnsactionParticulars = $"NEW TRANSACTION FROM SOURCE => {System.Text.Json.JsonSerializer.Serialize(transaction.TrnsactionSourceAccount)} To Destination Account => {System.Text.Json.JsonSerializer.Serialize(transaction.TransactionDestinationAccount)} ON DATE => {transaction.TransactionDate} FOR AMOUNT => {System.Text.Json.JsonSerializer.Serialize(transaction.TransactionAmount)} TRANSACTION TYPE =>{System.Text.Json.JsonSerializer.Serialize(transaction.TransactionType)} TRANSACTION STATUS =>{System.Text.Json.JsonSerializer.Serialize(transaction.TrnsactionStatus)}";

            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
            //Return the response object
            return response;
        }

        Response ITransactionService.MakeWithdrawl(string AccountNumber, decimal Amount, string TransactionPin)
        {
            Response response = new Response();
            Account sourceAccount;
            Account destinationAccount;
            Transaction transaction = new Transaction();

            //First check if the user  - account owner is valid
            //we'll need authenticate in UserService, so let's inject IUserService Here
            var authUser = _accountService.Authenticate(AccountNumber, TransactionPin);
            if (authUser == null) throw new ApplicationException("Invalid Credentials");

            try
            {
                //or deposite, our bankSettlemenAccount is the detination geting mouney from the user's account
                sourceAccount = _accountService.GetByNumber(AccountNumber);
                destinationAccount = _accountService.GetByNumber(_ourBankSettelmentAccount);

                //Now let's update their account balances
                sourceAccount.CurrentAccountBalance -= Amount;
                destinationAccount.CurrentAccountBalance += Amount;

                

                if ((_dbContext.Entry(sourceAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified) &&
                    (_dbContext.Entry(destinationAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified))
                {
                    //so transaction successful
                    transaction.TrnsactionStatus = TransStatus.Success;
                    response.ResponseCode = "00";
                    response.ResponseMessage = "Transaction successful!";
                    response.Data = null;
                }
                else
                {
                    //so transaction unsuccessful
                    transaction.TrnsactionStatus = TransStatus.Failed;
                    response.ResponseCode = "02";
                    response.ResponseMessage = "Transaction failed!";
                    response.Data = null;
                }

                //set other props of transaction here
                transaction.TrnsactionParticulars = $"NEW TRANSACTION FROM SOURCE => {System.Text.Json.JsonSerializer.Serialize(transaction.TrnsactionSourceAccount)} To Destination Account => {System.Text.Json.JsonSerializer.Serialize(transaction.TransactionDestinationAccount)} ON DATE => {transaction.TransactionDate} FOR AMOUNT => {System.Text.Json.JsonSerializer.Serialize(transaction.TransactionAmount)} TRANSACTION TYPE =>{System.Text.Json.JsonSerializer.Serialize(transaction.TransactionType)} TRANSACTION STATUS =>{System.Text.Json.JsonSerializer.Serialize(transaction.TrnsactionStatus)}";

                //Add the transaction to the context and save changes
                _dbContext.Transactions.Add(transaction);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _Logger.LogError($"N ERROR OCCURRED..... =>{ex.Message}");
                //Set response object in case of exception
                response.ResponseCode = "01";
                response.ResponseMessage = "Transaction failed due to an error!";
                response.Data = null;
            }

            transaction.TransactionType = TransType.Withdrawl;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionAmount = Amount;
            transaction.TrnsactionSourceAccount = _ourBankSettelmentAccount;
            transaction.TransactionDestinationAccount = AccountNumber;


            //set other props of transaction here
            transaction.TrnsactionParticulars = $"NEW TRANSACTION FROM SOURCE => {System.Text.Json.JsonSerializer.Serialize(transaction.TrnsactionSourceAccount)} To Destination Account => {System.Text.Json.JsonSerializer.Serialize(transaction.TransactionDestinationAccount)} ON DATE => {transaction.TransactionDate} FOR AMOUNT => {System.Text.Json.JsonSerializer.Serialize(transaction.TransactionAmount)} TRANSACTION TYPE =>{System.Text.Json.JsonSerializer.Serialize(transaction.TransactionType)} TRANSACTION STATUS =>{System.Text.Json.JsonSerializer.Serialize(transaction.TrnsactionStatus)}";

            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
            //Return the response object
            return response;
        }
    }
}
