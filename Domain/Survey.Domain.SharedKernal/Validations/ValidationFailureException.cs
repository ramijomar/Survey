namespace Survey.Domain.SharedKernal.Validations
{
    public class ValidationFailureException : Exception
    {
        public ValidationFailureException(string message = default, string errorCode = default)
        {
            Content = new ValidationFailure(message, errorCode);
        }

        public ValidationFailure Content { get; private set; }
    }
}
