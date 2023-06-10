import { Button, Container, Text, useToast, VStack } from '@chakra-ui/react';
import { Form, Formik } from 'formik';
import { useRouter } from 'next/router';
import React, { useEffect, useState } from 'react';

import { OperationResult } from '../../common/OperationResult';
import capitalize from '../../common/utils/capitalize';
import { ErrorResponse } from '../../models/common/ErrorResponse';
import { Token } from '../../models/users/Token';
import localization from '../../resources/localization/localization';
import { usersService } from '../../services';
import { OperationType } from '../shared/OperationType';
import TextField from '../shared/TextField/TextField';
import { ToastStatus } from '../shared/Toast/ToastStatus';
import { getErrorDescription, SignUpError } from './errorMapper';
import SignUpField from './SignUpField';
import { signUpValidationSchema } from './signUpValidationRules';

interface SignUpForm {
  [SignUpField.Email]: string;
  [SignUpField.Name]: string;
  [SignUpField.Password]: string;
}

const getToastInfo = (result: OperationResult<Token, ErrorResponse>) => {
  const title = localization.signUp;
  const description = result.isSuccessful
    ? localization.signUpSuccessMessage
    : getErrorDescription(result.error?.detail as keyof typeof SignUpError);

  const status = result.isSuccessful ? ToastStatus.Success : ToastStatus.Error;

  return { title, status, description };
};

const SignUp = () => {
  const router = useRouter();
  const [signUpForm] = useState<SignUpForm>({
    email: '',
    name: '',
    password: '',
  });

  useEffect(() => {
    const isLoggedIn = localStorage.getItem('token') != null;
    if (isLoggedIn) {
      router.push('/');
    }
  }, [router]);

  const toast = useToast();
  const toastId = 1;

  const handleSignUp = async (signUpForm: SignUpForm) => {
    if (toast.isActive(toastId)) {
      return;
    }

    const result = await usersService.signUp(signUpForm);

    const { title, status, description } = getToastInfo(result);

    toast({
      id: toastId,
      title: title,
      description: description,
      status: status,
      isClosable: true,
      position: 'bottom-right',
    });

    if (result.isSuccessful) {
      const { token } = result.result as Token;
      localStorage.setItem('token', token);

      router.push({
        pathname: '/success',
        query: { type: OperationType.SignUp },
      });
    }
  };

  return (
    <Container
      display='flex'
      h='full'
      alignItems='center'
      justifyContent='center'
    >
      <Formik
        initialValues={signUpForm}
        validationSchema={signUpValidationSchema}
        onSubmit={handleSignUp}
      >
        {
          <Form>
            <VStack
              spacing={5}
              mt='8rem'
            >
              <Text
                p={5}
                fontSize='5xl'
                align='center'
              >
                {localization.signUpDescription}{' '}
                {<strong>{localization.applicationName}</strong>}
              </Text>
              <TextField
                name={SignUpField.Email}
                placeholder={capitalize(SignUpField.Email)}
                type='text'
              />
              <TextField
                name={SignUpField.Name}
                placeholder={capitalize(SignUpField.Name)}
                type='text'
              />
              <TextField
                name={SignUpField.Password}
                placeholder={capitalize(SignUpField.Password)}
                type='password'
              />
              <Button
                size='lg'
                colorScheme='cyan'
                rounded='lg'
                isFullWidth
                type='submit'
              >
                {localization.next}
              </Button>
            </VStack>
          </Form>
        }
      </Formik>
    </Container>
  );
};

export default SignUp;
