import axios from 'axios';
import { authHeader } from '@helpers';

const URL = 'http://localhost:3721';
const HEADER = authHeader();

const getMedia = async (userId) => {
  const { data } = await axios.post(
    URL + '/user/images',
    { userId: userId },
    {
      headers: HEADER,
    }
  );
  return data;
};

const removeMedia = async (imageId) => {
  await axios.delete(
    URL + '/images',
    { data: { id: imageId } },
    {
      headers: HEADER,
    }
  );
};

export { getMedia, removeMedia };
