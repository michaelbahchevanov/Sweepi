import axios from 'axios';

const API_URL = 'http://localhost:42069/api/authentication/';

const register = (email, password) => {
  return axios
    .post(API_URL + 'register', {
      email,
      password,
    })
    .then((res) => {
      if (res.data.token) {
        localStorage.setItem('user', JSON.stringify(res.data));
      }

      return res.data;
    });
};

const login = (email, password) => {
  return axios
    .post(API_URL + 'login', {
      email,
      password,
    })
    .then((response) => {
      if (response.data.token) {
        localStorage.setItem('user', JSON.stringify(response.data));
      }
      return response.data;
    });
};

const logout = () => localStorage.removeItem('user');

const getCurrentUser = async () =>
  await JSON.parse(localStorage.getItem('user'));

export { register, login, logout, getCurrentUser };
