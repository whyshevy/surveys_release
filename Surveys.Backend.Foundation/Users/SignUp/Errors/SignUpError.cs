namespace Surveys.Backend.Foundation.Users.SignUp.Errors;

public enum SignUpError
{
    DuplicateEmail,
    DuplicateRoleName,
    DuplicateUserName,
    InvalidEmail,
    InvalidRoleName,
    InvalidToken,
    InvalidUserName,
    LoginAlreadyAssociated,
    PasswordMismatch,
    PasswordRequiresDigit,
    PasswordRequiresLower,
    PasswordRequiresNonAlphanumeric,
    PasswordRequiresUniqueChars,
    PasswordRequiresUpper,
    PasswordTooShort,
    RecoveryCodeRedemptionFailed,
    UserAlreadyHasPassword,
    UserAlreadyInRole,
    UserLockoutNotEnabled,
    UserNotInRole,
    Unknown
}