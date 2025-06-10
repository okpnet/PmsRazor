namespace QualRazorLibViewTest.Dtos
{
    public class ValueResult<T>
    {
        public int NumberOfRecords { get; set; }

        public int NumberOfMatchedRecords { get; set; }

        public int NumberOfPage { get; set; }

        public int PageNumber { get; set; }

        public IEnumerable<T> Sources { get; set; } = default!;
    }
}
