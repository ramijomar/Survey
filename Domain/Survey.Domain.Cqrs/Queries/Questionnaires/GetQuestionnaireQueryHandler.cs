using Survey.Domain.Entities;
using Survey.Domain.Messages.Queries.Questionnaires;
using Survey.Domain.Repositories.Questionnaires;
using Survey.Domain.SharedKernal.Validations;
using Survey.Domain.SharedKernal.ValueTypes;
using Survey.Infrastructure.Cqrs;
using Survey.Infrastructure.Cqrs.Queries;

namespace Survey.Domain.Cqrs.Queries.Questionnaires
{
    public class GetQuestionnaireQueryHandler : BaseQueryHandler<GetQuestionnaireQuery, Questionnaire>
    {
        private readonly IQuestionnaireReadRepository _questionnaireReadRepository;

        public GetQuestionnaireQueryHandler(IMediator mediator,
            IQuestionnaireReadRepository questionnaireReadRepository) : base(mediator)
        {
            _questionnaireReadRepository = questionnaireReadRepository;
        }

        public async override Task<Questionnaire> Handle(GetQuestionnaireQuery query, CancellationToken cancellationToken = default)
        {
            await CheckQuestionnaireExistance(query.Id, cancellationToken);

            return await _questionnaireReadRepository.Get(query.Id, cancellationToken);
        }

        private async Task CheckQuestionnaireExistance(QuestionnaireId questionnaireId, CancellationToken cancellationToken)
        {
            var questionnaireExist = await _questionnaireReadRepository.Exist(questionnaireId, cancellationToken);

            if (!questionnaireExist)
            {
                throw new ValidationFailureException("questionnaire does not exist");
            }
        }
    }
}
