using QualRazorLib.Core;
using QualRazorLib.Models.Tables;
using QualRazorLib.Providers.Sources;
using QualRazorLib.Views.States;

namespace QualRazorLib.Presentation.Facades
{

    public interface ITableViewModel: ITableViewParameter
    {
        int MaxNumberOfPage { get; }
    }

    public interface ITableViewModel<T>: IViewModel, ITableViewParameter,IDataHolder<ITableDataProvider<T>>, IViewState where T : class
    {

    }
}
