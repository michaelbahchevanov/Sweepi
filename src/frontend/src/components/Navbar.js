import React from 'react';
import { Logo } from '../images/Logo';
import { LogoutButton } from '@components';

export const Navbar = () => {
  return (
    <nav className='flex flex-row text-center justify-between py-4 px-24 bg-white shadow items-baseline w-full min-w-full xs:px-7'>
      <div className='mb-2 sm:mb-0'>
        <Logo className='xs:w-14 xs:h-10' />
      </div>
      <div className='relative mx-auto text-gray-600 self-center'>
        <input
          className='border-2 border-gray-300 bg-white h-10 px-5 pr-16 rounded-lg text-sm focus:outline-none xs:w-44 sm:w-52 w-96'
          type='search'
          name='search'
          placeholder='Search'
        />
        <button
          type='submit'
          className='absolute right-0 top-0 mt-5 mr-4'
        ></button>
      </div>
      <LogoutButton className='xs:text-xs text-xl self-center hover:cursor-pointer' />
    </nav>
  );
};
