import * as React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCog, faStar } from '@fortawesome/free-solid-svg-icons';
import axios from 'axios';

export const Card = ({
  image = 'https://picsum.photos/400',
  name = 'Charger',
}) => {
  const [tempImage, setImage] = React.useState();

  React.useEffect(() => {
    const req = axios.get('https://picsum.photos/400');
    req.then((data) => setImage(data.config.url));
  }, []);

  return (
    <div
      style={{ backgroundImage: `url(${tempImage})` }}
      className='container h-48 w-64 bg-no-repeat bg-cover relative'
    >
      <div className='flex flex-row w-full min-w-full justify-between items-center px-7 py-5'>
        <FontAwesomeIcon
          icon={faCog}
          color='#FFFFFF'
          size='lg'
          className='cursor-pointer'
        />
        <FontAwesomeIcon
          icon={faStar}
          color='#7A7A7A'
          size='lg'
          className='cursor-pointer'
        />
      </div>
      <div className='flex flex-row w-full min-w-full pl-6 pt-12'>
        <span className='text-2xl font-bold text-white'>{name}</span>
      </div>
      <div className='absolute bottom-0 mx-auto left-0 right-0 text-center bg-gray-600 w-36 rounded-lg focus:outline-none hover:bg-yellow-400 hover:text-white cursor-pointer'>
        Sweep
      </div>
    </div>
  );
};
