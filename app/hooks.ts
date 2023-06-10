import { TypedUseSelectorHook, useDispatch as useReduxDispatch, useSelector as useReduxSelector } from 'react-redux';
import type { AppDispatch, RootState } from './store';
import { setUser } from '../features/users/userSlice';
import { User } from 'models/users/User';
import { useRouter } from 'next/router';


export const useDispatch = () => useReduxDispatch<AppDispatch>();
export const useSelector: TypedUseSelectorHook<RootState> = useReduxSelector;

export const useUser = () => {
  const user = useSelector(state => state.user).user;
  const dispatch = useDispatch();

  return { user, setUser: (user: User | null) => dispatch(setUser(user)) };
};


export const useCurrentUser = () => {
  const router = useRouter();
  const { user } = useUser();

  const userId = router.query?.userId as string;
  if (user == null) {
    return null;
  }

  return userId === user?.id ? user : null;
};
