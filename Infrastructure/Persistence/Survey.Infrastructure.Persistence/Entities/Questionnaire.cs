using Survey.Infrastructure.Persistence.Shared;
using System.ComponentModel.DataAnnotations;

namespace Survey.Infrastructure.Persistence.Entities
{
    public class Questionnaire : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
