import React from 'react';
import { Box } from '../images/Box';

export const CtaButton = () => {
  return (
    <div className='bg-yellow-500 border border-yellow-200 rounded-3xl mt-16 ml-auto mr-auto w-56'>
      <div className='flex flex-row justify-between w-full items-center px-4 py-5'>
        <Box className='h-16 w-16' />
        <span className='font-semibold text-center text-2xl pl-1'>
          Add item
        </span>
      </div>
    </div>
  );
};
