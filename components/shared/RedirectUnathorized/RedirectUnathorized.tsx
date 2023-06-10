import { ReactElement, useCallback, useEffect } from 'react';
import { useUser } from 'app/hooks';
import { useRouter } from 'next/router';
import { User } from 'models/users/User';


interface RedirectIfUnauthorizedProps {
  redirectUrl?: string;
  checkIfUnauthorized: (user: User) => boolean;
  children: () => JSX.Element;
}

export function RedirectUnauthorized(
  {
    redirectUrl = '/',
    checkIfUnauthorized,
    children
  }: RedirectIfUnauthorizedProps): ReactElement {
  const { user } = useUser();
  const router = useRouter();

  const redirectToUrl = useCallback(async (redirectUrl: string) => {
    if (user == null) {
      return;
    }

    if (!checkIfUnauthorized(user)) {
      await router.replace(redirectUrl);
    }
  }, [checkIfUnauthorized, router, user]);

  useEffect(() => {
    if (user != null) {
      return;
    }

    redirectToUrl(redirectUrl);
  }, [redirectToUrl, redirectUrl, user]);

  return children();
}
