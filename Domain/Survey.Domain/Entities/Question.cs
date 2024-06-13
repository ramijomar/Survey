using Survey.Domain.SharedKernal.Enums;
using Survey.Domain.SharedKernal.ValueTypes;

namespace Survey.Domain.Entities
{
    public class Question
    {
        public Question(QuestionId id,
            QuestionnaireId questionnaireId,
            QuestionType type,
            int order,
            string text,
            IReadOnlyCollection<QuestionOption> questionOptions)
        {
            Id = id;
            QuestionnaireId = questionnaireId;
            Type = type;
            Order = order;
            Text = text;
            QuestionOptions = questionOptions;
        }

        public QuestionId Id { get; }
        public QuestionnaireId QuestionnaireId { get; }
        public QuestionType Type { get; }
        public int Order { get; }
        public string Text { get; }
        public IReadOnlyCollection<QuestionOption> QuestionOptions { get; }
    }
}
