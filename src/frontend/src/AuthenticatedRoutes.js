import React from 'react';
import { BrowserRouter, Route, Switch, Link } from 'react-router-dom';
import { Home, PageNotFound } from '@pages';

export const AuthenticatedRoutes = () => {
  return (
    <BrowserRouter>
      <div>
        <header>
          <div>
            <Link to='/'>home</Link>
          </div>
        </header>
        <Switch>
          <Route exact path='/' component={Home} />
          <Route path='*' component={PageNotFound} />
        </Switch>
      </div>
    </BrowserRouter>
  );
};
