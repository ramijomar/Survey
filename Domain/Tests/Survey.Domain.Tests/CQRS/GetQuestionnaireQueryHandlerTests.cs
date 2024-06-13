using NSubstitute;
using NUnit.Framework;
using Survey.Domain.Cqrs.Queries.Questionnaires;
using Survey.Domain.Entities;
using Survey.Domain.Messages.Queries.Questionnaires;
using Survey.Domain.Repositories.Questionnaires;
using Survey.Domain.SharedKernal.Enums;
using Survey.Domain.SharedKernal.Validations;
using Survey.Domain.SharedKernal.ValueTypes;
using Survey.Infrastructure.Cqrs;

namespace Survey.Domain.Tests.CQRS
{
    [TestFixture]
    public class GetQuestionnaireQueryHandlerTests
    {
        [Test]
        public void GetQuestionnaire_WithQuestionnaireIdDoesNotExist_ShouldThrowException()
        {
            //Arrange
            var substitutes = Substitutes.Build();
            var questionnaireId = QuestionnaireId.New(Guid.NewGuid());
            var questionnaireExist = false;

            substitutes.QuestionnaireReadRepositoryMock.Exist(questionnaireId, default)
                .Returns(Task.FromResult(questionnaireExist));

            var query = new GetQuestionnaireQuery(questionnaireId);

            //Act
            var sut = BuildSut(substitutes);
            var actualResult = Assert.ThrowsAsync<ValidationFailureException>(() 
                => sut.Handle(query, CancellationToken.None));

            //Assert
            Assert.That(actualResult.Content, Is.Not.Null);
            Assert.That(actualResult.Content.ErrorMessage, Is.EqualTo("questionnaire does not exist"));
            substitutes.QuestionnaireReadRepositoryMock.Received(1).Exist(Arg.Any<QuestionnaireId>(), default);
            substitutes.QuestionnaireReadRepositoryMock.DidNotReceive().Get(Arg.Any<QuestionnaireId>(), default);
        }

        [Test]
        public async Task GetQuestionnaire_WithQuestionnaireIdExist_ShouldReturnQuestionnaire()
        {
            //Arrange
            var substitutes = Substitutes.Build();
            var questionnaireId = QuestionnaireId.New(Guid.NewGuid());
            var inputBoxQuestionId = QuestionId.New(Guid.NewGuid());
            var checkBoxQuestionId = QuestionId.New(Guid.NewGuid());
            var selectListQuestionId = QuestionId.New(Guid.NewGuid());

            var questionnaireExist = true;

            substitutes.QuestionnaireReadRepositoryMock.Exist(questionnaireId, default)
                .Returns(Task.FromResult(questionnaireExist));

            var expectedQuestionnaire = new Questionnaire(questionnaireId,
                title: RandomText(),
                new List<Question>
                {
                    new Question(inputBoxQuestionId,
                    questionnaireId,
                    QuestionType.InputBox,
                    1,
                    RandomText(),
                    questionOptions: null),
                    new Question(checkBoxQuestionId,
                    questionnaireId,
                    QuestionType.CheckBox,
                    2,
                    RandomText(),
                    questionOptions: null),
                    new Question(selectListQuestionId,
                    questionnaireId,
                    QuestionType.SelectList,
                    3,
                    RandomText(),
                    new List<QuestionOption> 
                    {
                        new QuestionOption(QuestionOptionId.New(Guid.NewGuid()),
                        selectListQuestionId,
                        1,
                        RandomText()),
                        new QuestionOption(QuestionOptionId.New(Guid.NewGuid()),
                        selectListQuestionId,
                        2,
                        RandomText()),
                        new QuestionOption(QuestionOptionId.New(Guid.NewGuid()),
                        selectListQuestionId,
                        3,
                        RandomText())
                    })
                });

            substitutes.QuestionnaireReadRepositoryMock.Get(questionnaireId, default)
                .Returns(Task.FromResult(expectedQuestionnaire));

            var query = new GetQuestionnaireQuery(questionnaireId);

            //Act
            var sut = BuildSut(substitutes);
            var actualResult = await sut.Handle(query, CancellationToken.None);

            //Assert
            Assert.That(actualResult,Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(actualResult.Id, Is.EqualTo(expectedQuestionnaire.Id));
                Assert.That(actualResult.Title, Is.EqualTo(expectedQuestionnaire.Title));
            });

            CollectionAssert.AreEqual(
                expectedQuestionnaire.Questions
                .Select(question =>
                new
                {
                    question.Id,
                    question.QuestionnaireId,
                    question.Type,
                    question.Order,
                    question.Text
                }),
                actualResult.Questions
                .Select(question =>
                new
                {
                    question.Id,
                    question.QuestionnaireId,
                    question.Type,
                    question.Order,
                    question.Text,
                }));

            CollectionAssert.AreEqual(
                expectedQuestionnaire.Questions.Where(question => question.QuestionOptions is not null)
                .SelectMany(question => question.QuestionOptions)
                .Select(questionOption =>
                new
                {
                    questionOption.Id,
                    questionOption.QuestionId,
                    questionOption.Order,
                    questionOption.Text
                }),
                actualResult.Questions.Where(question => question.QuestionOptions is not null)
                .SelectMany(question => question.QuestionOptions)
                .Select(questionOption =>
                new
                {
                    questionOption.Id,
                    questionOption.QuestionId,
                    questionOption.Order,
                    questionOption.Text
                }));


            _ = substitutes.QuestionnaireReadRepositoryMock.Received(1).Exist(Arg.Any<QuestionnaireId>(), default);
            _ = substitutes.QuestionnaireReadRepositoryMock.Received(1).Get(Arg.Any<QuestionnaireId>(), default);
        }

        private static string RandomText(int length = 10)
        {
            var _rnd = new Random();
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
              .Select(s => s[_rnd.Next(s.Length)]).ToArray());
        }

        private static GetQuestionnaireQueryHandler BuildSut(Substitutes substitutes)
        {
            return new GetQuestionnaireQueryHandler(substitutes.MediatorMock,
                substitutes.QuestionnaireReadRepositoryMock);
        }

        private class Substitutes
        {
            public static Substitutes Build()
            {
                return new Substitutes();
            }

            private Substitutes()
            {
                MediatorMock = Substitute.For<IMediator>();
                QuestionnaireReadRepositoryMock = Substitute.For<IQuestionnaireReadRepository>();
            }

            public IMediator MediatorMock { get; }
            public IQuestionnaireReadRepository QuestionnaireReadRepositoryMock { get; }
        }
    }
}
