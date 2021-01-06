import React from 'react';
import { CardList, Navbar, CtaButton } from '@components';

export const Home = () => {
  return (
    <>
      <Navbar />
      <div className='container mx-auto px-4'>
        <CtaButton />
        <CardList />
      </div>
    </>
  );
};
