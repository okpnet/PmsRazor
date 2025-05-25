using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorLib.Controls.Argments;
using QualRazorLib.Helpers;

namespace QualRazorLib.Core
{
    /// <summary>
    /// QualRazorライブラリのRazorコンポーネントの基底クラスです。
    /// <para>
    /// ・コンポーネントの有効/無効（IsDisabled）や表示/非表示（IsHidden）などの基本的な状態管理機能を提供します。<br/>
    /// ・追加属性（AdditionalAttributes）のマージや、HTML属性の自動付与をサポートします。<br/>
    /// ・マウスイベント（クリック、ロングタップ等）のハンドリングや、長押し判定の仕組みを備えています。<br/>
    /// ・IDisposableの一括管理（DisposableCollection）によるリソース管理を行います。<br/>
    /// </para>
    /// このクラスを継承することで、共通的なUI動作や属性管理、イベント処理の実装を簡素化できます。
    /// </summary>
    public abstract class QualRazorComponentBase : OwningComponentBase, IDisposable
    {
        /// <summary>
        /// ロングタップ判定用のキャンセルトークンソース。
        /// </summary>
        private CancellationTokenSource _cts = new();

        /// <summary>
        /// ロングタップが完了したかどうかのフラグ。
        /// </summary>
        private bool _isLongTupComplete = false;

        /// <summary>
        /// IDisposableリソースの一括管理用コレクション。
        /// </summary>
        protected readonly DisposableCollection disposables = [];

        /// <summary>
        /// 任意の追加HTML属性を受け取るパラメータ。
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? AdditionalAttributes { get; set; }

        #region "Parameter Disabled"
        /// <summary>
        /// 無効状態の内部フラグ。
        /// </summary>
        protected bool _isDisabled = false;

        /// <summary>
        /// 無効状態時に付与する属性値（例: "disabled"）。
        /// </summary>
        public string? DisabledValue { get; protected set; } = null;

        /// <summary>
        /// コンポーネントの有効/無効を制御するパラメータ。
        /// </summary>
        [Parameter]
        public bool IsDisabled { get; set; }
        #endregion

        #region "Parameter Hidden"
        /// <summary>
        /// 非表示状態の内部フラグ。
        /// </summary>
        protected bool _isHidden = true;

        /// <summary>
        /// 非表示状態時に付与するCSSクラス名。
        /// </summary>
        public string? HiddenValue { get; protected set; } = null;

        /// <summary>
        /// コンポーネントの表示/非表示を制御するパラメータ。
        /// </summary>
        [Parameter]
        public bool IsHidden { get; set; } = false;
        #endregion

        /// <summary>
        /// HTML属性をマージし、状態に応じた属性やイベントハンドラを付与します。
        /// </summary>
        protected Dictionary<string, object> MeargeAttributeBase => HtmlAttributeHelper.MergeAttributes(
            AdditionalAttributes,
            new()
            {
                [HtmlAtributes.DISABLED] = DisabledValue!,
                [HtmlAtributes.CLASS] = HiddenValue!,
                [HtmlAtributes.MOUSEDOWNEVENT] = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseDown),
                [HtmlAtributes.MOUSEUPEVENT] = EventCallback.Factory.Create<MouseEventArgs>(this, OnMouseUp),
            });

        /// <summary>
        /// パラメータが設定された際の状態更新処理。
        /// </summary>
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
        /// マウス左クリックイベントの仮想メソッド。必要に応じて派生クラスでオーバーライドしてください。
        /// </summary>
        /// <param name="e">マウスキー引数</param>
        /// <returns>非同期タスク</returns>
        protected virtual Task OnLeftMouseClick(MouseKeyArg e)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// マウス右クリックイベントの仮想メソッド。ロングタッチ後もこのイベントが呼ばれます。
        /// </summary>
        /// <param name="e">マウスキー引数</param>
        /// <returns>非同期タスク</returns>
        protected virtual Task OnRightMouseClick(MouseKeyArg e)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// マウスクリックイベントの仮想メソッド。ボタン種別に応じて左/右クリックイベントを呼び出します。
        /// </summary>
        /// <param name="e">マウスイベント引数</param>
        /// <returns>非同期タスク</returns>
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
        /// 破棄処理。DisposableCollectionのクリアと基底クラスのDisposeを呼び出します。
        /// </summary>
        /// <param name="disposing">Dispose呼び出し元の判定</param>
        protected override void Dispose(bool disposing)
        {
            disposables.Clear();
            base.Dispose(disposing);
        }

        /// <summary>
        /// ロングタッチ判定用のマウスダウンイベント。
        /// </summary>
        /// <param name="e">マウスイベント引数</param>
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
                            OnRightMouseClick(arg);
                        },
                        _cts.Token);
                    break;
            }
        }

        /// <summary>
        /// ロングタッチ判定のキャンセル用マウスアップイベント。
        /// </summary>
        /// <param name="e">マウスイベント引数</param>
        protected virtual void OnMouseUp(MouseEventArgs e)
        {
            if (_isLongTupComplete || _cts.IsCancellationRequested)
            {
                return;
            }
            _cts.Cancel();
        }

        /// <summary>
        /// 長押し（ロングタッチ）判定用の非同期タイマー処理。
        /// </summary>
        /// <param name="reportProgress">進捗通知用IProgress</param>
        /// <param name="onCompleted">完了時コールバック</param>
        /// <param name="cancellationToken">キャンセルトークン</param>
        /// <returns>非同期タスク</returns>
        protected Task ExecuteWithProgressAsync(IProgress<int> reportProgress, Action onCompleted, CancellationToken cancellationToken)
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

        /// <summary>
        /// 長押し判定の非同期処理をfire-and-forgetで実行します。
        /// </summary>
        /// <param name="reportProgress">進捗通知用IProgress</param>
        /// <param name="onCompleted">完了時コールバック</param>
        /// <param name="cancellationToken">キャンセルトークン</param>
        protected void ExecuteWithProgressFireAndForget(IProgress<int> reportProgress, Action onCompleted, CancellationToken cancellationToken)
        {
            _ = ExecuteWithProgressAsync(reportProgress, onCompleted, cancellationToken);
        }
    }
}