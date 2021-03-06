import * as React from 'react';
import { mediaService, userService } from '@services';

const MediaContext = React.createContext();
const userId = userService.getUserId();

function MediaProvider({ children }) {
  const [state, setState] = React.useState({
    status: 'pending',
    error: null,
    media: [],
  });

  React.useEffect(() => {
    mediaService.getMedia(userId).then(
      (media) => setState({ status: 'success', error: null, media }),
      (error) => setState({ status: 'error', error, media: [] })
    );
  }, []);

  return (
    <MediaContext.Provider value={state}>
      {state.status === 'pending' ? (
        'Loading...'
      ) : state.status === 'error' ? (
        <div>
          An error has occured:
          <div>
            <pre>{state.error.message}</pre>
          </div>
        </div>
      ) : (
        children
      )}
    </MediaContext.Provider>
  );
}

function useMedia() {
  const state = React.useContext(MediaContext);
  const isPending = state.status === 'pending';
  const isError = state.status === 'error';
  const isSuccess = state.status === 'success';
  return {
    ...state,
    isPending,
    isError,
    isSuccess,
  };
}

export { MediaProvider, useMedia };
