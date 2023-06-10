import { Button, Container, Flex, HStack, Text } from '@chakra-ui/react';
import React from 'react';
import localization from '../../resources/localization/localization';
import { Logo } from '../shared/Logo';

interface NavBarProps {
  token: string | null;
  onTokenChanged: () => void;
  username: string | null;
}

const NavBar = ({ username, onTokenChanged }: NavBarProps) => {
  const HeaderComponent = () => {
    if (username != null) {
      return (
        <HStack>
          <Text>{username}</Text>
          <Button onClick={onTokenChanged}>Log out</Button>
        </HStack>
      );
    } else {
      return (
        <div className='text-xl font-medium text-slate-50'>
          <Button
            as='a'
            href='/sign-in'
            colorScheme='cyan'
          >
            {localization.signIn}
          </Button>
        </div>
      );
    }
  };

  return (
    <Container maxW='7xl'>
      <Flex
        as='nav'
        align='center'
        justifyContent='space-between'
        wrap='wrap'
      >
        <Logo href='/' />
        <HeaderComponent />
      </Flex>
    </Container>
  );
};

export { NavBar };
