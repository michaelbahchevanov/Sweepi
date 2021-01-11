import axios from 'axios';
import LocalStorageService from './LocalStorage.service';

const localStorageService = LocalStorageService.getService();
const API_URL = 'http://localhost:3721/auth';

const register = (email, password) => {
  return axios
    .post(API_URL + '/register', {
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
    .post(API_URL + '/login', {
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

const logout = async () => await localStorageService.clearToken();

const getCurrentUser = async () =>
  await JSON.parse(localStorage.getItem('user'));

axios.interceptors.request.use(
  (config) => {
    const token = localStorageService.getToken();
    if (token) {
      config.headers['Authorization'] = 'Bearer ' + token;
    }

    config.headers['Content-Type'] = 'application/json';
    config.headers['Access-Control-Allow-Origin'] = '*';
    return config;
  },
  (error) => {
    Promise.reject(error);
  }
);

axios.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (error.config && error.response && error.response.status === 400) {
      localStorageService.clearToken();
      window.location.reload();
    }
    if (error.config && error.response && error.response.status === 401) {
      return axios
        .post('http://localhost:3721/refresh', {
          token: localStorageService.getToken(),
          refreshToken: localStorageService.getRefreshToken(),
        })
        .then((res) => {
          if (res.status === 200) {
            localStorageService.setToken(res.data);
            axios.defaults.headers.common['Authorization'] =
              'Bearer ' + localStorageService.getToken();
            return axios(error.config);
          }
          if (res.status === 400) {
            localStorageService.clearToken();
            return axios(error.config);
          }
        });
    }
    return Promise.reject(error);
  }
);

export { register, login, logout, getCurrentUser };
