import React from 'react';
import { authService } from '@services';

export const LogoutButton = ({ className }) => {
  const handleOnClick = () => {
    authService
      .logout()
      .then(() => window.location.reload())
      .catch((error) => console.log(error));
  };
  return (
    <button className={className} onClick={handleOnClick}>
      Logout
    </button>
  );
};
