import * as yup from 'yup';
import localization from '../../resources/localization/localization';

const signInValidationSchema = yup.object().shape({
  email: yup.string().required(localization.emailRequired),
  password: yup.string().required(localization.passwordRequired),
});

export { signInValidationSchema };
