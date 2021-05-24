import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import PARoot from './components/PARoot';
import Login from './components/Auth/Login'
import TimeCard from './components/TimeCard/TimeCard'
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render() {
      return (
          <Layout>              
              <Route exact path='/' component={Login} />
              <Route exact path='/TimeCard' component={TimeCard} />
              {/* <Route path='/:componentName' component={(props) =>               
                <PARoot 
                    urlBase='http://localhost:5008/api/v1'
                    component={props.match.params.componentName}
                />} 
              /> */}
          </Layout>
      );
  }
}

