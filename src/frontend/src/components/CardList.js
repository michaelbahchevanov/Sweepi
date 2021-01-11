import React from 'react';
import { Card } from '@components';
import { useMedia, useItem } from '../context';

export const CardList = () => {
  const { media } = useMedia();
  const { items } = useItem();

  return (
    <div className='flex flex-wrap my-6 justify-center'>
      {media.map((data, i) => (
        <Card
          key={data._id}
          url={data.ImageUrl}
          name={items[i].name}
          imageid={data._id}
          itemId={items[i].id}
        />
      ))}
    </div>
  );
};
