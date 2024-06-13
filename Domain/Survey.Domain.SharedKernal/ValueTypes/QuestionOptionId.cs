namespace Survey.Domain.SharedKernal.ValueTypes
{
    public readonly struct QuestionOptionId
    {
        public QuestionOptionId(Guid value) => Value = value;
        public Guid Value { get; }
        public static QuestionOptionId Empty => New(Guid.Empty);
        public static QuestionOptionId New(Guid id) => new(id);
        public override string ToString() => Value.ToString();
        public bool Equals(QuestionOptionId other) => Value.Equals(other.Value);
    }
}
