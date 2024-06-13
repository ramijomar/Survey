namespace Survey.Domain.SharedKernal.Validations
{
    public class ValidationFailure
    {
        public ValidationFailure(string errorMessage, string errorCode)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }

        public string ErrorMessage { get; }
        public string ErrorCode { get; }
    }
}
