import { ArrowForwardIcon } from '@chakra-ui/icons';
import { Box, Button, Heading, VStack } from '@chakra-ui/react';
import NextLink from 'next/link';
import React from 'react';

import localization from '../../resources/localization/localization';

const UnathorizedHome = () => {
  return (
    <Box pt='10rem'>
      <VStack spacing={8}>
        <Heading
          as='h1'
          maxW='2xl'
          textAlign='center'
          fontSize='7xl'
          fontWeight='bold'
          wordBreak='break-word'
        >
          {localization.applicationDescription}
        </Heading>
        <NextLink
          href='/sign-up'
          passHref
        >
          <Button
            colorScheme='cyan'
            size='lg'
            rightIcon={<ArrowForwardIcon />}
          >
            {localization.getStarted}
          </Button>
        </NextLink>
      </VStack>
    </Box>
  );
};

export { UnathorizedHome };
