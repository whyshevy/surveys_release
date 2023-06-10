import { HStack, Input, Select, VStack } from '@chakra-ui/react';
import { ChoicesQuestion, RatingQuestion, TextQuestion } from 'components/Surveys/Create/Question/Types';
import { Field, useField } from 'formik';
import { Question } from 'models/surveys';
import { QuestionType, QuestionTypesLocalization } from 'models/surveys/QuestionType';
import localization from 'resources/localization/localization';

import { useQuestionTemplate } from './hooks/useQuestionTemplate';


const QuestionComponents = {
  [QuestionType.SingleChoice]: ChoicesQuestion,
  [QuestionType.MultipleChoice]: ChoicesQuestion,
  [QuestionType.Text]: TextQuestion,
  [QuestionType.Rating]: RatingQuestion
};

interface QuestionInputProps {
  questionFieldName: string;
  question: Question;
}

const QuestionInput = ({ questionFieldName, question }: QuestionInputProps) => {
  const {
    questionOptionsFieldName,
    questionTitleFieldName,
    questionTypeFieldName
  } = useQuestionTemplate(questionFieldName);

  const [field] = useField(questionTypeFieldName);

  const QuestionComponent = QuestionComponents[field.value as QuestionType];

  return (
    <VStack
      w='full'
      align='start'
      borderLeft='2px'
      borderColor='cyan'
      pl={5}
    >
      <HStack>
        <Field
          as={Input}
          name={questionTitleFieldName}
          placeholder={localization.questionTitle}
        />
        <Field
          as={Select}
          name={questionTypeFieldName}
        >
          {Object.entries(QuestionTypesLocalization).map(([key, value]) => (
            <option
              key={key}
              value={key}
            >
              {value}
            </option>
          ))}
        </Field>
      </HStack>
      <QuestionComponent
        type={question.type}
        optionsFieldName={questionOptionsFieldName}
      />
    </VStack>
  );
};

export default QuestionInput;
