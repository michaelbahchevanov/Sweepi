import React from 'react';
import { UnauthenticatedRoutes } from './UnauthenticatedRoutes';
export const UnauthenticatedApp = () => {
  return (
    <div>
      <div>This is the unauthenticated application</div>
      <UnauthenticatedRoutes />
    </div>
  );
};
