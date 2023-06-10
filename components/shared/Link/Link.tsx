import {
  Link as ChakraLink,
  LinkProps as ChakraLinkProps,
} from '@chakra-ui/react';
import NextLink, { LinkProps as NextLinkProps } from 'next/link';
import { ReactNode } from 'react';

interface LinkProps extends NextLinkProps {
  chakraLink?: ChakraLinkProps;
  children?: ReactNode;
}

const Link = (props: LinkProps) => {
  const { chakraLink, children } = props;
  const nextLinkProps = {
    ...props,
    chackraLink: undefined,
    children: undefined,
  };

  return (
    <NextLink {...nextLinkProps}>
      <ChakraLink {...chakraLink}>{children}</ChakraLink>
    </NextLink>
  );
};

export default Link;
