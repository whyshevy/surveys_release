import * as yup from 'yup';
import localization from '../../resources/localization/localization';

const MIN_PASSWORD_LENGTH = 6;

const signUpValidationSchema = yup.object().shape({
  name: yup.string().required(localization.nameRequired),
  email: yup.string().email().required(localization.emailRequired),
  password: yup
    .string()
    .min(
      MIN_PASSWORD_LENGTH,
      localization.passwordMinLengthError(MIN_PASSWORD_LENGTH)
    )
    .required(localization.passwordRequired),
});

export { signUpValidationSchema };
