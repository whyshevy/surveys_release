import { FieldArray } from 'formik';
import { Button, VStack } from '@chakra-ui/react';

import { createEmptyQuestion } from 'models/factories/question';
import localization from 'resources/localization/localization';

import QuestionInput from './QuestionInput';
import { useQuestionsInput } from './hooks/useQuestionsInput';


interface QuestionsInputProps {
  questionsFieldName: string;
}

const QuestionsInput = ({ questionsFieldName }: QuestionsInputProps) => {
  const { questions, getQuestionFieldName } = useQuestionsInput(questionsFieldName);

  return (
    <FieldArray name={questionsFieldName}>
      {({ push }) => (
        <VStack spacing={6} w='2xl' justify='center'>
          {
            questions && questions.map((question, index) =>(
              <QuestionInput
                key={question.id}
                questionFieldName={getQuestionFieldName(index)}
                question={question}
              />
            ))
          }
          <Button onClick={() => push(createEmptyQuestion(questions.length + 1))}>
            {localization.addQuestion}
          </Button>
        </VStack>)}
    </FieldArray>
  )
}

export default QuestionsInput;
