import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import IndividualTransaction from './Transactions/IndividualTransaction';
import { landingPageDTO} from './Transactions/transactions.model';
import TransactionsList from './Transactions/TransactionsList';
import Button from './Utils/Button';
import Menu from './Menu';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import routes from './rout-config';


function App() {
  return (
    <BrowserRouter>
      <Menu />
      <div className="container">
      <Switch>
        {routes.map(route =>
          <Route key={route.path} path={route.path}>
            <route.component />
          </Route>)}
      </Switch>
      </div>
    </BrowserRouter>
  )
}

export default App;