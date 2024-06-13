using Survey.Domain.Entities;
using Survey.Domain.SharedKernal.ValueTypes;

namespace Survey.Domain.Repositories.Questionnaires
{
    public interface IQuestionnaireReadRepository
    {
        Task<bool> Exist(QuestionnaireId id, CancellationToken cancellationToken);
        Task<Questionnaire> Get(QuestionnaireId id, CancellationToken cancellationToken);
    }
}
