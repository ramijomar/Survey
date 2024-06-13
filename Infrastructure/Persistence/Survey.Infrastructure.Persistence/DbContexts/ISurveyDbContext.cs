using Microsoft.EntityFrameworkCore;
using Survey.Infrastructure.Persistence.Entities;

namespace Survey.Infrastructure.Persistence.DbContexts
{
    public interface ISurveyDbContext
    {
        DbSet<Questionnaire> Questionnaires { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<QuestionOption> QuestionOptions { get; set; }
    }
}
