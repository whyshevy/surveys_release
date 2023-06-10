import { Box, Button, Heading, VStack } from '@chakra-ui/react';
import { Question } from 'components/Surveys/SurveyPass/QuestionFactory/Question';
import { Survey } from 'models/surveys/Survey';
import { useMemo } from 'react';
import localization from 'resources/localization/localization';

interface SurveyFormProps {
  title: string;
  survey: Survey;
}

export const SurveyForm = ({ title, survey }: SurveyFormProps) => {
  const orderedQuestions = useMemo(() => {
    return survey?.questions.sort((q1, q2) => q1.order - q2.order);
  }, [survey]);

  return (
    <Box mt={25}>
      <VStack
        w='full'
        align='start'
        spacing={5}
        pl={5}
      >
        <Heading>{title}</Heading>
        <VStack
          w='full'
          align='start'
          spacing={5}
        >
          {orderedQuestions &&
            orderedQuestions.map((q, index) => (
              <Question
                key={q.id}
                question={q}
                name={`survey.answers.${index}`}
              />
            ))}
        </VStack>
        <Button type='submit'>{localization.submit}</Button>
      </VStack>
    </Box>
  );
};
