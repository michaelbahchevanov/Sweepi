import React from 'react';
import { useAuthState, MediaProvider, ItemProvider } from './context';
import Compose from './context/compose';
import { AuthenticatedApp } from './AuthenticatedApp';
import { UnauthenticatedApp } from './UnauthenticatedApp';

export const App = () => {
  const { user } = useAuthState();
  return user ? (
    <Compose components={[MediaProvider, ItemProvider]}>
      <AuthenticatedApp />
    </Compose>
  ) : (
    <UnauthenticatedApp />
  );
};
