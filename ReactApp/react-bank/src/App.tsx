import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import IndividualTransaction from './Transactions/IndividualTransaction';
import { landingPageDTO, TransactionDTO } from './Transactions/transactions.model';
import TransactionsList from './Transactions/TransactionsList';

function App() {

  const [transactions, setTransaction] = useState<landingPageDTO>({});
  useEffect(() => {
    const timerID = setTimeout(() => {
      setTransaction({
        NormalTransactions : [
          {
          id:1,
          type:'exchange',
          price: -30,
          source:"yoni",
          destination:"Jonatan"
        },
        {
          id:2,
          type:'salary',
          price: 3000,
          source:"work",
          destination:"you"
        },
        {
          id:3,
          type:'refund',
          price: 100,
          source:"zara",
          destination:"you"
        }
      ],
      BlockchainTransactions : [

      ]

      });

    },4000);
    return () => clearTimeout(timerID);
  });
  
  return (
    <>
      <h3>Your Normal Transactions</h3>
      <TransactionsList transactions={transactions.NormalTransactions}/>
      <h3>Your blockchain transactions</h3>
      <TransactionsList transactions={transactions.BlockchainTransactions}/>
    </>
  );
}

export default App;
