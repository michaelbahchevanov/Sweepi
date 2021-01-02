import React from 'react';
import Background from '../images/Background.svg';
import { LogoOrange } from '../images/Logo-orange';

export const Landing = () => {
  return (
    <div className='container mx-auto h-screen w-full min-w-full'>
      <div
        className='bg-cover bg-no-repeat bg-center px-40 py-5 min-w-full min-h-full z-10'
        style={{
          backgroundImage: `url(${Background})`,
        }}
      >
        <div className='flex flex-row xs:flex-col w-full justify-between items-center'>
          <LogoOrange className='h-full w-32' />
          <div className='pt-7'>
            <button className='text-md text-yellow-500 bg-white px-7 py-2 xs:px-10 xs:w-48'>
              Sign in
            </button>
          </div>
        </div>

        <div className='flex flex-col justify-center items-center'>
          <div className='text-xl xs:text-lg mt-36 text-yellow-800 font-bold space-y-1'>
            <p className='xs:ml-16'>Keep your inventory</p>
            <p className='ml-48 xs:w-36'>on track</p>
            <p className='ml-20 xs:ml-24'>with Sweepi</p>
          </div>

          <div className='mt-14 text-center text-md leading-loose w-96 font-semibold xs:text-base'>
            {/* ToDo: make sure to fix overflowing below 400px */}
            <p>
              It is always better to have a clean home to come back to and
              keeping track of your items is the first step! Sweepi sweeps in to
              the rescue to provide an easy and interactive way of managing your
              possessions.
            </p>
          </div>

          <div className='mt-24 xs:w-72'>
            <button className='bg-yellow-500 text-lg text-white border-yellow-700 rounded-full py-3 px-12 xs:w-full'>
              Start tracking now!
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};
