import { QuestionProps } from './QuestionProps';
import { Box, Text, Textarea } from '@chakra-ui/react';
import { Field } from 'formik';


export const TextQuestion = ({ question, name }: QuestionProps) => {
  return (
    <Box w='full'>
      <Text fontSize='3xl'>{question.order + 1}. {question.title}</Text>
      <Field
        name={`${name}.text`}
        as={Textarea}
      />
    </Box>
  );
};
