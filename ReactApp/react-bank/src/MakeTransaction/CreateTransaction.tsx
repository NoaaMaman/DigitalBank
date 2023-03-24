import { Field, Form } from "formik";
import { Formik } from "formik";
import { Link } from "react-router-dom";
import Button from "../Utils/Button";
import * as Yup from 'yup';
import { ErrorMessage } from "formik/dist/ErrorMessage";
import TextField from "../Forms/TextField";

export default function createTransaction(){
    //const history = useHistory();
    return(
        <>
            <h3>Create Transaction</h3>
            <Formik initialValues={{
                    name: ''
            }}
             onSubmit={value => {
                //When the form is posted
                console.log(value);
             }}
             validationSchema={Yup.object({
                name: Yup.string().required('This field is required').firstLetterUppercase()
             })}
            >
                <Form>
                    <TextField field="name" displayName="Name"/>
                    <Button type="submit">Make Transaction!</Button>
                    <Link className="btn btn-secondary" to="/makeTransaction">Cancel</Link>
                </Form>
            </Formik>
            
        </>
        
    )
}
