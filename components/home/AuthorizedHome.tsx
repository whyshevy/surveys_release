import { Box } from '@chakra-ui/react';
import { JwtPayload } from '../../models/auth/Jwt';

interface AuthorizedHomeProps {
  payload: JwtPayload;
}

const AuthorizedHome = ({ payload }: AuthorizedHomeProps) => {
  return <Box>Hello, {payload.name}</Box>;
};

export default AuthorizedHome;
