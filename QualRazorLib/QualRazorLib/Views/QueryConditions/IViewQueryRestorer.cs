namespace QualRazorLib.Views.QueryConditions
{
    /// <summary>
    /// Facadeなどの外部から受け取ったクエリ条件（例: DTOなど）を
    /// View側の状態として復元する責務を担うインターフェイス
    /// </summary>
    public interface IViewQueryRestorer<TCondition>
    {
        /// <summary>
        /// 外部から渡された条件オブジェクトを使ってViewの状態を更新する
        /// </summary>
        void RestoreFrom(TCondition condition);
    }
}
