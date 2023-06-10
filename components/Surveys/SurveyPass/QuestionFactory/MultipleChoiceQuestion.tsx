import { Box, Checkbox, CheckboxGroup, Text, VStack } from '@chakra-ui/react';
import { QuestionProps } from './QuestionProps';
import { useMemo } from 'react';
import { Field } from 'formik';


const MultipleChoiceQuestion = ({ question, name }: QuestionProps) => {
  const { orderedOptions } = useMemo(() => {
    const orderedOptions = question.options?.sort((o1, o2) => o1.order - o2.order);

    return { orderedOptions };
  }, [question]);

  return (
    <Box>
      <Text fontSize='3xl'>{question.order + 1}. {question.title}</Text>
      <CheckboxGroup>
        <VStack align='start'>
          {orderedOptions && orderedOptions.map((o) => (
            <Field
              as={Checkbox}
              size='lg'
              key={o.id}
              value={o.id}
              name={`${name}.options`}
            >
              {o.content}
            </Field>
          ))}
        </VStack>
      </CheckboxGroup>
    </Box>
  );
};

export { MultipleChoiceQuestion };
