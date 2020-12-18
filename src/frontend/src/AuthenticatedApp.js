import React from 'react';
import { AuthenticatedRoutes } from './AuthenticatedRoutes';
import { ImageUploader } from '@components';

export const AuthenticatedApp = () => {
  return (
    <div>
      <div>This is the authenticated application</div>
      <ImageUploader />
      <AuthenticatedRoutes />
    </div>
  );
};
