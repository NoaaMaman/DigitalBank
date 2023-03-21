import createAccount from "./Accounts/CreateAccount";
import EditAccount from "./Accounts/EditAccount";
import IndexAccounts from "./Accounts/IndexAccount";

import FilterTransaction from "./MakeTransaction/FilterTransaction";
import IndexMakeTransaction from "./MakeTransaction/IndexMakeTransaction";



import landingPage from "./Transactions/LandingPageComponent";

const routes = [
    {path : '/accounts' , component:IndexAccounts, exact: true},
    {path : '/accounts/create' , component:EditAccount},
    {path: '/accounts/edit/:id(\\d+)', component: createAccount},

    {path : '/makeTransaction' , component: IndexMakeTransaction},
    {path : '/makeTransaction/create' , component:EditAccount},
    {path: '/makeTransaction/edit', component: createAccount},
    {path: '/makeTransaction/filter', component: FilterTransaction},

    {path : '/', component: landingPage, exact: true}
];

export default routes;
