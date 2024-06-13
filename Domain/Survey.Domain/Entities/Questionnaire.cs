using Survey.Domain.SharedKernal.ValueTypes;

namespace Survey.Domain.Entities
{
    public class Questionnaire
    {
        public Questionnaire(QuestionnaireId id,
            string title,
            IReadOnlyCollection<Question> questions)
        {
            Id = id;
            Title = title;
            Questions = questions;
        }

        public QuestionnaireId Id { get; }
        public string Title { get; }
        public IReadOnlyCollection<Question> Questions { get; }
    }
}
