import React from 'react';
import { useForm } from 'react-hook-form';
import { Link } from 'react-router-dom';
import { Logo } from '../images/Logo.js';
import { authService } from '@services';
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from 'yup';

const schema = yup.object().shape({
  email: yup.string().email().required(),
  password: yup
    .string()
    .matches(
      /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/,
      'Must contain lowercase, uppercase, number and special character'
    )
    .required(),
  passwordConfirmation: yup
    .string()
    .oneOf([yup.ref('password'), null], 'Passwords must match')
    .required('Password confirm is required'),
});

export const Register = ({ history }) => {
  const { register, handleSubmit, errors } = useForm({
    resolver: yupResolver(schema),
  });

  const onSubmit = (data, e) => {
    e.preventDefault();
    e.target.reset();

    authService
      .register(data.email, data.password)
      .then(() => history.push('/'))
      .then(() => window.location.reload())
      .catch((error) => console.log(error));
  };

  return (
    <div className='bg-gray-100 min-h-screen flex flex-col'>
      <div className='container max-w-sm mx-auto flex-1 flex flex-col items-center justify-center px-2'>
        <form
          className='bg-white px-6 py-8 rounded shadow-md text-black w-full border border-gray-300'
          onSubmit={handleSubmit(onSubmit)}
        >
          <Logo className='mx-auto mb-5 w-24 min-w-full h-24 min-h-full' />
          <h1 className='mb-8 text-xl text-center'>
            Sign up now and start managing your inventory smartly
          </h1>

          <input
            type='text'
            ref={register}
            className='block border border-gray-300 w-full p-3 rounded mb-4 bg-gray-100 focus:bg-gray-50 focus:outline-none focus:border-gray-600'
            name='email'
            placeholder='Email'
          />
          <p className=' text-yellow-400 font-normal italic mb-2'>
            {errors.email?.message}
          </p>

          <input
            type='password'
            ref={register}
            className='block border border-gray-300 w-full p-3 rounded mb-4 bg-gray-100 focus:bg-gray-50 focus:outline-none focus:border-gray-600'
            name='password'
            placeholder='Password'
          />
          <p className=' text-yellow-400 font-normal italic mb-2'>
            {errors.password?.message}
          </p>

          <input
            type='password'
            ref={register}
            className='block border border-gray-300 w-full p-3 rounded mb-4 bg-gray-100 focus:bg-gray-50 focus:outline-none focus:border-gray-600'
            name='passwordConfirmation'
            placeholder='Confirm Password'
          />
          <p className=' text-yellow-400 font-normal italic mb-2'>
            {errors.passwordConfirmation?.message}
          </p>

          <button
            type='submit'
            className='w-full text-center py-3 rounded bg-yellow-500 text-black hover:bg-green-dark focus:outline-none my-1'
          >
            Sign up
          </button>
        </form>

        <div className='text-grey-dark mt-6'>
          Already have an account?
          <Link to='/login'>
            <span className='text-yellow-500'> Sign in</span>
          </Link>
        </div>
      </div>
    </div>
  );
};
