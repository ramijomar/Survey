using Survey.Domain.SharedKernal.ValueTypes;

namespace Survey.Infrastructure.Persistence.Extensions
{
    public static class QuestionExtensions
    {
        public static Domain.Entities.Question ToModel(this Entities.Question question)
        {
            return new Domain.Entities.Question(QuestionId.New(question.Id),
                QuestionnaireId.New(question.QuestionnaireId),
                question.Type,
                question.Order,
                question.Text,
                question.QuestionOptions?.Select(questionOption => questionOption.ToModel()).ToList());
        }
    }
}
