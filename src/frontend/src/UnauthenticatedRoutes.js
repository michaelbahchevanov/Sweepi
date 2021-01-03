import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { Landing, Login, Register, PageNotFound } from '@pages';

export const UnauthenticatedRoutes = () => {
  return (
    <BrowserRouter>
      <div>
        <Switch>
          <Route exact path='/' component={Landing} />
          <Route exact path='/login' component={Login} />
          <Route exact path='/register' component={Register} />
          <Route path='*' component={PageNotFound} />
        </Switch>
      </div>
    </BrowserRouter>
  );
};
