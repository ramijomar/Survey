namespace Survey.Domain.SharedKernal.ValueTypes
{
    public readonly struct QuestionId
    {
        public QuestionId(Guid value) => Value = value;
        public Guid Value { get; }
        public static QuestionId Empty => New(Guid.Empty);
        public static QuestionId New(Guid id) => new(id);
        public override string ToString() => Value.ToString();
        public bool Equals(QuestionId other) => Value.Equals(other.Value);
    }
}
