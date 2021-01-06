import React from 'react';
import { useAuthState, MediaProvider } from './context';
import { AuthenticatedApp } from './AuthenticatedApp';
import { UnauthenticatedApp } from './UnauthenticatedApp';

export const App = () => {
  const { user } = useAuthState();
  return user ? (
    <MediaProvider>
      <AuthenticatedApp />
    </MediaProvider>
  ) : (
    <UnauthenticatedApp />
  );
};
