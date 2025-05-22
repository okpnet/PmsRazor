using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorLib.Argments;
using QualRazorLib.Helpers;

namespace QualRazorLib.Core
{
    /// <summary>
    /// QaulRazorの基本クラス
    /// </summary>
    public abstract class QualRazorComponentBase: OwningComponentBase,IDisposable
    {
        /// <summary>
        /// ロングタップ管理
        /// </summary>
        private CancellationTokenSource _cts=new();
        /// <summary>
        /// ロングタップの冪等性
        /// </summary>
        private bool _isLongTupComplete = false;
        /// <summary>
        /// イベント削除管理
        /// </summary>
        protected readonly DisposableCollection disposables = [];

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? AdditionalAttributes { get; set; }
        
        #region"Parameter Disabled"
        protected bool _isDisabled = false;
        public string? DisabledValue { get; protected set; } = null;
        [Parameter]
        public bool IsDisabled { get; set; }
        #endregion

        #region"Parameter Hidden"
        protected bool _isHidden = true;
        public string? HiddenValue { get; protected set; } = null;
        [Parameter]
        public bool IsHidden { get; set; } = false;
        #endregion

        protected Dictionary<string, object> MeargeAttributeBase => HtmlAttributeHelper.MergeAttributes(
            AdditionalAttributes,
            new()
            {
                [HtmlAtributes.DISABLED] = DisabledValue!,
                [HtmlAtributes.CLASS] = HiddenValue!,
                [HtmlAtributes.MOUSEDOWNEVENT]=EventCallback.Factory.Create<MouseEventArgs>(this,OnMouseDown),
                [HtmlAtributes.MOUSEUPEVENT]= EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseUp),
            });

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (_isDisabled != IsDisabled)
            {//Disabledパラメーター
                _isDisabled = IsDisabled;
                DisabledValue = _isDisabled ? HtmlAtributes.DISABLED : null;
            }
            if (_isHidden != IsHidden)
            {//Hiddenパラメーター
                _isHidden = IsHidden;
                HiddenValue = _isHidden ? CssClasses.HIDDEN : "";
            }
        }
        /// <summary>
        /// マウス左クリックイベント
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected virtual Task OnLeftMouseClick(MouseKeyArg e)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// マウス右クリックイベント。ロングタッチ後もこのイベント。
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected virtual Task OnRightMouseClick(MouseKeyArg e)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// マウスのクリックに関するイベント
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected virtual Task OnMouseClick(MouseEventArgs e)
        {
            var arg = new MouseKeyArg(e.ShiftKey, e.AltKey);
            switch (e.Button)
            {
                case 0:
                    return OnLeftMouseClick(arg);
                case 1:
                    return OnRightMouseClick(arg);
            }
            return Task.CompletedTask;
        }

        
        /// <summary>
        /// 破棄の処理
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            disposables.Clear();
            base.Dispose(disposing);
        }
        /// <summary>
        /// ロングタッチ用にクリックではなくダウンの状態を定義
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMouseDown(MouseEventArgs e)
        {
            switch (e.Button)
            {
                case 0:
                    _isLongTupComplete = false;
                    _cts = new CancellationTokenSource();
                    var progress = new Progress<int>((value) => System.Diagnostics.Debug.WriteLine($"long touch {value}%"));
                    ExecuteWithProgressFireAndForget(
                        progress,
                        () =>
                        {
                            var arg = new MouseKeyArg(e.ShiftKey, e.AltKey);
                            OnRightMouseClick(arg );
                        },
                        _cts.Token);
                    break;
            }
        }
        /// <summary>
        /// ロングタッチの判定をキャンセルする
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMouseUp(MouseEventArgs e)
        {
            if (_isLongTupComplete || _cts.IsCancellationRequested)
            {
                return;
            }
            _cts.Cancel();
        }

        /// <summary>
        /// 長押しタイマ
        /// </summary>
        /// <param name="reportProgress"></param>
        /// <param name="onCompleted"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected Task ExecuteWithProgressAsync(IProgress<int> reportProgress,Action onCompleted,CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                const int totalDurationMs = 4000;
                const int intervalMs = 500;
                const int steps = totalDurationMs / intervalMs;

                try
                {
                    for (int i = 1; i <= steps; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(intervalMs, cancellationToken);

                        int progress = (i * 100) / steps;
                        reportProgress.Report(progress);
                    }

                    cancellationToken.ThrowIfCancellationRequested();
                    _isLongTupComplete = true;
                    onCompleted.Invoke();
                }
                catch (OperationCanceledException)
                {
                }
            });
        }

        // Fire-and-forget スタイル
        protected void ExecuteWithProgressFireAndForget(IProgress<int> reportProgress,Action onCompleted,CancellationToken cancellationToken)
        {
            _ = ExecuteWithProgressAsync(reportProgress, onCompleted, cancellationToken);
        }
    }
}
