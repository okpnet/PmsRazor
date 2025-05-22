using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Intterfaces
{
    /// <summary>
    /// 窓口（Facade）としてUIからの呼び出しを一元化する
    /// </summary>
    public interface IViewModel<T> : IDataHolder<T>, IViewState, IActionDispatcher
    {
        Task LoadAsync();         // データの読み込み
        Task SubmitAsync();       // データの送信 or 更新
        void Reset();             // 初期状態に戻す
    }
}
