using Survey.Domain.SharedKernal.ValueTypes;

namespace Survey.Infrastructure.Persistence.Extensions
{
    public static class QuestionOptionExtensions
    {
        public static Domain.Entities.QuestionOption ToModel(this Entities.QuestionOption questionOption)
        {
            return new Domain.Entities.QuestionOption(QuestionOptionId.New(questionOption.Id),
                QuestionId.New(questionOption.QuestionId),
                questionOption.Order,
                questionOption.Text);
        }
    }
}
