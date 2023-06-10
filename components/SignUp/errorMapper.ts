import localization from '../../resources/localization/localization';

enum SignUpError {
  DuplicateEmail = 'DuplicateEmail',
  DuplicateRoleName = 'DuplicateRoleName',
  DuplicateUserName = 'DuplicateUserName',
  InvalidEmail = 'InvalidEmail',
  InvalidRoleName = 'InvalidRoleName',
  InvalidToken = 'InvalidToken',
  InvalidUserName = 'InvalidUserName',
  LoginAlreadyAssociated = 'LoginAlreadyAssociated',
  PasswordMismatch = 'PasswordMismatch',
  PasswordRequiresDigit = 'PasswordRequiresDigit',
  PasswordRequiresLower = 'PasswordRequiresLower',
  PasswordRequiresNonAlphanumeric = 'PasswordRequiresNonAlphanumeric',
  PasswordRequiresUniqueChars = 'PasswordRequiresUniqueChars',
  PasswordRequiresUpper = 'PasswordRequiresUpper',
  PasswordTooShort = 'PasswordTooShort',
  RecoveryCodeRedemptionFailed = 'RecoveryCodeRedemptionFailed',
  UserAlreadyHasPassword = 'UserAlreadyHasPassword',
  UserAlreadyInRole = 'UserAlreadyInRole',
  UserLockoutNotEnabled = 'UserLockoutNotEnabled',
  UserNotInRole = 'UserNotInRole',
  Unknown = 'Unknown',
}

const getErrorDescription = (error: string | null) => {
  let errorDescription;

  switch (error) {
    case SignUpError.DuplicateEmail:
      errorDescription = localization.emailDuplicate;
      break;
    case SignUpError.InvalidEmail:
      errorDescription = localization.emailInvalid;
      break;
    case SignUpError.PasswordRequiresDigit:
      errorDescription = localization.passwordRequired;
      break;
    case SignUpError.PasswordRequiresLower:
      errorDescription = localization.passwordRequiresLower;
      break;
    case SignUpError.PasswordRequiresNonAlphanumeric:
      errorDescription = localization.passwordRequiresNonAlphanumeric;
      break;
    case SignUpError.PasswordRequiresUpper:
      errorDescription = localization.passwordRequiresUpper;
      break;
    case SignUpError.PasswordTooShort:
      errorDescription = localization.passwordTooShort;
      break;
    default:
      errorDescription = localization.signUpErrorMessage;
  }

  return errorDescription;
};

export { SignUpError, getErrorDescription };
