import { QuestionType } from 'models/surveys';
import { SingleChoiceQuestion } from './SingleChoiceQuestion';
import { MultipleChoiceQuestion } from './MultipleChoiceQuestion';
import { TextQuestion } from './TextQuestion';
import { RatingQuestion } from './RatingQuestion';
import { Box, VStack } from '@chakra-ui/react';
import { QuestionProps } from './QuestionProps';


const QuestionComponents = {
  [QuestionType.SingleChoice]: SingleChoiceQuestion,
  [QuestionType.MultipleChoice]: MultipleChoiceQuestion,
  [QuestionType.Text]: TextQuestion,
  [QuestionType.Rating]: RatingQuestion
};

export const Question = ({ name, question }: QuestionProps) => {
  const QuestionComponent = QuestionComponents[question.type];

  return (
    <Box
      w='full'
      borderLeft='2px'
      borderColor='cyan'
    >
      <VStack
        align='start'
        ml={5}
      >
        <QuestionComponent question={question} name={`${name}`} />
      </VStack>
    </Box>
  );
};
