using System.Collections.ObjectModel;

namespace QualRazorLib.Providers.Sources
{
    public interface ITableDataProvider<TModel>: IDataProvider where TModel : class
    {
        int NumberOfRecords { get; }

        int NumberOfMatchedRecords { get; }

        int NumberOfPage { get; }

        int PageNumber { get; }

        ObservableCollection<TModel> Sources { get; }
    }
}
