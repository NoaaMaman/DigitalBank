import { Link } from "react-router-dom";

export default function IndexAccounts(){
    return(
        <>
            <h3>Accounts</h3>
            <Link className="btn btn-primary" to="/MoreOptions/create">Create Account</Link>
        </>
    )
}