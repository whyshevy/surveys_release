import {
  FormControl,
  FormErrorMessage,
  Input,
  InputProps,
} from '@chakra-ui/react';
import { Field, FieldHookConfig, useField } from 'formik';

const TextField = ({ ...props }: FieldHookConfig<string> & InputProps) => {
  const [field, meta] = useField(props);

  return (
    <FormControl isInvalid={!!meta.error && meta.touched}>
      <Field
        as={Input}
        {...field}
        {...props}
      />
      <FormErrorMessage>{meta.error}</FormErrorMessage>
    </FormControl>
  );
};

export default TextField;
