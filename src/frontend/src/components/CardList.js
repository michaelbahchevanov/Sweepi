import React from 'react';
import { Card } from '@components';
import { useMedia } from '../context';

export const CardList = () => {
  const { media } = useMedia();
  return (
    <div className='flex flex-wrap my-6 justify-center'>
      {media.map((data) => (
        <Card key={data.id} url={data.imageUrl} name={data.name} />
      ))}
    </div>
  );
};
