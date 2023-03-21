import GenericList from "../Utils/GenericList";
import Loading from "../Utils/Loading";
import IndividualTransaction from "./IndividualTransaction";
import { TransactionDTO } from "./transactions.model"
import css from './TransactionsList.module.css'

export default function TransactionsList(props: transactionsListProps){
    if(!props.transactions){
        return <Loading/>
    }else if(props.transactions.length == 0){
        return <>There are no Transactions to display</>
    }else{
        return(
            <GenericList
           
             list={props.transactions}>
            <div className={css.div}>
        
                {props.transactions?.map(transaction =>
                    <IndividualTransaction {...transaction} key={transaction.id}/>)}
        
            </div>
        </GenericList>
        )
        
    }
    
            
      
      
}

interface transactionsListProps{
    transactions?: TransactionDTO[];
}

