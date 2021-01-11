import * as React from 'react';
import { Box } from '../images/Box';
import { Widget } from '@uploadcare/react-widget';
import { userService, itemService } from '@services';
import axios from 'axios';

export const CtaButton = () => {
  const widgetApi = React.useRef();

  const handleOnClick = () => {
    const dialog = widgetApi.current.openDialog();
    dialog.done((file) => {
      if (file) {
        file.done(async (info) => {
          const userId = await userService.getUserId();
          await axios.post(
            'http://localhost:3721/images',
            {
              imageUrl: info.cdnUrl,
              isImage: info.isImage,
              isStored: info.isStored,
              name: info.name,
              size: info.size,
              userId: userId,
            },
            {
              headers: {
                'Content-Type': 'application/json',
              },
            }
          );
          await itemService.createItem(userId, { name: 'Empty' });
          await window.location.reload();
        });
      }
    });
  };

  return (
    <div className='bg-yellow-500 border border-yellow-200 rounded-3xl mt-16 ml-auto mr-auto w-56 shadow'>
      <div className='flex flex-row justify-between w-full items-center px-4 py-5'>
        <Box className='h-16 w-16' />
        <button
          className='font-semibold text-center text-2xl pl-1'
          onClick={handleOnClick}
        >
          Add item
        </button>
        <div className='hidden'>
          <Widget ref={widgetApi} publicKey='demopublickey' preloader={null} />
        </div>
      </div>
    </div>
  );
};
