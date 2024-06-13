using Microsoft.AspNetCore.Mvc;
using Survey.Domain.Messages.Queries.Questionnaires;
using Survey.Domain.SharedKernal.ValueTypes;
using Survey.Questionnaire.Api.Models;
using Survey.Web.Shared;
using Survey.Web.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Survey.Questionnaire.Api.Controllers
{
    [ApiController]
    [Route("questionnaire")]
    public class QuestionnaireController : ApiBaseController
    {
        private readonly ILogger<QuestionnaireController> _logger;

        public QuestionnaireController(IServiceProvider serviceProvider, ILogger<QuestionnaireController> logger)
            :base(serviceProvider)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuestionnaireDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([Required] string id, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(id, out var quizId))
            {
                var errorMessage = $"Invalid questionnaireId id - {id}";
                _logger.Log(LogLevel.Error, errorMessage);

                return JsonContentResult.Error(errorMessage);
            }

            var result = await Send(new GetQuestionnaireQuery(QuestionnaireId.New(quizId)), cancellationToken);

            return JsonContentResult.Success(new QuestionnaireDto(result));
        }
    }
}