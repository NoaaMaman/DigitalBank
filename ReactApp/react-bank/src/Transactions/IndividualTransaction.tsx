import { TransactionDTO } from "./transactions.model";
import css from './IndividualTransaction.module.css'
export default function IndividualTransaction(props: TransactionDTO){
    
    const buildLink = () => '/Transaction/${props.id}'

    return(
        <div className={css.div}>
            <p>
                <span>
                    <a href="{buildLink()}">{props.type}</a>
                </span>
                <span>
                    <a href={buildLink()}>{props.price}</a> 
                </span>
                <span>
                    <a href={buildLink()}>{props.source}</a>
                </span>
                <span>
                    <a href={buildLink()}>{props.destination}</a>
                </span>
            </p>
        </div>
    )
}