import { Link } from "react-router-dom";

export default function IndexAccounts(){
    return(
        <>
            <h3>Make Transaction</h3>
            <Link className="btn btn-primary" to="/makeTransaction/create">Create Transaction</Link>
        </>
    )
}