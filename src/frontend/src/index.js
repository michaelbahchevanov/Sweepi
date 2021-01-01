import React, { StrictMode } from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import { App } from './App';
import { AuthProvider } from './context';

const root = document.getElementById('root');

ReactDOM.render(
  <StrictMode>
    <AuthProvider>
      <App />
    </AuthProvider>
  </StrictMode>,
  root
);
