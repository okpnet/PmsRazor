using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Argments;
using QualRazorCore.Controls.Tables.Parameters;
using QualRazorCore.Core;

namespace QualRazorCore.Controls.Tables.Options
{
    /// <summary>
    /// テーブルの情報をビューへ提供する表示オプションクラス
    /// ユーザーとは対話しない
    /// </summary>
    public class InformationParameter:NotifyCore, IInformationParameter
    {
        protected bool _isSorted;
        /// <summary>
        /// ソートが有効
        /// </summary>
        public bool IsSorted 
        {
            get => _isSorted;
            set
            {
                if (_isSorted == value)
                {
                    return;
                }
                _isSorted = value;
                OnPropertyChanged(nameof(IsSorted));
            }
        }

        EventCallback<int> _pageMoveInvoke = EventCallback<int>.Empty;
        /// <summary>
        /// 指定ページ呼び出し
        /// </summary>
        public EventCallback<int> PageMoveInvoke
        {
            get => _pageMoveInvoke;
            set
            {
                if (Equals(_pageMoveInvoke,value))
                {
                    return;
                }
                _pageMoveInvoke = value;
                OnPropertyChanged(nameof(PageMoveInvoke));
            }
        }

        EventCallback<ColumnChangeOrderArg> _changeSortOrder;
        public EventCallback<ColumnChangeOrderArg> ChangeSortOrder 
        {
            get => _changeSortOrder;
            set
            {
                if(EventCallback.Equals(_changeSortOrder, value))
                {
                    return;
                }
                _changeSortOrder = value;
                OnPropertyChanged(nameof(ChangeSortOrder));
            }
        }

        int _maxNumberOfPage = 10;
        /// <summary>
        /// ページネーションボタンを表示する個数
        /// </summary>
        public int MaxNumberOfPage
        {
            get => _maxNumberOfPage;
            set
            {
                if (_maxNumberOfPage == value)
                {
                    return;
                }
                _maxNumberOfPage = value;
                OnPropertyChanged(nameof(MaxNumberOfPage));
            }
        }
    }
}
