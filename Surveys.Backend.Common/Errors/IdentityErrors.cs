namespace Surveys.Backend.Common.Errors;

public static class IdentityErrors
{
    public const string DefaultError = nameof(DefaultError);
    public const string DuplicateEmail = nameof(DuplicateEmail);
    public const string DuplicateRoleName = nameof(DuplicateRoleName);
    public const string DuplicateUserName = nameof(DuplicateUserName);
    public const string InvalidEmail = nameof(InvalidEmail);
    public const string InvalidRoleName = nameof(InvalidRoleName);
    public const string InvalidToken = nameof(InvalidToken);
    public const string InvalidUserName = nameof(InvalidUserName);
    public const string LoginAlreadyAssociated = nameof(LoginAlreadyAssociated);
    public const string PasswordMismatch = nameof(PasswordMismatch);
    public const string PasswordRequiresDigit = nameof(PasswordRequiresDigit);
    public const string PasswordRequiresLower = nameof(PasswordRequiresLower);
    public const string PasswordRequiresNonAlphanumeric = nameof(PasswordRequiresNonAlphanumeric);
    public const string PasswordRequiresUniqueChars = nameof(PasswordRequiresUniqueChars);
    public const string PasswordRequiresUpper = nameof(PasswordRequiresUpper);
    public const string PasswordTooShort = nameof(PasswordTooShort);
    public const string RecoveryCodeRedemptionFailed = nameof(RecoveryCodeRedemptionFailed);
    public const string UserAlreadyHasPassword = nameof(UserAlreadyHasPassword);
    public const string UserAlreadyInRole = nameof(UserAlreadyInRole);
    public const string UserLockoutNotEnabled = nameof(UserLockoutNotEnabled);
    public const string UserNotInRole = nameof(UserNotInRole);
}