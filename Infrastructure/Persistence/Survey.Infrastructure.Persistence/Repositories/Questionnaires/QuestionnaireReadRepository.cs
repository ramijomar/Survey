using Microsoft.EntityFrameworkCore;
using Survey.Domain.Entities;
using Survey.Domain.Repositories.Questionnaires;
using Survey.Domain.SharedKernal.ValueTypes;
using Survey.Infrastructure.Persistence.DbContexts;
using Survey.Infrastructure.Persistence.Extensions;

namespace Survey.Infrastructure.Persistence.Repositories.Questionnaires
{
    public class QuestionnaireReadRepository : IQuestionnaireReadRepository
    {
        private readonly ISurveyDbContext _dbContext;

        public QuestionnaireReadRepository(ISurveyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> Exist(QuestionnaireId id, CancellationToken cancellationToken)
        {
            return _dbContext.Questionnaires
                .AnyAsync(questionnaire => questionnaire.Id.ToString() == id.Value.ToString(),
                cancellationToken);
        }

        public async Task<Questionnaire> Get(QuestionnaireId id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Questionnaires
                .Include(questionnaire => questionnaire.Questions.OrderBy(question => question.Order))
                .ThenInclude(question => question.QuestionOptions.OrderBy(questionOption => questionOption.Order))
                .AsNoTracking()
                .SingleAsync(quiz => quiz.Id.ToString() == id.Value.ToString(), cancellationToken)
                .ConfigureAwait(false);

            return result.ToModel();
        }
    }
}
