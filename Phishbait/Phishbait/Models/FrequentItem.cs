namespace Phishbait
{
    public enum PhishDataType
    {
        Undefined,
        Positive,
        Negative
    }

    public partial class FrequentItem : AuditableEntity
    {
        public FrequentItem()
        {

        }

        public string Term { get; set; }

        public int Frequency { get; set; }

        public int MinimumFrequency { get; set; }

        public PhishDataType ItemType { get; set; } = PhishDataType.Undefined;
    }

}
