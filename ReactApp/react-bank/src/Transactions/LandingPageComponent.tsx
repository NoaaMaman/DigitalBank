import { useEffect, useState } from "react";
import Button from "../Utils/Button";
import { landingPageDTO } from "./transactions.model";
import TransactionsList from "./TransactionsList";

export default function LandingPage() {
  const [isLoading, setIsLoading] = useState(true);
  const [transactions, setTransactions] = useState<landingPageDTO>({
    NormalTransactions: [],
    BlockchainTransactions: []
  });

  useEffect(() => {
    const timerID = setTimeout(() => {
      
      setTransactions({
        NormalTransactions: [
          {
            id: 1,
            type: 'exchange',
            price: -30,
            source: 'yoni',
            destination: 'Jonatan'
          },
          {
            id: 2,
            type: 'salary',
            price: 3000,
            source: 'work',
            destination: 'you'
          },
          {
            id: 3,
            type: 'refund',
            price: 100,
            source: 'zara',
            destination: 'you'
          }
        ],
        BlockchainTransactions: []
      });

      setIsLoading(false);
    }, 4000);

    return () => clearTimeout(timerID);
  }, []);

  return (
    <>
      <h3>Your Normal Transactions</h3>
      {isLoading ? (
        <div>Loading...</div>
      ) : (
        <TransactionsList transactions={transactions.NormalTransactions} />
      )}
      <h3>Your Blockchain Transactions</h3>
      {isLoading ? (
        <div>Loading...</div>
      ) : (
        <TransactionsList transactions={transactions.BlockchainTransactions} />
      )}
    </>
  );
}