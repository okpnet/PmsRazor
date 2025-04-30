using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Tables.Argments;
using QualRazorCore.Core;

namespace QualRazorCore.Controls.Tables.Options
{
    /// <summary>
    /// テーブルの情報をビューへ提供する表示オプションクラス
    /// ユーザーとは対話しない
    /// </summary>
    public class TableInformationOption:NotifyCore
    {
        Func<PageInformationArg, string> _informationContentInvoke=default!;
        public Func<PageInformationArg, string> InformationContentInvoke
        {
            get => _informationContentInvoke;
            set
            {
                if (Equals(_informationContentInvoke , value))
                {
                    return;
                }
                _informationContentInvoke = value;
                OnPropertyChanged(nameof(InformationContentInvoke));
            }
        }

        Func<string> _prevLabelInvoke = default!;
        public Func<string> PrevLabelInvoke
        {
            get => _prevLabelInvoke;
            set
            {
                if (Equals(_prevLabelInvoke,value))
                {
                    return;
                }
                _prevLabelInvoke = value;
                OnPropertyChanged(nameof(PrevLabelInvoke));
            }
        }

        Func<string> _nextLabelInvoke = default!;
        public Func<string> NextLabelInvoke
        {
            get => _nextLabelInvoke;
            set
            {
                if (Equals(_nextLabelInvoke, value))
                {
                    return;
                }
                _nextLabelInvoke = value;
                OnPropertyChanged(nameof(NextLabelInvoke));
            }
        }

        EventCallback<int> _pageMoveInvoke = EventCallback<int>.Empty;
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
