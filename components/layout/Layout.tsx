import { Container } from '@chakra-ui/react';
import React, { ReactNode, useEffect, useState } from 'react';
import { NavBar } from '../NavBar';
import { JwtPayload } from '../../models/auth/Jwt';
import router from 'next/router';
import AuthService from '../../services/auth/AuthService';
import { useUser } from '../../app/hooks';

interface LayoutProps {
  children?: ReactNode;
}

export default function Layout({ children }: LayoutProps) {
  const { user, setUser } = useUser();
  const [token, setToken] = useState<string | null>(null);
  const [jwt, setJwt] = useState<JwtPayload | null>(null);

  useEffect(() => {
    setToken(localStorage.getItem('token'));
  }, []);

  useEffect(() => {
    if (token == null) {
      return;
    }

    setJwt(AuthService.decodeJwt(token));
  }, [token]);

  const handleSignOut = () => {
    localStorage.removeItem('token');
    setToken(null);
    setJwt(null);

    setUser(null);

    router.push('/');
  };

  return (
    <Container
      maxW='7xl'
      p={4}
    >
      <NavBar
        onTokenChanged={handleSignOut}
        token={token}
        username={user?.name ?? null}
      />
      {children}
    </Container>
  );
}
