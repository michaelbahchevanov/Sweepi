import * as React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCog, faStar } from '@fortawesome/free-solid-svg-icons';
import { mediaService, itemService, authService } from '@services';
import { useForm } from 'react-hook-form';

export const Card = ({
  url = 'linear-gradient(#eb01a5, #d13531)',
  name = 'None',
  imageid,
  itemId,
}) => {
  const [showModal, setShowModal] = React.useState(false);
  const { register, handleSubmit } = useForm();
  const onSubmit = async (data, e) => {
    const user = await authService.getCurrentUser();
    e.preventDefault();
    e.target.reset();

    await itemService.updateItem(user.userId, { name: data.name, id: data.id });
    setShowModal(false);

    window.location.reload();
  };

  const handleOnClick = () => {
    mediaService
      .removeMedia(imageid)
      .then(() => window.location.reload())
      .catch((error) => console.log(error));
    itemService
      .deleteItem(itemId)
      .then(() => window.location.reload())
      .catch((error) => console.log(error));
  };
  return (
    <>
      <div
        style={{ backgroundImage: `url(${url})` }}
        className='container h-56 w-72 bg-no-repeat bg-cover relative mx-4 my-4 shadow border-solid border-2 border-gray-900 focus:outline-none focus-within:outline-none'
      >
        <div className='flex flex-row w-full min-w-full justify-between items-center px-7 py-5'>
          <button>
            <FontAwesomeIcon
              icon={faCog}
              color='#FFFFFF'
              size='lg'
              className='cursor-pointer focus:outline-none'
              onClick={() => setShowModal(true)}
            />
          </button>
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
        <button
          className='absolute bottom-0 mx-auto left-0 right-0 text-center bg-gray-600 w-36 rounded-lg focus:outline-none hover:bg-yellow-400 hover:text-white cursor-pointer'
          onClick={handleOnClick}
        >
          Sweep
        </button>
      </div>
      {showModal ? (
        <>
          <div className='justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-50 outline-none focus:outline-none'>
            <div className='relative w-auto my-6 mx-auto max-w-3xl'>
              {/*content*/}
              <div className='border-0 rounded-lg shadow-lg relative flex flex-col w-full bg-white outline-none focus:outline-none'>
                {/*header*/}
                <div className='flex items-start justify-between p-5 border-b border-solid border-gray-300 rounded-t'>
                  <h3 className='text-3xl font-semibold'>Edit Item</h3>
                  <button
                    className='p-1 ml-auto bg-transparent border-0 text-black opacity-5 float-right text-3xl leading-none font-semibold outline-none focus:outline-none'
                    onClick={() => setShowModal(false)}
                  >
                    <span className='bg-transparent text-black opacity-5 h-6 w-6 text-2xl block outline-none focus:outline-none'>
                      ×
                    </span>
                  </button>
                </div>
                {/*body*/}
                <form onSubmit={handleSubmit(onSubmit)}>
                  <div className='relative p-6 flex-auto'>
                    <div className='px-6'>
                      <span className='pr-4 font-medium'>Item Name:</span>
                      <input
                        className='border-2 border-yellow-500 bg-white h-10 px-4 rounded-lg text-sm focus:outline-none xs:w-44 sm:w-52 w-64'
                        ref={register}
                        type='text'
                        name='name'
                        placeholder='Cucumber'
                      />
                      <input
                        type='hidden'
                        ref={register}
                        name='id'
                        value={itemId}
                      />
                    </div>
                  </div>
                  {/*footer*/}
                  <div className='flex items-center justify-end p-6 border-t border-solid border-gray-300 rounded-b'>
                    <button
                      className='text-red-500 background-transparent font-bold uppercase px-6 py-2 text-sm outline-none focus:outline-none mr-1 mb-1'
                      type='button'
                      style={{ transition: 'all .15s ease' }}
                      onClick={() => setShowModal(false)}
                    >
                      Close
                    </button>
                    <button
                      className='bg-green-500 text-white active:bg-green-600 font-bold uppercase text-sm px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1'
                      type='submit'
                      style={{ transition: 'all .15s ease' }}
                    >
                      Save Changes
                    </button>
                  </div>
                </form>
              </div>
            </div>
          </div>
          <div className='opacity-25 fixed inset-0 z-40 bg-black'></div>
        </>
      ) : null}
    </>
  );
};
