using Survey.Domain.SharedKernal.ValueTypes;

namespace Survey.Domain.Entities
{
    public class QuestionOption
    {
        public QuestionOption(QuestionOptionId id,
            QuestionId questionId,
            int order,
            string text)
        {
            Id = id;
            QuestionId = questionId;
            Order = order;
            Text = text;
        }

        public QuestionOptionId Id { get; }
        public QuestionId QuestionId { get; }
        public int Order { get; }
        public string Text { get; }
    }
}
