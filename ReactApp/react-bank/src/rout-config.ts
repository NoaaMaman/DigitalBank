import createAccount from "./Accounts/CreateAccount";
import EditAccount from "./Accounts/EditAccount";
import IndexAccounts from "./Accounts/IndexAccount";
import createTransaction from "./MakeTransaction/CreateTransaction";
import EditTransaction from "./MakeTransaction/EditTransaction";

import FilterTransaction from "./MakeTransaction/FilterTransaction";
import IndexMakeTransaction from "./MakeTransaction/IndexMakeTransaction";



import landingPage from "./Transactions/LandingPageComponent";
import RedirectToLandingPage from "./Utils/RedirectToLandingPage";

const routes = [
    {path : '/accounts' , component:IndexAccounts, exact: true},
    {path : '/accounts/create' , component:createAccount},
    {path: '/accounts/edit/:id(\\d+)', component: EditAccount},

    {path : '/makeTransaction' , component: IndexMakeTransaction, exact: true},
    {path : '/makeTransaction/create' , component: createTransaction},
    {path: '/makeTransaction/edit/:id(\\d+)', component:EditTransaction},
    {path: '/makeTransaction/filter', component: FilterTransaction},

    {path : '/', component: landingPage, exact: true},
    {path:'*', component: RedirectToLandingPage}
];

export default routes;
