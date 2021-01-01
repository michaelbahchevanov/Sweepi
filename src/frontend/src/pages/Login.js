import React from 'react';
import { useForm } from 'react-hook-form';
import { Link } from 'react-router-dom';
import { authService } from '@services';

export const Login = ({ history }) => {
  const { register, handleSubmit } = useForm();

  const onSubmit = (data, e) => {
    e.preventDefault();
    e.target.reset();

    authService
      .login(data.email, data.password)
      .then((res) => console.log(res))
      .then(() => history.push('/'))
      .catch((error) => console.log(error));
  };

  return (
    <div className='bg-grey-lighter min-h-screen flex flex-col'>
      <div className='container max-w-sm mx-auto flex-1 flex flex-col items-center justify-center px-2'>
        <form
          className='bg-white px-6 py-8 rounded shadow-md text-black w-full border border-gray-300'
          onSubmit={handleSubmit(onSubmit)}
        >
          <h1 className='mb-8 text-3xl text-center'>Sign in</h1>

          <input
            type='text'
            ref={register}
            className='block border border-gray-300 w-full p-3 rounded mb-4 bg-gray-100 focus:bg-gray-50 focus:outline-none focus:border-gray-600'
            name='email'
            placeholder='Email'
          />

          <input
            type='password'
            ref={register}
            className='block border border-gray-300 w-full p-3 rounded mb-4 bg-gray-100 focus:bg-gray-50 focus:outline-none focus:border-gray-600'
            name='password'
            placeholder='Password'
          />

          <button
            type='submit'
            className='w-full text-center py-3 rounded bg-yellow-500 text-black hover:bg-green-dark focus:outline-none my-1'
          >
            Sign in
          </button>
        </form>

        <div className='text-grey-dark mt-6'>
          Don't have an account?
          <Link to='/register'>
            <span className='text-yellow-500'> Sign up</span>
          </Link>
        </div>
      </div>
    </div>
  );
};
