import { Button, Checkbox, Container, Heading, HStack, Text, VStack } from '@chakra-ui/react';
import { Form, Formik } from 'formik';
import React, { useState } from 'react';

import router from 'next/router';

import capitalize from '../../common/utils/capitalize';
import { Token } from '../../models/users/Token';
import localization from '../../resources/localization/localization';
import { usersService } from '../../services';
import TextField from '../shared/TextField/TextField';
import SignInField from './SignInField';
import { signInValidationSchema } from './signInValidationSchema';
import { useUser } from '../../app/hooks';
import AuthService from '../../services/auth/AuthService';

interface SignInForm {
  [SignInField.Email]: string;
  [SignInField.Password]: string;
  [SignInField.ShouldRemember]: boolean;
}

const SignIn = () => {
  const { setUser } = useUser();

  const [signInForm, setSignInForm] = useState<SignInForm>({
    email: '',
    password: '',
    shouldRemember: false
  });

  const setShouldRemember = () => {
    const shouldRemember = !signInForm.shouldRemember;

    setSignInForm({ ...signInForm, shouldRemember });
  };

  const handleSignIn = async ({
                                email,
                                password,
                                shouldRemember
                              }: SignInForm) => {
    const result = await usersService.signIn({
      email,
      password,
      shouldRemember
    });

    if (result.isSuccessful) {
      const { token } = result.result as Token;
      localStorage.setItem('token', token);

      const user = AuthService.decodeJwtToUser(token);
      setUser(user);

      await router.push(`users/${user.id}/surveys`);
    }
  };

  return (
    <Container
      pt='15rem'
      h='full'
      alignItems='center'
      justifyContent='center'
      maxW='lg'
    >
      <Formik
        initialValues={signInForm}
        validationSchema={signInValidationSchema}
        onSubmit={handleSignIn}
      >
        {
          <Form>
            <VStack spacing={5}>
              <Heading>{localization.signIn}</Heading>
              <TextField
                name='email'
                placeholder={capitalize(localization.email)}
                type='text'
              />
              <TextField
                name='password'
                placeholder={capitalize(localization.password)}
                type='password'
              />
              <Button
                size='lg'
                colorScheme='cyan'
                rounded='lg'
                isFullWidth
                type='submit'
              >
                {localization.signIn}
              </Button>
              <HStack
                w='full'
                justify='space-between'
              >
                <Checkbox onChange={setShouldRemember}>
                  <Text opacity='35%'>{localization.rememberMe}</Text>
                </Checkbox>
              </HStack>
            </VStack>
          </Form>
        }
      </Formik>
    </Container>
  );
};

export default SignIn;
