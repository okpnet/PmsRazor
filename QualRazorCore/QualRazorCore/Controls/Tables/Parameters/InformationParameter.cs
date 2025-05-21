using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Argments;
using QualRazorCore.Core;

namespace QualRazorCore.Controls.Tables.Options
{
    /// <summary>
    /// テーブルの情報をビューへ提供する表示オプションクラス
    /// ユーザーとは対話しない
    /// </summary>
    public class InformationParameter:NotifyCore
    {
        EventCallback<int> _pageMoveInvoke = EventCallback<int>.Empty;
        /// <summary>
        /// 指定ページ呼び出し
        /// </summary>
        public EventCallback<int> PageMoveInvoke
        {
            get => _pageMoveInvoke;
            set
            {
                if (_pageMoveInvoke.Equals(value))
                {
                    return;
                }
                _pageMoveInvoke = value;
                OnPropertyChanged(nameof(PageMoveInvoke));
            }
        }

        int _maxPaageCount = 10;
        /// <summary>
        /// ページネーションボタンを表示する個数
        /// </summary>
        public int MaxPageCount
        {
            get => _maxPaageCount;
            set
            {
                if (_maxPaageCount == value)
                {
                    return;
                }
                _maxPaageCount = value;
                OnPropertyChanged(nameof(MaxPageCount));
            }
        }
    }
}
