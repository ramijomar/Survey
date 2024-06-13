using Survey.Domain.Entities;
using Survey.Domain.SharedKernal.ValueTypes;
using Survey.Infrastructure.Cqrs.Queries;

namespace Survey.Domain.Messages.Queries.Questionnaires
{
    public class GetQuestionnaireQuery : IQuery<Questionnaire>
    {
        public GetQuestionnaireQuery(QuestionnaireId id)
        {
            Id = id;
        }

        public QuestionnaireId Id { get; }
    }
}
