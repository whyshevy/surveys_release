import { Box, Radio, RadioGroup, Text, VStack } from '@chakra-ui/react';
import { QuestionProps } from './QuestionProps';
import { useMemo } from 'react';
import { Field } from 'formik';


const useSingleChoiceQuestion = (questionFieldName: string) => {
  const getOptionsFieldName = () => `${questionFieldName}.options`;
  const getOptionFieldName = (index: number) => `${questionFieldName}.options.${index}`;

  return { getOptionFieldName, getOptionsFieldName };
};

const SingleChoiceQuestion = ({ question, name }: QuestionProps) => {
  const { orderedOptions } = useMemo(() => {
    const orderedOptions = question.options?.sort((o1, o2) => o1.order - o2.order);

    return { orderedOptions };
  }, [question]);

  const { getOptionsFieldName } = useSingleChoiceQuestion(name);

  // TODO: Figure out what name should be used, it's wrong onSubmit
  return (
    <Box w='full'>
      <Text fontSize='3xl'>{question.order + 1}. {question.title}</Text>
      <RadioGroup name={getOptionsFieldName()}>
        <VStack align='start'>
          {orderedOptions && orderedOptions.map((o) => (
            <Field
              size='lg'
              as={Radio}
              key={o.id}
              value={o.id}
              name={getOptionsFieldName()}
            >
              {o.content}
            </Field>
          ))}
        </VStack>
      </RadioGroup>
    </Box>
  );
};

export { SingleChoiceQuestion };
