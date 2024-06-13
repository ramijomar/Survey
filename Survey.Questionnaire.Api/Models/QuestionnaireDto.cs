using Survey.Domain.SharedKernal.Enums;

namespace Survey.Questionnaire.Api.Models
{
    public class QuestionnaireDto
    {
        public QuestionnaireDto(Domain.Entities.Questionnaire questionnaire)
        {
            Id = questionnaire.Id.Value;
            Title = questionnaire.Title;
            Questions = questionnaire.Questions.Select(question => new QuestionDto(question));
        }

        public Guid Id { get; }
        public string Title { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; }

        public class QuestionDto
        {
            public QuestionDto(Domain.Entities.Question question)
            {
                Id = question.Id.Value;
                Type = question.Type;
                Text = question.Text;
                QuestionOptions = question.QuestionOptions.Select(questionOption => new QuestionOptionDto(questionOption));
            }

            public Guid Id { get; }
            public QuestionType Type { get; }
            public string Text { get; }
            public IEnumerable<QuestionOptionDto> QuestionOptions { get; }

            public class QuestionOptionDto
            {
                public QuestionOptionDto(Domain.Entities.QuestionOption questionOption)
                {
                    Id = questionOption.Id.Value;
                    Text = questionOption.Text;
                }

                public Guid Id { get; }
                public string Text { get; }
            }
        }
    }
}
