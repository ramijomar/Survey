using Survey.Domain.SharedKernal.Enums;
using Survey.Infrastructure.Persistence.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey.Infrastructure.Persistence.Entities
{
    public class Question : Entity
    {
        [Required]
        public Guid QuestionnaireId { get; set; }
        [ForeignKey(nameof(QuestionnaireId))]
        public Questionnaire Questionnaire { get; set; }
        [Required]
        public QuestionType Type { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public string Text { get; set; }
        public ICollection<QuestionOption> QuestionOptions { get; set; }
    }
}
