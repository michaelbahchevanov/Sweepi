import * as React from 'react';
import { Widget } from '@uploadcare/react-widget';
import axios from 'axios';

export const ImageUploader = () => {
  const handleFileSelect = (file) => {
    if (file) {
      file.done(async (info) => {
        const req = await axios.post(
          'http://localhost:6969/api/v1/images',
          {
            imageUrl: info.cdnUrl,
            isImage: info.isImage,
            isStored: info.isStored,
            name: info.name,
            size: info.size,
          },
          {
            headers: {
              'Content-Type': 'application/json',
            },
          }
        );
        return req;
      });
    }
  };

  const handleOnChange = (info) => {
    console.log('Upload completed: ' + info);
  };

  return (
    <div>
      <p>
        <label htmlFor='file'>You've just uploaded:</label>{' '}
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
