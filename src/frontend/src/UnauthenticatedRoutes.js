import React from 'react';
import { BrowserRouter, Route, Switch, Link } from 'react-router-dom';
import { Home, Login, Register, PageNotFound } from '@pages';

export const UnauthenticatedRoutes = () => {
  return (
    <BrowserRouter>
      <div>
        <header>
          <div>
            <Link to='/'>home</Link>
          </div>
          <div>
            <Link to='/login'>login</Link>
          </div>
          <div>
            <Link to='/register'>register</Link>
          </div>
        </header>
        <Switch>
          <Route exact path='/' component={Home} />
          <Route path='/login' component={Login} />
          <Route path='/register' component={Register} />
          <Route path='*' component={PageNotFound} />
        </Switch>
      </div>
    </BrowserRouter>
  );
};
