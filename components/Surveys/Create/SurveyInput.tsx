import {
  Box,
  FormControl,
  FormErrorMessage,
  HStack,
  Input,
  Text,
  VStack,
} from '@chakra-ui/react';
import { Field, useField } from 'formik';
import localization from 'resources/localization/localization';
import { useSurveyInput } from './hooks/useSurveyInput';
import QuestionsInput from './QuestionsInput';

const SurveyInput = () => {
  const { surveyTitleFieldName, questionsFieldName } = useSurveyInput();
  const [, { touched, error }] = useField(surveyTitleFieldName);

  return (
    <VStack
      className='survey-input'
      w='full'
      align='start'
      p={25}
      spacing={25}
    >
      <HStack
        spacing={5}
        align='baseline'
      >
        <Box>
          <Text
            fontSize='2xl'
            fontWeight='medium'
            verticalAlign='center'
          >
            {localization.newSurvey}
          </Text>
        </Box>
        <Box>
          <FormControl isInvalid={error != null && touched}>
            <Field
              as={Input}
              placeholder={localization.title}
              name={surveyTitleFieldName}
            />
            {error != null && touched && (
              <FormErrorMessage>{error}</FormErrorMessage>
            )}
          </FormControl>
        </Box>
      </HStack>

      <QuestionsInput questionsFieldName={questionsFieldName} />
    </VStack>
  );
};

export { SurveyInput };
