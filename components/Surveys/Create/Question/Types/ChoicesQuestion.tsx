import { CloseIcon } from '@chakra-ui/icons';
import { Button, HStack, Input } from '@chakra-ui/react';
import { Field, FieldArray, useField } from 'formik';
import { createEmptyOptionFromOrder } from 'models/factories';
import { Option } from 'models/surveys/Option';
import { useMemo } from 'react';
import localization from 'resources/localization/localization';

import { useSingleChoiceQuestion } from '../../hooks/useSingleChoiceQuestion';
import { QuestionProps } from './QuestionProps';

const ChoicesQuestion = ({ optionsFieldName }: QuestionProps) => {
  const { getOptionContentFieldName } =
    useSingleChoiceQuestion(optionsFieldName);

  const [field] = useField(optionsFieldName);
  const options = useMemo(() => field.value as Option[], [field]);

  return (
    <FieldArray name={optionsFieldName}>
      {({ remove, push }) => (
        <>
          {options.map((option, index) => (
            <HStack
              w='full'
              key={option.id}
            >
              <Field
                as={Input}
                name={getOptionContentFieldName(index)}
                placeholder={localization.title}
              />
              <Button
                onClick={() => remove(index)}
                variant='ghost'
              >
                <CloseIcon />
              </Button>
            </HStack>
          ))}
          <Button
            onClick={() => push(createEmptyOptionFromOrder(options.length + 1))}
          >
            {localization.addOption}
          </Button>
        </>
      )}
    </FieldArray>
  );
};

export { ChoicesQuestion };
