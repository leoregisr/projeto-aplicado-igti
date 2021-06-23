import React, { useEffect, useState  } from 'react';
import { Route, Switch, withRouter, useLocation } from 'react-router';
import { Layout } from './components/Layout';
import Login from './components/Auth/Login'
import Home from './components/Home';
import TimeCard from './components/TimeCard/TimeCard'
import Pendencies from './components/Pendencies/Pendencies'
import Reports from './components/Reports/Reports'
import ReportByDate from './components/Reports/ReportByDate'
import ReportByYearMonth from './components/Reports/ReportByYearMonth'
import './custom.css'
import { PrivateRoute } from './components/PrivateRoute';

function App() {
  const displayName = App.name;    

  return (
    <Switch>
      <Layout>              
          <Route exact path='/'component={Login}/>            
          <PrivateRoute exact path='/Home' component={Home}  />              
          <PrivateRoute exact path='/TimeCard' component={TimeCard}/>            
          <PrivateRoute exact path='/Pendencies' component={Pendencies}/>
          <PrivateRoute exact path='/Reports' component={Reports}/>
          <PrivateRoute exact path='/Reports/ReportByDate' component={ReportByDate}/>
          <PrivateRoute exact path='/Reports/ReportByYearMonth' component={ReportByYearMonth}/>
          {/* <Route path='/:componentName' component={(props) =>               
            <PARoot 
                urlBase='http://localhost:5008/api/v1'
                component={props.match.params.componentName}
            />} 
          /> */}
      </Layout>
    </Switch>
  );
}

export default App;