import { NavLink } from "react-router-dom";

export default function Menu(){
    return(
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <NavLink className="navbar-brand" href="/" to={""}>Maman Digital Bank</NavLink>
                <div className="collapse navbar-collapse">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        <li>
                            <NavLink className="nav-link" to="/accounts/edit">
                                Edit Account
                           </NavLink>
                        </li>
                        <li>
                            <NavLink className="nav-link" to="/makeTransaction">
                                Create Transaction
                           </NavLink>
                        </li>
                    </ul>
                </div>
            </div>

        </nav>
    )
}