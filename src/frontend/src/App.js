import React from 'react';
import { useAuthState } from './context';
import { AuthenticatedApp } from './AuthenticatedApp';
import { UnauthenticatedApp } from './UnauthenticatedApp';

export const App = () => {
  const { user } = useAuthState();
  return user ? <AuthenticatedApp /> : <UnauthenticatedApp />;
};
