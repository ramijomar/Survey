namespace Survey.Domain.SharedKernal.ValueTypes
{
    public readonly struct QuestionnaireId
    {
        public QuestionnaireId(Guid value) => Value = value;
        public Guid Value { get; }
        public static QuestionnaireId Empty => New(Guid.Empty);
        public static QuestionnaireId New(Guid id) => new(id);
        public override string ToString() => Value.ToString();
        public bool Equals(QuestionnaireId other) => Value.Equals(other.Value);
    }
}
