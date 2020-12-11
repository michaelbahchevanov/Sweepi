import axios from 'axios';
import { authHeader } from '@helpers';

const API_URL = 'http://localhost:5100/api/';

const getAllUsers = () =>
  axios.get(API_URL + 'users', { headers: authHeader() });

export { getAllUsers };
