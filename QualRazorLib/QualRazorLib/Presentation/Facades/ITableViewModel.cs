using QualRazorLib.Core;
using QualRazorLib.Views.States;
using TalkLib.Pages.Results.ResultItems;

namespace QualRazorLib.Presentation.Facades
{

    public interface ITableViewModel
    {
        int MaxNumberOfPage { get; }
    }

    public interface ITableViewModel<T>: ITableViewModel, IDataHolder<ITalkPageResult<T>>, IViewState where T : class
    {

        Task LoadAsync();         // データの読み込み
        Task SubmitAsync();       // データの送信 or 更新
        void Reset();             // 初期状態に戻す
    }
}
