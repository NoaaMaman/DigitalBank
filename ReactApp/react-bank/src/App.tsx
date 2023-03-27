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
import axios from 'axios';
import { urlWeather } from './endpoint';
//import configureValidations from './Validations';

//configureValidations();
function App() {
  useEffect(() => {
    axios.get('https://localhost:7016/WeatherForecast')
      .then(response => {
        console.log(response.data);
      });
  }, []);
  return (
    <BrowserRouter>
      <Menu />
      <div className="container">
      <Switch>
        {routes.map((r) => (
          <Route key={r.path} path={r.path} exact={r.exact} >
              <r.component />
          </Route>
        ))}
      </Switch>
      </div>
    </BrowserRouter>
  )
}

export default App;