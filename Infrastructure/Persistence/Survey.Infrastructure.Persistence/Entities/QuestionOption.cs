using Survey.Infrastructure.Persistence.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey.Infrastructure.Persistence.Entities
{
    public class QuestionOption : Entity
    {
        [Required]
        public Guid QuestionId { get; set; }
        [ForeignKey(nameof(QuestionId))]
        public Question Question { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
