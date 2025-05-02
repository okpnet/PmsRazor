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
        /// <summary>
        /// テーブルインフォメーションメッセージコンテンツデリゲート
        /// </summary>
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
        /// <summary>
        /// 戻るボタンラベルを取得するデリゲート
        /// </summary>
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
        /// <summary>
        /// 次ボタンラベルを取得するデリゲート
        /// </summary>
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

        protected Dictionary<string, object> _containerAdditionalAttributes = new();
        /// <summary>
        /// インフォメーションDIVの属性
        /// </summary>
        public Dictionary<string, object> ContainerAdditionalAttributes
        {
            get => _containerAdditionalAttributes;
            set
            {
                if (Equals(_containerAdditionalAttributes, value))
                {
                    return;
                }
                _containerAdditionalAttributes = value;
                OnPropertyChanged(nameof(ContainerAdditionalAttributes));
            }
        }

        protected Dictionary<string, object> _informationAdditionalAttributes = new();
        /// <summary>
        /// テーブルインフォメーションメッセージの属性
        /// </summary>
        public Dictionary<string, object> InformationAdditionalAttributes
        {
            get => _informationAdditionalAttributes;
            set
            {
                if (Equals(_informationAdditionalAttributes, value))
                {
                    return;
                }
                _informationAdditionalAttributes = value;
                OnPropertyChanged(nameof(InformationAdditionalAttributes));
            }
        }

        protected Dictionary<string, object> _buttonGroupAdditionalAttributes = new();
        /// <summary>
        /// ページボタングループの属性
        /// </summary>
        public Dictionary<string, object> ButtonGroupAdditionalAttributes
        {
            get => _buttonGroupAdditionalAttributes;
            set
            {
                if (Equals(_buttonGroupAdditionalAttributes, value))
                {
                    return;
                }
                _buttonGroupAdditionalAttributes = value;
                OnPropertyChanged(nameof(ButtonGroupAdditionalAttributes));
            }
        }

        protected Dictionary<string, object> _buttonAdditionalAttributes = new();
        /// <summary>
        /// ページボタンのデフォルト属性
        /// </summary>
        public Dictionary<string, object> ButtonAdditionalAttributes
        {
            get => _buttonAdditionalAttributes;
            set
            {
                if (Equals(_buttonAdditionalAttributes, value))
                {
                    return;
                }
                _buttonAdditionalAttributes = value;
                OnPropertyChanged(nameof(ButtonAdditionalAttributes));
            }
        }

        protected Dictionary<string, object> _activeButtonAdditionalAttributes = new();
        /// <summary>
        /// ページボタンのカレント属性
        /// </summary>
        public Dictionary<string, object> ActiveButtonAdditionalAttributes
        {
            get => _activeButtonAdditionalAttributes;
            set
            {
                if (Equals(_activeButtonAdditionalAttributes, value))
                {
                    return;
                }
                _activeButtonAdditionalAttributes = value;
                OnPropertyChanged(nameof(ActiveButtonAdditionalAttributes));
            }
        }

    }
}
