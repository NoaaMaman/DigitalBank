import { Link, useParams } from "react-router-dom";

export default function EditTransaction(){
    const {id} : any = useParams();

    return(
        <>
            <h3>Edit Transaction</h3>
            The id is
        </>
    )
}