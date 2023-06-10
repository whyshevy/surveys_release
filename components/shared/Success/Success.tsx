import { Box, Heading, Text } from '@chakra-ui/react';
import { CheckCircleIcon } from '@chakra-ui/icons';

import { OperationType } from '../OperationType';
import localization from '../../../resources/localization/localization';

interface SuccessProps {
  type: OperationType;
}

const getTitleAndDescirptionByOperationType = (type: OperationType) => {
  let title;
  let description;

  switch (type) {
    case OperationType.SignUp:
      title = localization.signUp;
      description = localization.signUpSuccessMessage;
      break;
    default:
      title = localization.unknown;
      description = '';
  }

  return { title, description };
};

const Success = ({ type }: SuccessProps) => {
  const { title, description } = getTitleAndDescirptionByOperationType(type);

  return (
    <Box
      textAlign='center'
      pt='15rem'
    >
      <CheckCircleIcon
        boxSize='50px'
        color='green.500'
      />
      <Heading
        as='h2'
        size='xl'
        mt={6}
        mb={2}
      >
        {title}
      </Heading>
      <Text color={'gray.500'}>{description}</Text>
    </Box>
  );
};

export default Success;
