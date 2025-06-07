using System.Collections.ObjectModel;

namespace QualRazorLib.Providers.Sources
{
    public class TableDataProvider<TModel> : ITableDataProvider<TModel>, IDataProvider where TModel : class
    {
        public int NumberOfRecords { get; set; }

        public int NumberOfMatchedRecords { get; set; }

        public int NumberOfPage { get; set; }

        public int PageNumber { get; set; }

        public ObservableCollection<TModel> Sources { get; set; } = default!;

        public TableDataProvider() 
        {
        }

        public TableDataProvider(int numberOfRecords, int numberOfMatchedRecords, int numberOfPage, int pageNumber, ObservableCollection<TModel> sources)
        {
            NumberOfRecords = numberOfRecords;
            NumberOfMatchedRecords = numberOfMatchedRecords;
            NumberOfPage = numberOfPage;
            PageNumber = pageNumber;
            Sources = sources;
        }
    }
}
