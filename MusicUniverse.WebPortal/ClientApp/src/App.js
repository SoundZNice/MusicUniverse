import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { routes } from './components/Routes'
import { BrowserRouter } from 'react-router-dom';

export default class App extends Component {
  static displayName = App.name;

  render () {    
    const r = routes.get()
    return (
        <Layout menu={r.filter(route => route.nav)}>
          {r.map(({route, component}) => 
            <Route exact path={route} key={route} component={component}/> )}
        </Layout>
    );
  }
}