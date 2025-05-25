using QualRazorLib.Core;
using QualRazorLib.Views.States;

namespace QualRazorLib.Presentation.Facades
{
    /// <summary>
    /// 窓口（Facade）としてUIからの呼び出しを一元化する
    /// </summary>
    public interface IViewModel<T> : IDataHolder<T>, IViewState
    {
        Task LoadAsync();         // データの読み込み
        Task SubmitAsync();       // データの送信 or 更新
        void Reset();             // 初期状態に戻す
    }
}
