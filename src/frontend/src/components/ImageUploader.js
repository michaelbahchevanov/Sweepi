import * as React from 'react';
import { Widget } from '@uploadcare/react-widget';
import axios from 'axios';
import { getUserId } from '../services/user.service';

export const ImageUploader = () => {
  const handleFileSelect = (file) => {
    if (file) {
      file.done(async (info) => {
        const userId = await getUserId();
        await axios.post(
          'http://localhost:6969/api/v1/images',
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
      });
    }
  };

  const handleOnChange = (info) => {
    console.log('Upload completed: ' + info);
  };

  return (
    <div>
      <p>
        <Widget
          publicKey='447ab6367441af85d8d1'
          id='file'
          onChange={handleOnChange}
          onFileSelect={handleFileSelect}
        />
      </p>
    </div>
  );
};
