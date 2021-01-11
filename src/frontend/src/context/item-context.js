import * as React from 'react';
import { itemService, userService } from '@services';

const ItemContext = React.createContext();
const userId = userService.getUserId();

function ItemProvider({ children }) {
  const [state, setState] = React.useState({
    status: 'pending',
    error: null,
    items: [],
  });

  React.useEffect(() => {
    itemService.getItems(userId).then(
      (items) => setState({ status: 'success', error: null, items }),
      (error) => setState({ status: 'error', error, items: [] })
    );
  }, []);

  return (
    <ItemContext.Provider value={state}>
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
    </ItemContext.Provider>
  );
}

function useItem() {
  const state = React.useContext(ItemContext);
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

export { ItemProvider, useItem };
