using QualRazorCore.Controls.Tables.Helpers;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Controls.Tables.Rows.Core;
using System.ComponentModel;

namespace QualRazorCore.Controls.Tables.Extensions
{
    /// <summary>
    /// TableSchemaOption の状態変更を監視し、その変化をテーブル表示に伝えることで、両者を直接結びつけることなく連携を可能にする中間層クラス。
    /// *ビューにバインドする使用者がセットするコレクションを監視。ビューにバインドするパラメーターに変換して登録して、ビューが関しするプロパティにセットするためのActionを呼び出す。
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class TableSchemaOptionNotifier<TModel>:IDisposable where TModel:class
    {
        private readonly TableSchemaOption<TModel> _option;
        private readonly Action<IEnumerable<TableRowState<TModel>>> _setSourceAction;
        private readonly PropertyChangedEventHandler _handler;


        public TableSchemaOptionNotifier(TableSchemaOption<TModel> option, Action<IEnumerable<TableRowState<TModel>>> setSourceAction)
        {
            _option = option;
            _setSourceAction = setSourceAction;
            _handler = (sender, e) =>
            {
                if (e.PropertyName == nameof(_option.PageResult))
                {
                    _setSourceAction.Invoke(_option.GenerateSource());
                }
            };

            _option.PropertyChanged += _handler;
        }

        public void Dispose()
        {
            _option.PropertyChanged -= _handler;
        }
    }
}
