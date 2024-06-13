using Survey.Domain.SharedKernal.ValueTypes;

namespace Survey.Infrastructure.Persistence.Extensions
{
    public static class QuestionnaireExtensions
    {
        public static Domain.Entities.Questionnaire ToModel(this Entities.Questionnaire questionnaire)
        {
            return new Domain.Entities.Questionnaire(QuestionnaireId.New(questionnaire.Id),
                questionnaire.Title,
                questionnaire.Questions?.Select(question => question.ToModel()).ToList());
        }
    }
}
