import React, { useState } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import Login from './components/Auth/Login'
import Home from './components/Home';
import TimeCard from './components/TimeCard/TimeCard'
import './custom.css'
import { PrivateRoute } from './components/PrivateRoute';


function App() {
  const displayName = App.name;  
    return (
      <Switch>
        <Layout>              
            <Route exact path='/' component={Login}/>            
            <PrivateRoute exact path='/Home' component={Home} />              
            <PrivateRoute exact path='/TimeCard' component={TimeCard}/>            
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