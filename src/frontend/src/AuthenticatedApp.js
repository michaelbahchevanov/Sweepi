import React from 'react';
import { AuthenticatedRoutes } from './AuthenticatedRoutes';

export const AuthenticatedApp = () => {
  return (
    <div>
      <div>This is the authenticated application</div>
      <AuthenticatedRoutes />
    </div>
  );
};
