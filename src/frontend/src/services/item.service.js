import axios from 'axios';
import { authHeader } from '@helpers';

const API_URL = 'http://localhost:3721';
const header = authHeader();

const createItem = async (userId, item) => {
  await axios.post(
    API_URL + '/products',
    { userId: userId, ...item },
    {
      headers: header,
    }
  );
};

const updateItem = async (userId, item) => {
  await axios.put(
    API_URL + '/products',
    { userId: userId, ...item },
    {
      headers: header,
    }
  );
};

const getItems = async (userId) => {
  const { data } = await axios.post(
    API_URL + '/products/all',
    { userId: userId },
    {
      headers: header,
    }
  );
  return data;
};

const deleteItem = async (id) => {
  await axios.delete(
    API_URL + '/products/' + id,
    {},
    {
      headers: header,
    }
  );
};

export { createItem, updateItem, getItems, deleteItem };
